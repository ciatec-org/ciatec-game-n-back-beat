# AGENTS.md — Ritmo (N-Back Beat)

Instruções para qualquer agente de IA (Codex, Claude Code, Gemini CLI, Copilot, Cursor...) que trabalhe neste projeto.

## O projeto

- **Jogo:** Ritmo — jogo sério de memória de trabalho (N-Back) para crianças e jovens no espectro autista: o jogador ouve uma sequência musical marcada por um metrônomo e responde se um estímulo ocorreu *N* passos atrás.
- **Unity:** 6000.5.7f1, URP 17.5, só o Input System (1.20).
- **Design (o quê e o porquê):** `Docs/SGDD-1-Lucas.md`. É grande: leia só a seção que a story citar.
- **Backlog (o que fazer):** `Docs/ABD-1-Lucas.md`. Cada story tem um ID `US-xx` no título (o nível do título muda:
  **busque pelo ID**), critérios de aceite, cenários Dado/Quando/Então e tasks `[agente]` e `[aluno]`.
- **Estado do trabalho:** `Docs/progresso.md` (crie se não existir). Leia antes de começar.
- **Decisões:** `Docs/decisoes-provisorias.md` (crie se não existir).

## Regras

1. **Não invente requisito, não corte nenhum, e não decida lacuna sozinho.** Se a story ou o SGDD não dizem como
   algo funciona (o que aparece na tela, como o jogador sai, avança ou volta, quanto vale um número, o que uma
   animação ou um tutorial mostra), pergunte ao desenvolvedor e espere a resposta antes de fazer essa parte: a story,
   o que falta, 2 ou 3 opções e a sua recomendação, todas as lacunas da story numa pergunta só. Enquanto espera, siga
   com o que não depende dela.
   - Grave a resposta em `Docs/decisoes-provisorias.md` (story, pergunta, resposta, quem respondeu).
   - Sem ninguém para responder, registre a pergunta lá como `ABERTA`, faça o resto e liste as abertas no fim.
   - Só decide sozinho o que o jogador nunca percebe: nome de classe, pasta, estrutura interna do código.
