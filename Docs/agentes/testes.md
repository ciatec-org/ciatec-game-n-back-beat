# Testes

O aluno roda os testes com o Editor aberto, em **Window > General > Test Runner** (abas EditMode e PlayMode), e
cola para o agente as falhas com a mensagem. O agente escreve os testes e diz ao aluno quais rodar (os da story e os
de quem usa o que ela mudou; no marco, todos).

## asmdef

O projeto precisa do pacote `com.unity.test-framework` (Package Manager). Um asmdef de teste só enxerga código que
está num asmdef: se o código do jogo ainda está solto no `Assembly-CSharp` (sem asmdef), a primeira task é criar o
asmdef do jogo na pasta de scripts dele, referenciando os pacotes que ele usa (Input System, TextMeshPro, UI). Use o
nome e a pasta que o repositório já tem; os exemplos abaixo chamam o asmdef do jogo de `Jogo`. Com o Input System,
o `InputTestFixture` exige `"testables": ["com.unity.inputsystem"]` no `Packages/manifest.json`.

```json
// Assets/Scripts/Jogo.asmdef
{ "name": "Jogo", "references": ["UnityEngine.UI", "Agentes.Runtime"], "autoReferenced": true }
// Assets/Tests/EditMode/Jogo.Tests.EditMode.asmdef
{ "name": "Jogo.Tests.EditMode", "references": ["Jogo", "Agentes.Runtime", "UnityEngine.UI",
  "UnityEngine.TestRunner", "UnityEditor.TestRunner"],
  "includePlatforms": ["Editor"], "overrideReferences": true, "precompiledReferences": ["nunit.framework.dll"],
  "defineConstraints": ["UNITY_INCLUDE_TESTS"] }
// Assets/Tests/PlayMode/Jogo.Tests.PlayMode.asmdef
{ "name": "Jogo.Tests.PlayMode", "references": ["Jogo", "Agentes.Runtime", "UnityEngine.UI",
  "UnityEngine.TestRunner"], "includePlatforms": [],
  "overrideReferences": true, "precompiledReferences": ["nunit.framework.dll"], "defineConstraints": ["UNITY_INCLUDE_TESTS"] }
```

## Tempo e entrada em PlayMode

- **Tempo:** a lógica do jogo com tempo (cronômetro, ritmo, timeout) lê `Agentes.Relogio.Atual` (`.Tempo`,
  `.DeltaTempo`). O teste troca por `Relogio.UsarFalso()` e avança à mão (`Avancar(2.5f)`), ou por
  `Relogio.UsarReal()` (com `Escala` para acelerar) quando o robô precisa do tempo correndo. Para o teste esperar,
  `WaitForSecondsRealtime`.
- **Entrada:** o jogo lê `Agentes.Entrada.Atual` (`Apertou`, `Segurando`, `Soltou`, `Eixo`, `CliqueDesceu`,
  `PosicaoMouse`); o teste usa `Entrada.UsarFalsa()` e chama `Tocar(KeyCode.Space)`, `Apertar`/`Soltar`,
  `DefinirEixo("Horizontal", 1)`, `Clicar()`. Botão da UI se aperta por `botao.onClick.Invoke()`; slider, por
  `slider.value = x`.
- No `[TearDown]`, `Entrada.Restaurar()` e `Relogio.Restaurar()`.

```csharp
using System.Collections;
using Agentes;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class ControleTests
{
    [TearDown] public void Limpar() { Entrada.Restaurar(); Relogio.Restaurar(); }

    [UnityTest]
    public IEnumerator EspacoPulaECronometroAnda()
    {
        var entrada = Entrada.UsarFalsa();
        var relogio = Relogio.UsarFalso();
        var jogador = new GameObject("Jogador").AddComponent<Jogo.Jogador>();
        var cronometro = new GameObject("Cronometro").AddComponent<Jogo.Cronometro>();
        yield return null;

        entrada.Tocar(KeyCode.Space);
        yield return null;
        Assert.IsTrue(jogador.Pulando);

        relogio.Avancar(10f);
        yield return null;
        Assert.AreEqual(50f, cronometro.Restante, 0.01f);
    }
}
```
