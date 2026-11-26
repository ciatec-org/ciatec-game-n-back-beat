// Relógio injetável. O jogo lê o tempo por Relogio.Atual em vez de Time.time / Time.deltaTime.
//
// Por que existe: no PlayMode em batch o tempo da
// Unity não é confiável. Num dos jogos do teste anterior do pacote, o Time.time quase não andou: 176 quadros =
// 0,34 s em 30 s de relógio real, e um WaitForSeconds(2) não terminou. No projeto vazio (25/11/2026) andou normal
// (3,0 s em 3,0 s reais), mas a ~8.000 quadros por segundo, então lógica contada em quadros corre rápido demais.
// Teste que depende do Time.time fica frágil nos dois sentidos; na build e no Editor com janela o tempo é normal.
//
// Contornos:
//   - Teste que só precisa esperar: WaitForSecondsRealtime ou Time.realtimeSinceStartup, nunca WaitForSeconds.
//   - Lógica do jogo com tempo (cronômetro, ritmo, timeout): leia Relogio.Atual. No teste, troque por um
//     RelogioFalso e avance o tempo à mão (Avancar), ou por um RelogioReal, que segue o relógio do sistema.
//
// Uso no jogo:   _restante -= Relogio.Atual.DeltaTempo;
// Uso no teste:  var r = Relogio.UsarFalso(); r.Avancar(2.5f); yield return null; ... Relogio.Restaurar();
using System.Diagnostics;
using UnityEngine;

namespace Agentes
{
    public interface IRelogio
    {
        /// <summary>Segundos com a escala de tempo (como Time.time).</summary>
        float Tempo { get; }
        /// <summary>Segundos do último quadro (como Time.deltaTime).</summary>
        float DeltaTempo { get; }
        /// <summary>Segundos sem a escala de tempo (a pausa não para): como Time.unscaledTime.</summary>
        float TempoSemEscala { get; }
    }

    /// <summary>O tempo da Unity (padrão). No batch anda devagar demais: ver o cabeçalho.</summary>
    public sealed class RelogioUnity : IRelogio
    {
        public float Tempo => Time.time;
        public float DeltaTempo => Time.deltaTime;
        public float TempoSemEscala => Time.unscaledTime;
    }

    /// <summary>Segue o relógio do sistema. Use no teste-robô em batch quando o jogo precisa andar em tempo real.
    /// DeltaTempo é calculado uma vez por quadro (a primeira leitura do quadro).</summary>
    public sealed class RelogioReal : IRelogio
    {
        readonly Stopwatch _sw = Stopwatch.StartNew();
        int _quadro = -1;
        float _anterior = -1f, _delta;
        /// <summary>Multiplica o tempo (2 = o jogo anda o dobro). Útil para o robô atravessar fases longas.</summary>
        public float Escala = 1f;

        public float Tempo => TempoSemEscala * Escala;
        public float TempoSemEscala => (float)_sw.Elapsed.TotalSeconds;
        public float DeltaTempo
        {
            get
            {
                if (Time.frameCount != _quadro)
                {
                    _quadro = Time.frameCount;
                    var agora = Tempo;
                    _delta = _anterior < 0f ? 0f : agora - _anterior;
                    _anterior = agora;
                }
                return _delta;
            }
        }
    }

    /// <summary>Tempo controlado pelo teste: só anda quando o teste chama Avancar. O delta de um avanço vale no
    /// quadro do pedido e no seguinte, e depois volta a zero.</summary>
    public sealed class RelogioFalso : IRelogio
    {
        float _tempo, _delta;
        int _quadroDoDelta = -10;
        public float Tempo => _tempo;
        public float TempoSemEscala => _tempo;
        public float DeltaTempo => Time.frameCount - _quadroDoDelta <= 1 ? _delta : 0f;

        public void Avancar(float segundos)
        {
            _tempo += segundos;
            _delta = segundos;
            _quadroDoDelta = Time.frameCount;
        }
    }

    public static class Relogio
    {
        static IRelogio _atual;
        public static IRelogio Atual
        {
            get => _atual ??= new RelogioUnity();
            set => _atual = value;
        }

        public static RelogioFalso UsarFalso() { var r = new RelogioFalso(); _atual = r; return r; }
        public static RelogioReal UsarReal() { var r = new RelogioReal(); _atual = r; return r; }
        /// <summary>Volta ao tempo da Unity. Chame no [TearDown] do teste.</summary>
        public static void Restaurar() => _atual = new RelogioUnity();
    }
}
