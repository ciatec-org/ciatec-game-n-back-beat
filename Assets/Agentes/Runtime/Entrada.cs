// Camada de entrada injetável. O jogo lê teclado e mouse por Entrada.Atual em vez de chamar UnityEngine.Input
// direto; o teste troca Entrada.Atual por uma EntradaFalsa e "aperta" teclas por código.
//
// Por que existe: num teste automático ninguém aperta o teclado, então Input.GetKeyDown nunca fica verdadeiro e
// não há como testar o controle do jogador. Com esta camada, o teste diz o que foi apertado e confere o efeito.
//
// Uso no jogo:   if (Entrada.Atual.Apertou(KeyCode.Space)) Pular();
// Uso no teste:  var e = Entrada.UsarFalsa(); e.Tocar(KeyCode.Space); yield return null; ... Entrada.Restaurar();
using System.Collections.Generic;
using UnityEngine;

namespace Agentes
{
    public interface IEntrada
    {
        /// <summary>A tecla desceu neste quadro (equivale a Input.GetKeyDown).</summary>
        bool Apertou(KeyCode tecla);
        /// <summary>A tecla está segurada (Input.GetKey).</summary>
        bool Segurando(KeyCode tecla);
        /// <summary>A tecla subiu neste quadro (Input.GetKeyUp).</summary>
        bool Soltou(KeyCode tecla);
        /// <summary>Eixo do Input Manager antigo ("Horizontal", "Vertical"), de -1 a 1.</summary>
        float Eixo(string nome);
        Vector2 PosicaoMouse { get; }
        bool CliqueDesceu(int botao);
    }

    /// <summary>A entrada de verdade: repassa ao Input Manager antigo (o padrão de um projeto novo).</summary>
    public sealed class EntradaUnity : IEntrada
    {
        public bool Apertou(KeyCode tecla) => Input.GetKeyDown(tecla);
        public bool Segurando(KeyCode tecla) => Input.GetKey(tecla);
        public bool Soltou(KeyCode tecla) => Input.GetKeyUp(tecla);
        public float Eixo(string nome) => Input.GetAxisRaw(nome);
        public Vector2 PosicaoMouse => Input.mousePosition;
        public bool CliqueDesceu(int botao) => Input.GetMouseButtonDown(botao);
    }

    /// <summary>Entrada controlada pelo teste. Um evento (Apertar, Tocar, Soltar, Clicar) vale no quadro do pedido e
    /// no seguinte, porque o teste costuma pedir e depois dar "yield return null". Segurar vale até Soltar.</summary>
    public sealed class EntradaFalsa : IEntrada
    {
        readonly HashSet<KeyCode> _segurando = new HashSet<KeyCode>();
        readonly Dictionary<KeyCode, int> _apertou = new Dictionary<KeyCode, int>();
        readonly Dictionary<KeyCode, int> _soltou = new Dictionary<KeyCode, int>();
        readonly Dictionary<string, float> _eixos = new Dictionary<string, float>();
        readonly Dictionary<int, int> _clique = new Dictionary<int, int>();

        public Vector2 PosicaoMouse { get; set; }

        static bool Vale<T>(Dictionary<T, int> d, T k) => d.TryGetValue(k, out var q) && Time.frameCount - q <= 1;

        /// <summary>Desce a tecla e a mantém segurada até Soltar.</summary>
        public void Apertar(KeyCode tecla) { _apertou[tecla] = Time.frameCount; _segurando.Add(tecla); _soltou.Remove(tecla); }
        public void Soltar(KeyCode tecla) { _segurando.Remove(tecla); _soltou[tecla] = Time.frameCount; }
        /// <summary>Aperta e solta: o jogo vê Apertou uma vez e a tecla não fica presa.</summary>
        public void Tocar(KeyCode tecla) { _apertou[tecla] = Time.frameCount; _soltou[tecla] = Time.frameCount; }
        public void DefinirEixo(string nome, float valor) => _eixos[nome] = Mathf.Clamp(valor, -1f, 1f);
        public void Clicar(int botao = 0) => _clique[botao] = Time.frameCount;

        public bool Apertou(KeyCode tecla) => Vale(_apertou, tecla);
        public bool Segurando(KeyCode tecla) => _segurando.Contains(tecla) || Vale(_apertou, tecla);
        public bool Soltou(KeyCode tecla) => Vale(_soltou, tecla);
        public float Eixo(string nome) => _eixos.TryGetValue(nome, out var v) ? v : 0f;
        public bool CliqueDesceu(int botao) => Vale(_clique, botao);
    }

    public static class Entrada
    {
        static IEntrada _atual;
        public static IEntrada Atual
        {
            get => _atual ??= new EntradaUnity();
            set => _atual = value;
        }

        public static EntradaFalsa UsarFalsa()
        {
            var falsa = new EntradaFalsa();
            _atual = falsa;
            return falsa;
        }

        /// <summary>Volta à entrada de verdade. Chame no [TearDown] do teste.</summary>
        public static void Restaurar() => _atual = new EntradaUnity();
    }
}
