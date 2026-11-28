---
name: ritmo-testes
description: Cria testes EditMode e PlayMode em Unity para o projeto Ritmo usando Agentes.Relogio, InputTestFixture e montagem mínima por código. Use ao escrever ou corrigir testes em Assets/_Project/Tests/.
---

# Testes Unity (Ritmo)

Siga `Docs/agentes/testes.md` e a regra 5 do `AGENTS.md`:

1. Coloque testes em `Assets/_Project/Tests/` (`Ritmo.Tests.EditMode`, `Ritmo.Tests.PlayMode`, `Ritmo.Tests.Performance`).
2. Monte o mínimo necessário por código (`new GameObject`, `AddComponent`, `ScriptableObject.CreateInstance`) — não dependa de cenas do aluno (exceto `RoboJogaTudoTests` no marco).
3. Use `Agentes.Relogio.UsarFalso()` para tempo de jogo e avance com `Avancar(segundos)`.
4. Para Input System (1.20), use `InputTestFixture` para simular teclado/mouse/touch.
5. Para agendamento musical (`AudioSettings.dspTime`), injete uma interface falsa de relógio DSP.
6. Sempre restaure no `[TearDown]` com `Relogio.Restaurar()`.
7. Ao finalizar, liste exatamente quais classes/testes o aluno deve rodar no Test Runner do Editor.
