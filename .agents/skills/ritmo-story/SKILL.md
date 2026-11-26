---
name: ritmo-story
description: Executa o fluxo de uma user story (US-xx) do projeto Ritmo seguindo o AGENTS.md, Docs/ABD-1-Lucas.md e Docs/SGDD-1-Lucas.md. Use quando o usuário pedir para implementar, continuar ou fechar uma story.
---

# Executar Story (Ritmo)

1. Leia `Docs/progresso.md` (se existir) e `Docs/decisoes-provisorias.md` (se existir).
2. Busque o ID `US-xx` em `Docs/ABD-1-Lucas.md` e leia apenas do título até o próximo título de mesmo nível.
3. Leia em `Docs/SGDD-1-Lucas.md` apenas a seção citada pela story.
4. Procure scripts relacionados com `grep` antes de criar novos.
5. Se houver lacuna não decidida no ABD/SGDD, pare essa parte e use a skill `ritmo-lacuna`.
6. Implemente apenas as tasks `[agente]` em `Assets/_Project/Scripts/<Módulo>/` (asmdefs `Ritmo.*`):
   - 1 `MonoBehaviour` ou `ScriptableObject` por arquivo, com o mesmo nome da classe.
   - Campos de Inspector como `[SerializeField] private`.
   - Tempo via `Agentes.Relogio.Atual`, entrada via Input System 1.20 e timestamps musicais via interface sobre `AudioSettings.dspTime`.
   - Nunca crie ou edite `.unity`, `.prefab`, `.asset`, `.mat`, `.controller`, `.anim` ou `.mixer`.
7. Escreva os testes em `Assets/_Project/Tests/` usando a skill `ritmo-testes`.
8. Informe ao aluno quais testes rodar no Test Runner (os da story e os de classes dependentes).
9. Ao fechar, registre em `Docs/progresso.md` (3 a 8 linhas): story, classes mudadas, testes, lacunas, o que o aluno monta/liga no Editor e sugestão de commit `US-xx: <título curto>`.
