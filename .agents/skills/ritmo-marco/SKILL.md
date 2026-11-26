---
name: ritmo-marco
description: Fecha uma story de marco (US-M1 ou US-M2) do projeto Ritmo conforme Docs/agentes/marco-jogavel.md. Use quando o usuário pedir para fechar um milestone ou rodar a validação do marco.
---

# Fechar Marco Jogável (Ritmo)

Siga `Docs/agentes/marco-jogavel.md`:

1. Verifique em `Docs/decisoes-provisorias.md` se há alguma lacuna `ABERTA`; liste-as no topo da entrega.
2. Peça ao aluno para rodar toda a suíte (EditMode e PlayMode) no Test Runner e corrija eventuais falhas.
3. Crie ou atualize `Assets/_Project/Tests/PlayMode/RoboJogaTudoTests.cs` abrindo a cena de entrada do Build Settings e percorrendo o fluxo completo do jogador (menu, modos, pausa/volta, configurações, fim de sessão, registro local).
4. Audite todos os requisitos do milestone em `Docs/ABD-1-Lucas.md` classificando em: verificado pelo agente (com nome do teste), corrigido no marco, sem caminho no jogo, ou Parte B (para o aluno conferir no Play).
5. Registre o resultado em `Docs/progresso.md` usando o modelo da seção `Marco <ID> — <título>` de `Docs/agentes/marco-jogavel.md`.