2. **Você só escreve código e testes. Tudo o que se faz no Editor da Unity é do aluno:** cenas, Build Settings, UI,
   HUD e Canvas, prefabs, instâncias de ScriptableObject (`.asset`) e seus valores, materiais, luz, câmera,
   animações, arte, som, mixer, ligar referências no Inspector e gerar builds. Nunca crie nem edite `.unity`,
   `.prefab`, `.asset`, `.mat`, `.controller`, `.anim` ou `.mixer`, nem por texto nem por script de Editor.
   - Seu componente expõe campos `[SerializeField]` com nome claro, e liga listeners de botão no `Awake`. No fim da
     story, escreva em `Docs/progresso.md` o que o aluno monta e liga ("na cena X, ponha `HudDaFase` no Canvas e
     ligue `cronometro` ao `Text` do topo"). As tasks `[aluno]` do ABD já dizem isso; complete o que faltar.
   - Seus testes não dependem da cena do aluno: montam por código o mínimo de que precisam (`new GameObject`,
     `AddComponent`, `ScriptableObject.CreateInstance`). Só o teste-robô do marco abre a cena de entrada.
3. **Código em `Assets/_Project/Scripts/<Módulo>/` (asmdefs `Ritmo.*`, um por módulo), testes em `Assets/_Project/Tests/`
   (`Ritmo.Tests.EditMode`, `Ritmo.Tests.PlayMode` e `Ritmo.Tests.Performance`).** `Assets/Agentes/` é do pacote: use, não mude.
4. **Cada `ScriptableObject` e cada `MonoBehaviour` no próprio arquivo, com o nome da classe** (`ConfigFase` em
   `ConfigFase.cs`); senão o `.asset` ou o componente perde o script.
5. **Entrada e tempo pelas camadas do pacote:** o jogo lê teclado e mouse por `Agentes.Entrada.Atual` e o tempo por
   `Agentes.Relogio.Atual`, nunca `Input.*` ou `Time.time` direto. É o que deixa o teste apertar teclas e avançar o
   tempo (`Docs/agentes/testes.md`). Se o projeto usa o **Input System** novo, a entrada é por ele (não use
   `Agentes.Entrada`, que lê o Input Manager antigo), e o teste simula o dispositivo com o `InputTestFixture`; o
   tempo continua pelo `Agentes.Relogio`. **Neste jogo** os *timestamps* da música são agendados por
   `AudioSettings.dspTime`, lido por uma interface que o teste troca por um relógio falso (seção 3 do ABD).
6. **Uma story por vez**, pelos passos de "Como fazer uma story" abaixo.
7. **Você escreve os testes; o aluno os roda** no Test Runner, com o Editor aberto, e te passa as falhas. Diga a
   ele quais rodar: os da story e os de quem usa o que ela mudou (`rg NomeDaClasse Assets/`). No marco, todos.
8. **Mudou o valor padrão de um campo serializado? Avise o aluno em `Docs/progresso.md`:** a cena e o prefab
   guardam o valor antigo, e quem corrige é ele, no Inspector.
9. **Erro de compilação ou teste que falha duas vezes na mesma correção:** pare, registre o problema em
   `Docs/decisoes-provisorias.md` e siga para o que não depende dele.

## Padrões de código

- **O padrão que o repositório já tem vence este:** pastas, asmdef, nomes e guias do projeto (ex.: um
  `EditingGuide.md`). Onde a pasta ou o asmdef dele difere da regra 3, vale o dele.
- C#: classes, métodos e propriedades em `PascalCase`; campos e variáveis em `camelCase`; um namespace do jogo.
- Campo do Inspector é `[SerializeField] private`, não `public`.
- Valor de design (tempo, velocidade, limite, quantidade) fica num ScriptableObject de configuração, não espalhado
  no código.
- Sistemas conversam por evento (`event`, `UnityEvent`) ou referência ligada no Inspector; nada de `Find*` nem de
  singleton para tudo.
- Nada de `Find*`, `GetComponent` ou alocação (`new`, LINQ, concatenação de string) dentro do `Update`.
- Classe pequena, com uma responsabilidade. Antes de criar um sistema, procure (`rg`) se já existe um que faz isso.
- Comentário só onde explica o porquê. Sem código morto nem `Debug.Log` esquecido.

## Como fazer uma story

1. **Ler só o necessário:** `Docs/progresso.md`; no ABD, a story pelo ID (`rg -n "US-xx" Docs/ABD-1-Lucas.md`), do título
   até o próximo título de mesmo nível; só a seção do SGDD que ela citar; os scripts que vai mudar (ache por `rg`).
   Lacuna → pergunte antes (regra 1). Decisão que o ABD já traz não é lacuna.
2. **Fazer:** só as tasks `[agente]`. Código em `Assets/Scripts/`, testes em `Assets/Tests/`, um por critério de
   aceite que dê para testar por código (o visual, pelo estado: tela ativa, texto, objeto visível). Critério que só
   se vê jogando fica para o marco.
3. **Conferir:** peça ao aluno para rodar no Test Runner os testes da story e os de quem usa o que ela mudou (diga
   as classes) e te passar as falhas e os erros do Console. Corrija até passarem.
4. **Fechar:** confira os critérios um a um (`[x]` e o teste, ou `[ ]` e o motivo). Registre em `Docs/progresso.md`,
   em 3 a 8 linhas: story, classes mudadas, testes, lacunas (respondidas ou `ABERTA`), **o que o aluno monta e liga
   no Editor** (cena, objeto, componente, campo → referência) e o que fica para o marco. O commit é do aluno; sugira
   a mensagem `US-xx: <título curto>`.

Não edite o SGDD nem o ABD.

## Quando precisar

- `Docs/agentes/testes.md` — como escrever os testes (asmdef, tempo e entrada falsos)
- `Docs/agentes/marco-jogavel.md` — como fechar a story de marco
