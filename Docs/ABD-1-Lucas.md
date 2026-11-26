---
faixa: CIATec
doc: Plano de trabalho
doc_extenso: Agile Backlog Document
titulo: Ritmo (N-Back Beat)
subtitulo: Plano de trabalho do jogo de iniciação científica do Lucas
versao: v2.0
mudanca: reescrito no molde do Caça às Cores; a subida do N entra no Core, como no protótipo (decisão do orientador, 26/11/2026); cada épico pertence a um milestone só
data: 26/11/2026
projeto_vinculado: ATGCP — Adaptive Therapeutic Game Calibration Protocol
organizacao: CIATec
triple_diamond:
ppi:
pesquisador: Lucas (IC)
tipo: backlog
status: rascunho — milestones Core e Expansão, sem data; a conexão com a API fica em ABD-1-Lucas-api.md
data_criacao: 25/11/2026
data_atualizacao: 26/11/2026
---

**Histórico.**

- **v2.0 (26/11/2026): reescrito no molde do Caça às Cores (26/11/2026)**, por decisão do orientador ("Sim, no molde do Caça"). Uma história por coisa que a criança ou o mediador faz, e não por requisito; uma task por pedaço de trabalho, de 1 ou 2 h, sem o par `[agente]`/`[aluno]`; o teste dentro da task que escreve a regra; a burocracia fora (seção 6). O escopo é o da v1.2, sem corte. Duas decisões do orientador de 26/11/2026 entram aqui: **o N sobe dentro do jogo no Core, como no protótipo** ("Sobem, como no protótipo"; US-02.5), e **cada épico pertence a um milestone só** (os épicos Core vêm antes dos da Expansão). A v1.2 tinha 9 épicos, 52 histórias, 206 tasks e 213 h (73 tasks sem horas); a v2.0 tem 9 épicos, 25 histórias, 82 tasks e 149 h. O mapa de cada história e task da v1.2 para a v2.0 está na seção 9 (histórias) e em `mapa-molde-caca.md` (tasks), fora do repositório.
- v1.2 (26/11/2026): correção do orientador ao corte de protótipo: a mecânica fica no Core, e os tutoriais saem dele ("pode ficar só o jogo direto sem precisar de tutorial").
- v1.1 (26/11/2026): corte de protótipo: o Core é o jogo jogável de ponta a ponta, com a telemetria local; o resto foi para a Expansão; a burocracia saiu.
- v1.0 (26/11/2026): a adaptação de dificuldade foi para o backend (padrão CIATEC); o dispositivo-alvo é o PC (Windows, mouse e teclado); a ética, o relatório e a exportação saíram do jogo.
- v0.5 a v0.9 (25 e 26/11/2026): as decisões do orientador sobre as lacunas (LA-01 a LA-09) e o playtest do protótipo web (tutorial jogável, o N à vista, a fase em blocos, o placar).

# 1 COMO USAR ESTE PLANO

## 1.1 Para quem é

**Este plano é do Lucas, que constrói o Ritmo na iniciação científica, com o agente de IA dele.** Ele diz o que construir, em que ordem, e em pedaços pequenos o bastante para caber numa sessão de trabalho. O que o jogo é, e por quê, está no SGDD (`SGDD-1-Lucas.md`): este plano não decide nada sobre o jogo, só organiza o trabalho de construí-lo. **Toda dúvida sobre como algo deve acontecer se responde no SGDD**; se ele não responde, a dúvida vai ao orientador, e a resposta volta ao SGDD. A referência do que é mecânica é o protótipo web (`prototipos-web/nback/`), que o orientador jogou e validou.

**A tecnologia é Unity para o PC** (§2.2 e §7.4 do SGDD): Unity 6000.5.7f1 com URP, o Input System, a interface em uGUI e o Test Framework (EditMode e PlayMode). O código mora em `Assets/_Project/`, com as asmdefs `Ritmo.*`. A build é só Windows, jogada com mouse e teclado.

**A task diz o que fazer, e não quem faz.** O código C# e os testes podem sair do agente; o que se faz no Editor da Unity (cenas, prefabs, assets e os valores dos campos, as ligações no Inspector, as builds) e rodar os testes no Test Runner, com o Editor aberto, é do Lucas. Por isso "e ligar na cena" está dentro da mesma task do código.

## 1.2 O ritmo

**Sem sprints nem datas** (decisão do orientador, 26/11/2026). O plano tem dois milestones, feitos nessa ordem: **Core**, o jogo jogável de ponta a ponta, com a telemetria salva no PC; e **Expansão**, o mediador, os perfis, o treino, o tutorial, a avaliação, a interface de parâmetros para o backend, a música a mais, o professor e as preferências. Cada épico pertence a um milestone só, e os épicos seguem a ordem dos milestones. A ordem das histórias dentro de cada milestone está na seção 5.

## 1.3 O caminho de uma task

**Uma task por vez, de 1 ou 2 h: uma sessão de trabalho.** Ela fecha quando o que pede funciona no Play do Editor e, se escreve uma regra, o teste dela está verde no Test Runner. **Uma task parada por uma semana é hora de pedir ajuda**, e não de esperar a reunião.

## 1.4 Pronta para começar, e pronta de verdade

**Uma história está pronta para começar** quando as seções do SGDD que ela cita foram lidas, as dependências dela estão feitas, e não há dúvida aberta sobre o que ela pede.

**Uma história está feita** quando:

- cada cenário de aceite dela foi visto acontecer, jogando no Play do Editor ou na build Windows;
- os testes das tasks dela estão verdes no Test Runner;
- o Console não mostra nenhuma exceção durante uma partida jogada.

## 1.5 Os testes

**Teste só onde há regra, dentro da task que escreve a regra.** As regras (o gerador, o julgamento, as tentativas, a partida, a carga, a trava, o aplicador de parâmetros) moram em classes C# puras, separadas da cena, com teste EditMode; o tempo do áudio é lido por uma interface de relógio que o teste troca por um relógio falso. Não há task só de teste, nem teste-robô que joga o jogo: o jogo se prova jogado, nas histórias de marco.

## 1.6 Como ler uma história

Cada história traz o perfil, as horas, a prioridade e o milestone; a história no formato *Como… quero… para que…*; **a lista dos requisitos do SGDD que ela realiza, um por linha** — os `RT-xx` são as linhas da §12, na ordem da tabela, e os outros vêm pela seção, com o texto do SGDD; os cenários de aceite; e as tasks, de 1 ou 2 h cada, com a camada (gameplay, presentation, dados, conteúdo, arte, telemetria, docs, build, validação).

> **As histórias de marco** (uma por milestone) só fecham com a build Windows jogada do menu à tela final e com o arquivo de telemetria da partida conferido contra o que foi jogado — nunca com uma parte jogada no Editor. São a única prova de que as peças foram juntadas.

# 2 CAPACIDADE E PREVISÃO

**O plano tem 9 épicos, 25 histórias e 82 tasks, somando 149 horas: o Core tem 14 histórias, 44 tasks e 79 h; a Expansão, 11 histórias, 38 tasks e 70 h.** O plano conta em horas, e não em pontos. Não há projeção em semanas (decisão do orientador, 26/11/2026): depois das primeiras histórias, o Lucas soma as horas das tasks que fechou por semana e refaz a previsão com esse número.

| Épico | Milestone | Histórias | Tasks | Horas |
| --- | --- | --- | --- | --- |
| EP-01 · Fundação do projeto Unity | Core | 2 | 5 | 9 h |
| EP-02 · A fase | Core | 5 | 15 | 28 h |
| EP-03 · A tela de jogo e a música | Core | 3 | 12 | 21 h |
| EP-04 · Menus e conforto | Core | 2 | 6 | 10 h |
| EP-05 · Registro da partida e marco Core | Core | 2 | 6 | 11 h |
| EP-06 · O painel do mediador | Expansão | 3 | 11 | 21 h |
| EP-07 · Treino, tutorial e avaliação | Expansão | 3 | 9 | 16 h |
| EP-08 · Parâmetros por interface | Expansão | 1 | 3 | 6 h |
| EP-09 · Música, professor e preferências | Expansão | 4 | 15 | 27 h |

| Milestone | O que se vê | Histórias | Tasks | Horas |
| --- | --- | --- | --- | --- |
| Core | A build Windows abre na tela inicial; a criança escolhe o som e joga 6 fases, com acerto, erro, reescuta, subida de N, [Mais fácil], pausa e volume; o arquivo da partida fica no PC | 14 | 44 | 79 h |
| Expansão | O painel do mediador, os perfis, o treino, o tutorial, a avaliação, a interface de parâmetros, mais músicas e ruídos, a música inteira, o professor e as preferências | 11 | 38 | 70 h |
| **Total** | | **25** | **82** | **149 h** |

**A meta do molde era de 20 a 25 histórias e de 50 a 70 tasks.** As histórias couberam (25); as tasks não (82). O escopo decidido pelo orientador, sem corte, soma 149 h: o Core com a mecânica inteira, a música e a subida de N, e a Expansão com o mediador, os perfis, o treino, o tutorial, a avaliação, a interface de parâmetros, o catálogo, o professor e as preferências. Com tasks de 1 a 2 h, isso não cabe em 70 sem cortar escopo, o que só o orientador decide (seção 8.3).

**Riscos.** O tempo do áudio na build (a precisão do `AudioSettings.dspTime` e das versões esticadas da música) só se vê na build Windows: a T-01.2.1 abre a build cedo, e o marco a joga. A primeira vez com o projeto pesa nas horas: elas supõem quem já montou o esqueleto em Unity e C#.

# 3 ÉPICOS

Cada épico está inteiro na seção 4: a descrição, por que importa, quando está pronto, e as histórias e tasks dele. **Cada épico pertence a um milestone só**, e os épicos seguem a ordem dos milestones.

| Épico | Milestone | Domínio | Depende de |
| --- | --- | --- | --- |
| EP-01 · Fundação do projeto Unity | Core | Setup | — |
| EP-02 · A fase | Core | Gameplay | EP-01 |
| EP-03 · A tela de jogo e a música | Core | Interface | EP-02 |
| EP-04 · Menus e conforto | Core | Interface | EP-02 |
| EP-05 · Registro da partida e marco Core | Core | Dados | EP-02, EP-03, EP-04 |
| EP-06 · O painel do mediador | Expansão | Mediador | EP-05 |
| EP-07 · Treino, tutorial e avaliação | Expansão | Onboarding | EP-06 |
| EP-08 · Parâmetros por interface | Expansão | Adaptação | EP-06, EP-07 |
| EP-09 · Música, professor e preferências | Expansão | Interface | EP-06, EP-07, EP-08 |

# 4 ÉPICOS, HISTÓRIAS E TASKS

As histórias estão na ordem em que se fazem. As tasks de cada uma também: as de cima vêm primeiro.

## 4.1 EP-01 — Fundação do projeto Unity

As cinco cenas, os valores da fase num asset, os ícones do jogo e a build para o PC. Nenhuma regra do jogo sai daqui, e é o épico que deixa o resto andar. **Milestone: Core.**

**Por que importa:** Sem as cenas ligadas e sem a build, nada do que vem depois se joga no PC.

**Pronto quando:**

- A build Windows abre na tela inicial, gerada pelo item de menu;
- Os valores da fase estão num asset, e nenhum número da fase fica no código.

## 4.1.1 US-01.1 — O jogo abre na tela inicial, com os valores da fase num lugar só

**Perfil:** Time · **Horas:** 6 · **Prioridade:** P1 · **Milestone:** Core · **Depende de:** —

*Como time, quero as cinco cenas ligadas, os ícones do jogo e os valores da fase num asset, para que a build abra no jogo e nenhum número da fase fique escondido no código.*

**Requisitos do SGDD que ela realiza:**

- `RT-02` — Fundo de tela branco/neutro como padrão inicial
- `§10.3` — Tela Inicial/Perfil ... Modo Treino (Onboarding) ... Tela de Jogo ... Tela de Sessão Finalizada (as quatro telas do fluxo, itens 1 a 4)
- `§11.1` — Tamanho da fase | faixa: 4 a 12 blocos (padrão 6)
- `§5.2` — Velocidade (BPM): Alteração no andamento da música ou ritmo do metrônomo, podendo variar de 60 BPM até 120 BPM.
- `§11.3` — Suporte 1 (S1): Entrada no N-Back = 1, a 60 BPM, fase de 6 blocos.
- `§4.3` — Inicialmente, ele será definido com a quantidade de 3 tentativas.
- `§10.2 Linguístico` — Interface com mínimo de texto; foco em ícones universais (ex: play, pause, volume, recarregar).

**Cenários de aceite:**

- Dado a build, quando o jogo abre, então o Bootstrap abre a tela inicial, sem passo manual.
- Dado as cinco cenas, quando o time as abre, então o fundo de cada uma é branco ou neutro, sem animação.
- Dado alguém digita BPM 150 no asset, quando o asset é validado, então o BPM fica em 120, e o teste EditMode confere o limite.

| Task | O que fazer | Horas e camada |
| --- | --- | --- |
| T-01.1.1 | Criar as cinco cenas em `Assets/_Project/Scenes/` (`00_Bootstrap`, `01_Profile`, `02_Training`, `03_Gameplay`, `04_SessionEnd`), com fundo branco ou neutro e sem animação; escrever as constantes `SceneNames` e o `BootstrapLoader` em `Ritmo.Core`; registrar as cinco no Build Profiles, nessa ordem e sem a `SampleScene`, e ligar o Bootstrap | 2 h · build |
| T-01.1.2 | Escrever o ScriptableObject `PhaseSettings` (N, blocos por fase, tentativas, BPM, sondas, estímulos distintos e tempo de resposta), com as faixas da §11.1 e da §5.2 no `OnValidate`, que leva o valor de fora ao limite, e teste EditMode; criar o asset com os valores de entrada do S1 (N=1, 6 blocos, 3 tentativas, 60 BPM, 3 sondas, 5 distintos, 10 s) | 2 h · dados |
| T-01.1.3 | Desenhar ou escolher os ícones universais do jogo (play, pausa, volume, silenciar, recarregar, voltar ao início, porta, pasta e a escada do [Mais fácil]) e importá-los | 2 h · arte |

## 4.1.2 US-01.2 — A build para o PC

**Perfil:** Time · **Horas:** 3 · **Prioridade:** P2 · **Milestone:** Core · **Depende de:** US-01.1

*Como time, quero gerar a build Windows por um item de menu, para que o jogo se jogue no PC, com mouse e teclado.*

**Requisitos do SGDD que ela realiza:**

- `§2.2` — o dispositivo-alvo é o PC, Windows, com mouse e teclado; web, mobile e Linux ficam fora desta versão; a build é só Windows.
- `§7.4` — Motor de Jogo: Unity (C#) para renderização visual e gestão de interface de utilizador.

**Cenários de aceite:**

- Dado o projeto aberto, quando o Lucas roda o item de menu, então a build Windows sai numa pasta fora do repositório, sem erro.
- Dado a build, quando ela abre no PC, então mostra o nome e o ícone do jogo e chega à tela inicial.

| Task | O que fazer | Horas e camada |
| --- | --- | --- |
| T-01.2.1 | Configurar a build Windows no Build Profiles (nome e ícone no Player Settings), gerar a build e abri-la no PC | 2 h · build |
| T-01.2.2 | Escrever o item de menu do Editor (em `Ritmo.Editor`) que gera a build Windows numa pasta fora do repositório | 1 h · build |

## 4.2 EP-02 — A fase

O coração do jogo: os sons no compasso, a pausa, o som novo, o Sim ou Não, as tentativas, a reescuta, a passagem de fase, a subida do N e o [Mais fácil]. **Milestone: Core.**

**Por que importa:** É a tarefa N-Back que o estudo observa. Tudo o que vem depois mostra, mede ou enfeita esta fase.

**Pronto quando:**

- Uma partida de 6 fases se joga do ▶ à tela final, com acerto, erro, reescuta, subida de N e [Mais fácil];
- As regras (julgamento, tentativas, partida, carga) estão em C# puro, com teste EditMode.

## 4.2.1 US-02.1 — Ouvir os sons no compasso

**Perfil:** Criança · **Horas:** 7 · **Prioridade:** P1 · **Milestone:** Core · **Depende de:** US-01.1

*Como criança, quero ouvir os sons da fase um a cada batida, para que eu acompanhe a sequência e consiga lembrar dela.*

**Requisitos do SGDD que ela realiza:**

- `§2` — haverá estímulos sonoros sequenciais enumerados, que poderão ser musicais ou não, divididos em timestamps delimitados por metrônomo.
- `§5.2` — Tamanho da fase: número de blocos sonoros antes da pausa, com 6 blocos de base (faixa 4 a 12, ajuste do mediador) ... A duração em segundos sai do tamanho e do BPM (6 blocos a 60 BPM = 6 s).
- `§5.1` — A progressão de dificuldade se dá pelo aumento do número "N" de passos atrás que devem ser lembrados, ou pela complexidade/velocidade do timestamp musical.

**Cenários de aceite:**

- Dado uma fase de 6 blocos a 60 BPM, quando ela toca, então 6 sons tocam, um por segundo, e a fase para em 6 s.
- Dado a mesma semente, quando o gerador roda duas vezes, então a sequência é a mesma.
- Dado 200 sondas geradas, quando o teste as conta, então as que pedem Sim ficam em 50% ± 10 pontos, e metade das outras é distrator.

| Task | O que fazer | Horas e camada |
| --- | --- | --- |
| T-02.1.1 | Fazer no projeto os 5 sons não musicais (gota, tambor, toc, chocalho e assobio), importá-los, escrever o ScriptableObject `StimulusBank` (id → `AudioClip`) e criar o asset com os cinco | 2 h · conteúdo |
| T-02.1.2 | Escrever o gerador da sequência em C# puro: sorteio por partida com semente; entre 3 e 5 estímulos distintos, pelo asset; 50% de sondas que pedem Sim, e metade das outras como distrator (o som de outra distância); teste EditMode (toda sonda tem gabarito em N=1, 2 e 3; 200 sondas em 50% ± 10; a mesma semente dá a mesma sequência) | 2 h · gameplay |
| T-02.1.3 | Escrever o agendador dos *timestamps* por `AudioSettings.dspTime`, a 60/BPM s, atrás de uma interface de relógio que o teste troca por um relógio falso; a fase toca o número de blocos do asset e para; teste EditMode | 2 h · gameplay |
| T-02.1.4 | Escrever o `StimulusPlayer`, que toca o som do banco em cada *timestamp*, agendado no `dspTime`, e ligá-lo na `03_Gameplay` com um `AudioSource` | 1 h · presentation |

## 4.2.2 US-02.2 — Ouvir o som novo e responder Sim ou Não

**Perfil:** Criança · **Horas:** 8 · **Prioridade:** P1 · **Milestone:** Core · **Depende de:** US-02.1

*Como criança, quero ouvir o som novo no fim da fase e clicar em Sim ou Não, para que eu exercite lembrar o que tocou N passos atrás.*

**Requisitos do SGDD que ela realiza:**

- `§4.1` — Quando o tempo pré-estabelecido para exibição de som terminar, o jogador será exposto a um estímulo a mais. Ele deve selecionar corretamente entre sim ou não para indicar se aquele foi o estímulo que ocorreu N-Passos atrás.
- `§4.3` — Para cada fase, teremos três questionamentos (o mediador ajusta de 1 a 5).
- `§10.1` — As opções de resposta devem aparecer de maneira expressiva na tela, com tamanho padronizado e grande, e com colorações distintas, facilitando reconhecimento;
- `§10.1` — Um breve escurecimento no plano de fundo será utilizado para evitar distrações.
- `§10.3` — painel de resposta que surge apenas durante as pausas de questionamento.
- `§10.2 Motor` — Tempo de resposta: 10 s por pergunta, numa barra que encolhe acima do Sim/Não; o mediador ajusta de 5 a 20 s. No tutorial e em S3 não há limite. Tempo esgotado: o som novo toca de novo e o tempo recomeça, sem gastar tentativa, sem alarme nem som de erro.

**Cenários de aceite:**

- Dado a sequência E A D G C A da §4.1 e N=3, quando a sonda é G e a criança clica em Sim, então o jogo marca acerto; com a sonda D e Sim, erro.
- Dado o fim da fase, quando a pausa começa, então o fundo escurece 35% em 0,25 s e o painel Sim/Não aparece, igual no acerto e no erro.
- Dado uma pergunta aberta, quando passam 10 s sem resposta, então a sonda toca de novo e o tempo recomeça, sem gastar tentativa e sem alarme.

| Task | O que fazer | Horas e camada |
| --- | --- | --- |
| T-02.2.1 | Escrever a regra do julgamento em C# puro: a sonda k ocupa o *timestamp* fim + k e é julgada contra o de N antes dela; teste EditMode com a sequência da §4.1 em N=3 (G pede Sim, D pede Não), com N=1 (a segunda sonda contra a primeira) e com menos sons tocados que N (recusa) | 2 h · gameplay |
| T-02.2.2 | Montar o painel Sim/Não (`AnswerPanel`) na `03_Gameplay`: dois botões grandes, de cores distintas, com ícones e ≥ 48×48 dp, visíveis só na pausa, e uma camada escura de 35% em 0,25 s atrás deles | 2 h · presentation |
| T-02.2.3 | Escrever o `PhaseController`: no fim da fase, pausa, toca as sondas do asset (3), abre o painel e julga cada clique; ligá-lo na cena com o asset, o `StimulusPlayer` e o painel | 2 h · presentation |
| T-02.2.4 | Escrever o tempo da pergunta em C# puro (10 s pelo asset, faixa 5 a 20; esgotado, a sonda toca de novo e o tempo recomeça, sem gastar tentativa), com teste EditMode, e a barra (`AnswerTimerBar`, uma `Image` Filled em cor neutra acima do Sim/Não) que esvazia sem alarme nem troca de cor | 2 h · gameplay |

## 4.2.3 US-02.3 — Errar, perder uma tentativa e ouvir de novo

**Perfil:** Criança · **Horas:** 3 · **Prioridade:** P1 · **Milestone:** Core · **Depende de:** US-02.2

*Como criança, quero ouvir a fase de novo quando erro demais, para que eu tente outra vez sem castigo.*

**Requisitos do SGDD que ela realiza:**

- `§4.3` — Errar faz com que seja decrementado um contador de tentativas restantes. Inicialmente, ele será definido com a quantidade de 3 tentativas.
- `§4.3` — Caso o contador zere, o conjunto de timestamps atual é escutado novamente, o contador volta cheio e as perguntas recomeçam. O padrão de estímulos será idêntico.
- `§5.1` — Caso o contador de tentativas zere na fase, o jogo não emite telas punitivas; em vez disso, o usuário escuta o conjunto de timestamps novamente para consolidar o aprendizado.

**Cenários de aceite:**

- Dado o contador em 3, quando a criança erra, então ele vai a 2, sem som nem tela de erro.
- Dado o contador em 1, quando ela erra, então a mesma sequência toca de novo, o contador volta a 3 e as perguntas recomeçam.

| Task | O que fazer | Horas e camada |
| --- | --- | --- |
| T-02.3.1 | Escrever o contador de tentativas em C# puro (começa no valor do asset, cada erro tira 1, zerado pede a reescuta), com teste EditMode | 1 h · gameplay |
| T-02.3.2 | Ligar a reescuta no `PhaseController`: com o contador zerado, a mesma sequência toca de novo, o contador volta cheio e as sondas recomeçam, sem tela punitiva | 2 h · gameplay |

## 4.2.4 US-02.4 — Passar de fase e chegar ao fim da partida

**Perfil:** Criança · **Horas:** 4 · **Prioridade:** P1 · **Milestone:** Core · **Depende de:** US-02.3

*Como criança, quero passar de fase e, no fim, ver quantas vezes acertei, para que eu sinta que avancei.*

**Requisitos do SGDD que ela realiza:**

- `§4.3` — A fase avança quando as perguntas dela acabam sem que o contador de tentativas restantes tenha zerado.
- `§4.3` — A partida tem 6 fases com sons ou ruídos; com música, ela acaba quando a música acaba.
- `§4.2` — O erro resultará apenas na ausência da recompensa visual e na não progressão da fase.
- `§10.3` — Tela de Sessão Finalizada: Pontuação destacando apenas acertos (o botão da música completa é a US-09.1, na Expansão)

**Cenários de aceite:**

- Dado as sondas respondidas com o contador acima de zero, quando a última fecha, então a fase seguinte começa sozinha.
- Dado a sexta fase, com sons, quando ela termina, então abre a tela final com os acertos da partida, sem contagem de erro.

| Task | O que fazer | Horas e camada |
| --- | --- | --- |
| T-02.4.1 | Escrever a regra da partida em C# puro: a fase avança quando as sondas acabam com o contador acima de zero; a partida fecha em 6 fases com sons, ou quando a música acaba; teste EditMode das transições | 2 h · gameplay |
| T-02.4.2 | Ligar a regra na cena: a fase seguinte abre sozinha, e o fim da partida abre a `04_SessionEnd`, onde o `SessionEndView` mostra os acertos acumulados, em número grande e sem contagem de erro | 2 h · presentation |

## 4.2.5 US-02.5 — O N sobe quando acerto tudo, e desce quando peço

**Perfil:** Criança · **Horas:** 6 · **Prioridade:** P1 · **Milestone:** Core · **Depende de:** US-02.4

*Como criança, quero que o desafio suba quando acerto tudo e desça quando peço, para que o jogo fique do meu tamanho.*

**De onde vem a regra.** O orientador decidiu em 26/11/2026 que o N sobe dentro do jogo no Core, "como no protótipo". A regra é a do protótipo web (`prototipos-web/nback/nback.js`): a fase a 100% é a que fecha sem erro, sem zerada e fora de N=0 (`nback.js:446`); três seguidas sobem o N em 1 (`nback.js:462-465`), até 3 em S1 e S2 (`nback.js:24`); a contagem zera na subida (`nback.js:464`), na regressão (`nback.js:430`) e a cada partida (`nback.js:257`); a regressão desce o BPM 20 até 60 e, já em 60, o N 1 até 1, e no piso não faz nada (`nback.js:422-442`). O BPM não sobe sozinho: no protótipo ele só desce (`nback.js:425`) ou vem do painel (`nback.js:606`). A avaliação inicial (US-07.3) não conta para a subida. Na Expansão, o backend pode trocar esta regra pela interface da US-08.1.

**Requisitos do SGDD que ela realiza:**

- `§5.1` — A progressão de dificuldade se dá pelo aumento do número "N" de passos atrás que devem ser lembrados, ou pela complexidade/velocidade do timestamp musical.
- `§5.3.2` — Aumento de Carga: O N-Back só poderá subir caso o jogador alcance 100% de precisão em 3 fases consecutivas na mesma partida (a contagem recomeça a cada partida), em S1 e em S2.
- `§11.3` — Suporte 1 (S1): Entrada no N-Back = 1, a 60 BPM, fase de 6 blocos. Progressão permitida até N=3 se engajado.
- `§5.3.2` — O BPM só desce: na v1, nenhuma regra automática o sobe; ele sobe só pelo mediador.
- `RT-04` — Botão de "regressão de fase" para manejo de frustração
- `§11.2` — Regressão de fase | Aumento de erros sequenciais ou solicitação ativa da criança (retorno a opções mais fáceis para evitar ataques de frustração). No piso (60 BPM e N=1), o botão "mais fácil" não faz nada e aparece apagado

**Cenários de aceite:**

- Dado N=1 e duas fases seguidas a 100%, quando a terceira fecha a 100%, então a fase seguinte toca em N=2 e a contagem recomeça.
- Dado duas fases a 100% e uma com um erro, quando a seguinte fecha a 100%, então a contagem está em 1 e o N não sobe.
- Dado N=3, quando mais três fases fecham a 100%, então o N fica em 3.
- Dado N=2 e 60 BPM, quando a criança clica em [Mais fácil], então a fase atual recomeça em N=1, com o contador cheio, e a contagem de 100% zera.
- Dado N=1 e 60 BPM (o piso), quando ela clica em [Mais fácil], então nada muda, sem mensagem, e o botão está apagado.
- Dado uma partida nova, quando ela começa, então volta ao N de entrada do asset, mesmo que a anterior tenha chegado a N=3.

| Task | O que fazer | Horas e camada |
| --- | --- | --- |
| T-02.5.1 | Escrever a carga da partida em C# puro (`MatchLoad`): fase a 100% é a que fecha sem erro, sem reescuta e fora de N=0; três seguidas sobem o N em 1, até 3; a contagem zera na subida, na regressão e a cada partida, que recomeça no N de entrada; a regressão desce um degrau (BPM −20 até 60; já em 60, N −1 até 1) e, no piso, não muda nada; o BPM não sobe; teste EditMode | 2 h · gameplay |
| T-02.5.2 | Ligar a carga no `PhaseController`: a fase seguinte toca no N novo, e o pedido de mais fácil recomeça a fase atual um degrau abaixo, com o contador cheio | 2 h · gameplay |
| T-02.5.3 | Montar o botão [Mais fácil] (`EasierButton`) no canto inferior direito da `03_Gameplay`: sempre à mostra, com o ícone da escada maior que 48 dp e sem mensagem; apagado (35% de opacidade) no piso, e normal quando a carga sai dele | 2 h · presentation |

## 4.3 EP-03 — A tela de jogo e a música

O que a criança vê e ouve durante a fase: a fila de blocos, o cronômetro, a sonda à vista, o retorno de acerto, o placar e a música como estímulo. **Milestone: Core.**

**Por que importa:** O SGDD pede que a criança acompanhe a sequência também com os olhos, que o acerto seja comemorado e o erro passe em silêncio.

**Pronto quando:**

- Do ▶ até a pausa, todo quadro tem a fila e o cronômetro;
- O acerto pulsa, mostra o ✓ e toca o arpejo, e o erro não faz nada;
- Uma partida se joga com a música, nota por nota.

## 4.3.1 US-03.1 — Ver a fila de blocos e o cronômetro

**Perfil:** Criança · **Horas:** 9 · **Prioridade:** P1 · **Milestone:** Core · **Depende de:** US-02.2

*Como criança, quero ver cada som virar um bloco numa fila, e o tempo da fase no topo, para que eu acompanhe a sequência também com os olhos.*

**Requisitos do SGDD que ela realiza:**

- `§7.3` — Apresentação visual por meio de blocos de ondas sonoras ou notas musicais enfileiradas.
- `§10.2 Visual` — Cronômetro posicionado de forma visível na parte superior; opção mandatória de fundo branco/neutro; disposição enfileirada clara da estrutura da música.
- `§10.3` — Tela de Jogo: Cronômetro no topo, visualização em cascata (blocos) da música; painel de resposta que surge apenas durante as pausas de questionamento.
- `§10.2 Linguístico` — na fila, o bloco de N atrás ganha contorno e um "?", sem mostrar o som dele (com N=0 o som fica à vista).
- `§7.3` — Controle absoluto de volume musical, permitindo silenciamento se a criança desejar focar apenas no estímulo visual.
- `§10.1` — A interface deve possuir mínimo de ruído visual (ex: evitar estrelinhas ou fundos excessivamente animados) para prevenir distração;

**Cenários de aceite:**

- Dado o clique no ▶, quando o primeiro quadro da fase aparece, então já há o cronômetro cheio no topo e a posição 0 da fila, e do ▶ até a pausa nenhum quadro mostra a tela vazia.
- Dado uma fase a 60 BPM, quando os sons tocam, então entra um bloco por batida, numerado a partir de 0, e o bloco do som atual acende com a forma e o ícone dele.
- Dado a pergunta aberta com N=2, quando a sonda toca, então ela aparece com a identidade do som, e o bloco de 2 atrás ganha o contorno e o "?", sem mostrar o som.
- Dado o volume em 0, quando a criança joga, então responde pelo visual, e o julgamento é o mesmo.

| Task | O que fazer | Horas e camada |
| --- | --- | --- |
| T-03.1.1 | Desenhar a onda sonora e a nota musical dos blocos, e a forma e o ícone de cada som do banco; pôr os campos `shape` e `icon` por id no `StimulusBank` e preenchê-los | 2 h · arte |
| T-03.1.2 | Escrever a fila (`BlockQueueView`): no quadro do ▶ ela já mostra a posição 0; um bloco novo por *timestamp*, no instante do som, numerado a partir de 0, com a onda ou a nota; o bloco atual acende com a identidade e volta a neutro quando o seguinte toca; montar o prefab do bloco e a faixa na `03_Gameplay` | 2 h · presentation |
| T-03.1.3 | Escrever o cronômetro da fase (`PhaseTimerView`) no topo: contagem regressiva, cheio no quadro do ▶, no recomeço da reescuta e na retomada; teste PlayMode: do ▶ até a pausa, todo quadro tem a fila e o cronômetro | 2 h · presentation |
| T-03.1.4 | Escrever a sonda visível (`ProbeView`): na pausa, cada sonda aparece no cartão com a identidade do som enquanto toca; montar o cartão acima do painel | 1 h · presentation |
| T-03.1.5 | Pôr o marcador do bloco de N atrás no `BlockQueueView`: quando a pergunta abre, o bloco ganha contorno de cor quente e um "?" grande, sem a identidade; com N=0, a identidade fica à vista; o marcador some quando a pergunta fecha | 2 h · presentation |

## 4.3.2 US-03.2 — Acertar e ver o retorno; errar sem castigo

**Perfil:** Criança · **Horas:** 4 · **Prioridade:** P1 · **Milestone:** Core · **Depende de:** US-03.1

*Como criança, quero que o acerto seja comemorado e o erro passe em silêncio, para que eu não tenha medo de errar.*

**Requisitos do SGDD que ela realiza:**

- `§4.2` — Acertos: Geram feedback visual imediato (animações de recompensa contidas, para evitar distração) e reforço sonoro agradável (ex: som funcional integrado à música). A pontuação na tela focará nos acertos acumulados.
- `§4.2` — um placar "✓ n" fica à mostra no canto superior esquerdo durante toda a partida e conta os acertos da partida, avaliação inicial incluída; no acerto ele pulsa, o cartão do som novo ganha contorno verde e um ✓ por 0,9 s, e toca o arpejo.
- `RT-01` — Feedback visual neutro para erros (sem punição sonora/visual)
- `§4.2` — Não haverá distorções de áudio, mudança drástica de paleta de cores ou sons de "falha", a fim de evitar estímulos aversivos

**Cenários de aceite:**

- Dado uma resposta certa, quando a criança clica, então o cartão pulsa 8% em 0,45 s, ganha contorno verde e ✓ por 0,9 s, o arpejo toca, e o placar soma 1 e pulsa.
- Dado uma resposta errada, quando ela clica, então nenhum som toca, nada pisca, a paleta não muda e o placar fica igual.
- Dado a tela de jogo, quando a criança procura vidas ou contagem de erro, então não acha nenhuma.

| Task | O que fazer | Horas e camada |
| --- | --- | --- |
| T-03.2.1 | Fazer no projeto o som de acerto, um arpejo curto, e importá-lo | 1 h · conteúdo |
| T-03.2.2 | Escrever o retorno de acerto (`CorrectFeedback`): pulso de 8% em 0,45 s no cartão da sonda, contorno verde e ✓ por 0,9 s, e o arpejo; o erro não toca nada, não pisca e não muda cor; montar o contorno e o ✓ no cartão | 2 h · presentation |
| T-03.2.3 | Escrever o placar "✓ n" (`HitCounterView`) no canto superior esquerdo, à mostra desde o ▶: soma e pulsa no acerto; o erro não muda número nem cor | 1 h · presentation |

## 4.3.3 US-03.3 — Jogar com uma música

**Perfil:** Criança · **Horas:** 8 · **Prioridade:** P2 · **Milestone:** Core · **Depende de:** US-02.4, US-03.1, US-03.2

*Como criança, quero jogar com uma música de verdade, para que cada batida seja uma nota que eu lembro.*

**Requisitos do SGDD que ela realiza:**

- `§4.3` — cada batida é uma nota da melodia, e "igual" quer dizer a mesma nota (altura). A fase é a fatia seguinte da melodia, o som novo é uma nota da melodia sorteada (metade das vezes igual à de N atrás) e a partida acaba quando a música acaba.
- `§5.2` — Velocidade (BPM): Alteração no andamento da música ou ritmo do metrônomo, podendo variar de 60 BPM até 120 BPM.
- `§4.2` — reforço sonoro agradável (ex: som funcional integrado à música)
- `§10.2 Cultural` — Uso de estímulos musicais familiares ou agradáveis à criança (ex: músicas infantis populares ou temas de interesse), sem imposição de gêneros específicos.

**Cenários de aceite:**

- Dado a música escolhida, quando a fase toca, então ela é a fatia seguinte da melodia, uma nota por batida.
- Dado duas batidas com a mesma nota, quando uma é a sonda e a outra está N atrás, então a resposta certa é Sim.
- Dado a música a 80 BPM, quando a fase toca, então o intervalo é 0,75 s e o clipe é a versão de 80; um BPM de 90 toca a versão de 80.
- Dado um acerto com música, quando o arpejo toca, então ele entra no tempo seguinte, na tônica da faixa.
- Dado a última fatia da melodia, quando ela é respondida, então a partida fecha.

| Task | O que fazer | Horas e camada |
| --- | --- | --- |
| T-03.3.1 | Escolher uma música de domínio público ou CC0 e preparar, num editor de áudio fora da Unity, as versões em 60, 80, 100 e 120 BPM, esticadas no tempo sem mudar a altura; importá-las | 2 h · conteúdo |
| T-03.3.2 | Pôr a entrada musical no `StimulusBank` (a faixa de cada BPM, o BPM, a nota da melodia de cada batida e a forma e o ícone de nota) e fatiar a faixa em tempo de execução; teste EditMode: duas batidas com a mesma nota contam como iguais | 2 h · dados |
| T-03.3.3 | Jogar com a música: a fase é a fatia seguinte da melodia, a sonda é uma nota sorteada (metade igual à de N atrás), a fase toca a versão do seu BPM (um BPM entre degraus vai ao de baixo) e a partida acaba quando a música acaba; teste EditMode | 2 h · gameplay |
| T-03.3.4 | Integrar o som de acerto à música: o arpejo na tônica da faixa, tocado no tempo seguinte | 2 h · presentation |

## 4.4 EP-04 — Menus e conforto

A tela inicial com a escolha do som, o [Sair], o volume à mostra, a pausa e a saída pela pausa, e os alvos de clique generosos. **Milestone: Core.**

**Por que importa:** A criança precisa começar sozinha, baixar o som e sair quando quiser, sem ficar presa no jogo.

**Pronto quando:**

- A tela inicial escolhe o som e abre a partida;
- O volume, a pausa, o [Mais fácil] da pausa e o [Voltar ao início] funcionam durante a fase.

## 4.4.1 US-04.1 — Escolher o som e começar

**Perfil:** Criança · **Horas:** 5 · **Prioridade:** P2 · **Milestone:** Core · **Depende de:** US-01.1, US-02.1

*Como criança, quero escolher entre os sons e a música e apertar ▶, para que eu jogue com o que gosto.*

**Requisitos do SGDD que ela realiza:**

- `§5` — O jogo se inicia com a avaliação do estado atual da criança e a seleção do estímulo auditivo preferido (músicas de diferentes gêneros ou ruídos específicos). (A avaliação do humor é a US-09.3, na Expansão.)
- `§10.3` — Menu (decidido pelo orientador em 26/11/2026): botão [Sair] só no Windows ...; a configuração mínima é o volume, à mostra no canto superior direito como em toda tela (forma do protótipo web, sem tela de Configurações à parte).
- `§10.2 Visual` — nenhuma tela corta um botão: a tela inicial e a final rolam, e o ▶ fica sempre alcançável.
- `§10.2 Motor` — Área de clique (hitbox) dos blocos deve ser generosa - tamanho mínimo de 48x48 dp ... (no PC, v1.2, a regra vale para o clique do mouse)

**Cenários de aceite:**

- Dado a tela inicial, quando ela abre, então mostra uma opção por fonte do banco (os sons e a música), com ícone de ≥ 48 dp e sem texto longo.
- Dado a música escolhida, quando a criança aperta ▶, então a partida toca a música.
- Dado a build Windows, quando a tela inicial abre, então o [Sair] está lá e fecha o jogo.
- Dado uma janela de 1024×600, quando a tela inicial ou a final não cabe, então ela rola e o ▶ fica alcançável.

| Task | O que fazer | Horas e camada |
| --- | --- | --- |
| T-04.1.1 | Montar a tela inicial (`SourceGrid`): uma opção por fonte do banco, com o ícone dela (≥ 48 dp, sem texto longo), num `GridLayoutGroup` da `01_Profile`; a escolha vai a um `SessionContext`, que leva a fonte à partida; o ▶ abre a `03_Gameplay` | 2 h · presentation |
| T-04.1.2 | Pôr o [Sair] (ícone de porta) na tela inicial, ativo só na build Windows (`UNITY_STANDALONE_WIN`), e a tela inicial e a final num `ScrollRect` que só rola quando não cabe (1024×600, 1280×720 e 1920×1080), com o ▶ sempre alcançável | 2 h · presentation |
| T-04.1.3 | Ajustar o `CanvasScaler` das cinco cenas (referência 1920×1080) e os alvos, para que todo alvo de clique tenha ≥ 48×48 dp | 1 h · presentation |

## 4.4.2 US-04.2 — Pausar, baixar o volume ou voltar ao início

**Perfil:** Criança · **Horas:** 5 · **Prioridade:** P1 · **Milestone:** Core · **Depende de:** US-02.5, US-03.1

*Como criança, quero pausar, baixar o som e sair quando quiser, para que eu nunca fique presa no jogo.*

**Requisitos do SGDD que ela realiza:**

- `RT-03` — Controle mestre de volume (0-100%) acessível durante o jogo
- `§4.2` — O usuário terá controle sobre o volume ou a opção de desativar os sons inteiramente, respeitando a variabilidade sensorial do espectro.
- `§10.3` — Pausa (decidido pelo orientador em 26/11/2026): o botão de pausa abre três opções com ícones grandes: [Continuar], que recomeça a fase do primeiro timestamp, com a mesma sequência e sem gastar tentativa; [Mais fácil], a mesma regressão do botão da tela de jogo (§11.2); e [Voltar ao início], que fecha a partida na tela final, sem marca de falha.
- `§10.2 Linguístico` — Interface com mínimo de texto; foco em ícones universais (ex: play, pause, volume, recarregar).

**Cenários de aceite:**

- Dado uma fase tocando, quando a criança muda o volume ou silencia, então o som muda na hora, e a fase não pausa nem atrasa.
- Dado uma fase tocando, quando ela pausa, então o som e o cronômetro param; em [Continuar], a fase recomeça do primeiro timestamp, com a mesma sequência e o mesmo contador.
- Dado a pausa fora do piso, quando ela clica em [Mais fácil], então a fase recomeça um degrau abaixo, como pelo botão da tela.
- Dado a pausa, quando ela clica em [Voltar ao início], então a tela final abre com os acertos, sem mensagem de fracasso.

| Task | O que fazer | Horas e camada |
| --- | --- | --- |
| T-04.2.1 | Escrever o volume mestre (`MasterVolumeControl`): slider de 0 a 100% e o botão de silenciar, no canto superior direito da `03_Gameplay` e da `01_Profile`, sem pausar a fase; o mesmo valor vale nas duas telas | 2 h · presentation |
| T-04.2.2 | Escrever a pausa (`PauseController`): o botão de pausa para o som e o cronômetro; [Continuar] recomeça a fase do primeiro *timestamp*, com a mesma sequência e sem gastar tentativa; montar a tela da pausa com ícones grandes | 2 h · presentation |
| T-04.2.3 | Pôr na pausa o [Mais fácil], que faz a regressão do botão da tela (apagado no piso), e o [Voltar ao início], que fecha a partida e abre a tela final com os acertos, sem marca de falha | 1 h · gameplay |

## 4.5 EP-05 — Registro da partida e marco Core

O arquivo de telemetria de cada partida, gravado no PC, o documento do formato dele, e a história de marco do Core. **Milestone: Core.**

**Por que importa:** Sem o arquivo, o jogo não serve ao estudo; sem o marco, as peças nunca foram jogadas juntas.

**Pronto quando:**

- Toda partida grava um JSON no PC, explicado pelo documento do formato;
- A história de marco Core foi jogada na build Windows, e o arquivo bateu com a partida.

## 4.5.1 US-05.1 — O registro da partida, salvo e documentado

**Perfil:** Pesquisador · **Horas:** 8 · **Prioridade:** P1 · **Milestone:** Core · **Depende de:** US-02.5, US-04.1, US-04.2

*Como pesquisador, quero um arquivo de cada partida no PC e um documento que explique cada campo, para que eu analise o que a criança fez sem perguntar ao time.*

**Requisitos do SGDD que ela realiza:**

- `§5.3.1` — Estado: O sistema avalia o estado atual do jogador a cada ciclo, considerando métricas como o tempo de resposta, a contagem de acertos contínuos e o número de tentativas gastas no painel de respostas (Sim/Não).
- `§7.4` — a telemetria é salva em arquivo local no PC
- `§2.3` — o jogo grava a telemetria em arquivo local no PC, e o relatório vem de fora do jogo.
- `RT-10` — Implementar cliente de telemetria no Unity para envio/receção de payloads JSON (via REST) comunicando com a API

**Cenários de aceite:**

- Dado uma partida jogada até o fim, quando a tela final abre, então o JSON dela está no `persistentDataPath`, com cada fase (N, BPM, blocos, duração), cada sonda com o gabarito, a resposta e o tempo de reação, as tentativas gastas, as reescutas, as pausas, as regressões e as subidas de N.
- Dado uma partida fechada pelo [Voltar ao início], quando o arquivo é aberto, então ela está marcada como incompleta, com a saída pela pausa.
- Dado a tela final, quando alguém clica no botão da pasta, então o caminho do arquivo aparece e a pasta abre.
- Dado o documento do formato, quando o pesquisador abre o arquivo de uma partida ao lado dele, então entende cada campo, e não acha nome nem identificador da criança.

| Task | O que fazer | Horas e camada |
| --- | --- | --- |
| T-05.1.1 | Escrever o modelo do registro em C# puro: sessão, partida (fonte, semente, N de entrada), fases (N, BPM, blocos, duração), som de cada *timestamp*, sondas com o gabarito, a resposta e o tempo de reação, tentativas gastas e eventos, sem identificador do jogador; teste EditMode (tempo de reação = resposta − apresentação; acertos seguidos por fase) | 2 h · telemetria |
| T-05.1.2 | Ligar os eventos do jogo ao registro: a escolha da fonte, cada sonda respondida ou esgotada, a reescuta, a pausa e a retomada, a regressão pedida (`voluntary_regression`), a subida de N (`n_up`) e a saída pela pausa | 2 h · telemetria |
| T-05.1.3 | Gravar o JSON da partida no `persistentDataPath` ao fim dela, marcando a incompleta, e pôr na tela final o botão da pasta (`LogFileButton`), que mostra o caminho e abre a pasta | 2 h · telemetria |
| T-05.1.4 | Escrever o formato do registro num `.md` em `Docs/registro/`: a versão, a descrição de cada campo e o exemplo de uma partida completa | 2 h · docs |

## 4.5.2 US-05.2 — Marco Core: uma partida inteira na build de PC

**Perfil:** Time · **Horas:** 3 · **Prioridade:** P1 · **Milestone:** Core · **história de marco Core** · **Depende de:** todas as outras histórias do Core

*Como time, quero jogar a build Windows do menu à tela final e abrir o arquivo da partida, para que o Core se prove jogado, e não só em peças.*

**Requisitos do SGDD que ela realiza:**

- `RT-07` — O jogo não deve exigir postura em pé; deve ser jogável sentado.

**Cenários de aceite:**

- Dado a build Windows gerada pelo item de menu, quando uma pessoa joga sentada, só com o mouse, uma partida da tela inicial à final, acertando três fases seguidas, errando até zerar uma vez, pedindo [Mais fácil] e pausando, então tudo isso acontece, e o N sobe depois da terceira fase a 100%.
- Dado a mesma partida, quando o arquivo de telemetria é aberto com o documento do formato ao lado, então ele bate com o que foi jogado: as fases, as sondas, os tempos, os acertos, as tentativas, a reescuta, a regressão e a subida de N.
- Dado a partida, quando o `Player.log` é olhado, então não há exceção.

| Task | O que fazer | Horas e camada |
| --- | --- | --- |
| T-05.2.1 | Gerar a build Windows pelo item de menu e jogar uma partida da tela inicial à final, sentado e só com o mouse, como no primeiro cenário; corrigir o que aparecer e jogar de novo | 2 h · validação |
| T-05.2.2 | Abrir o arquivo de telemetria da partida com o documento do formato ao lado e conferir que ele bate com o que foi jogado | 1 h · validação |

## 4.6 EP-06 — O painel do mediador

O painel do terapeuta, aberto por atalho: o perfil da criança, os ajustes da sessão, a trava, a interrupção branda, o limite e o encerramento. Nada daqui aparece para a criança. **Milestone: Expansão.**

**Por que importa:** S3 e as sessões mediadas de S2 dependem do terapeuta no controle (§5.3.3); sem o painel, o jogo só serve a quem joga sozinho.

**Pronto quando:**

- O painel abre só pelo atalho, com o perfil, os ajustes, a trava, a interrupção e o encerrar;
- Cada ação do mediador vai para o registro.

## 4.6.1 US-06.1 — Abrir o painel e escolher o perfil

**Perfil:** Mediador · **Horas:** 6 · **Prioridade:** P1 · **Milestone:** Expansão · **Depende de:** US-04.1, US-02.5

*Como mediador, quero abrir um painel que a criança não abre por acaso e escolher o perfil dela, para que o jogo entre no nível certo.*

**Requisitos do SGDD que ela realiza:**

- `RT-08` — Dashboard clínico ou atalhos de teclado para "Trava de Variável" (congelar N-Back e BPM)
- `§5.3.3` — Perfil: o mediador escolhe o perfil da criança (S1, S2 ou S3) no painel; o padrão é S1. ... o painel abre pelo atalho de teclado
- `§11.3` — Suporte 2 (S2): Entrada no N-Back = 1, a 60 BPM, fase de 6 blocos.
- `§11.3` — Depois do treino, a partida de S3 também é em N=0, sem limite de tempo para responder, e o N não sobe
- `§5.3.2` — A partida entra sempre em 60 BPM e no N do perfil (ou nos valores que o mediador definiu no painel), e cada partida recomeça desses valores, sem herdar o que a anterior alcançou.
- `§10.3` — Modo Treino (Onboarding): tutorial jogável (S1 e S2, §4.4) ou Treino Pré-Jogo sem pontuação (S3).

**Cenários de aceite:**

- Dado o jogo aberto, quando o mediador aperta Ctrl+Shift+M, então o painel abre por cima e a fase segue tocando; um clique em qualquer lugar da tela não o abre.
- Dado o perfil S2 escolhido, quando a partida seguinte começa, então entra em N=1, 60 BPM e 6 blocos, e não nos valores que a anterior alcançou.
- Dado o perfil S3, quando a partida começa, então vai ao treino e depois joga em N=0, sem barra de tempo, e o N não sobe.
- Dado nenhum perfil escolhido, quando a partida começa, então a entrada é a de S1.

| Task | O que fazer | Horas e camada |
| --- | --- | --- |
| T-06.1.1 | Montar o painel do mediador (`MediatorPanel`) como um Canvas por cima, com as seções perfil, ajustes, trava, interrupção, contexto e encerrar, e o acesso (`MediatorAccess`) só pelo `Ctrl+Shift+M`; com o painel aberto, a fase segue tocando | 2 h · presentation |
| T-06.1.2 | Escrever as faixas de entrada por perfil (`ProfileEntryRanges`, ScriptableObject e asset): S1 e S2 em N=1, 60 BPM e 6 blocos; S3 em N=0, sem tempo de resposta e com o teto do N em 0 na carga da partida; cada partida começa nos valores de entrada; teste EditMode | 2 h · dados |
| T-06.1.3 | Escrever o seletor de perfil (`ProfileSelector`: S1, S2 ou S3, padrão S1, e o código do paciente) na seção perfil, e o roteador: S1 vai ao tutorial com Pular, S2 ao tutorial obrigatório na primeira vez, S3 ao treino | 2 h · gameplay |

## 4.6.2 US-06.2 — Ajustar a sessão, travar e acalmar

**Perfil:** Mediador · **Horas:** 8 · **Prioridade:** P1 · **Milestone:** Expansão · **Depende de:** US-06.1

*Como mediador, quero ajustar os valores da sessão, travar o N e o BPM e virar a pergunta em N=0 na hora, para que eu responda ao que vejo na criança antes que o jogo perceba.*

**Requisitos do SGDD que ela realiza:**

- `RT-08` — Dashboard clínico ou atalhos de teclado para "Trava de Variável" (congelar N-Back e BPM)
- `RT-09` — Comando de "Interrupção Branda" para transição imediata para o Modo "Treino Pré-Jogo" (N=0)
- `§5.3.3` — Trava de Variável: O terapeuta poderá fixar o nível de N-Back (ex: travar em N=1) ou travar o BPM, impedindo que o algoritmo dinâmico aumente a dificuldade se notar sinais físicos de irritabilidade no paciente antes que o sistema detecte falhas computacionais.
- `§5.3.3` — Interrupção Branda: Um controle para transformar o próximo questionamento instantaneamente em um "Treino Pré-Jogo" (Associação direta N=0), permitindo a autorregulação do paciente sem a necessidade de fechar e reiniciar o software.
- `§5.3.3` — N de entrada: o mediador escolhe no painel o N com que a partida começa, de 0 a 3; o padrão é o N do perfil (0 em S3, 1 em S1 e S2), e trocar o perfil volta ao padrão. Vale a partir da partida seguinte.
- `§5.3.3` — Os ajustes do mediador e a trava passam de uma partida para a seguinte e valem até o fim da sessão.
- `§4.3` — esse valor poderá ser alterado ... por um mediador no controle das variáveis principais do jogo.

**Cenários de aceite:**

- Dado 5 tentativas no painel, quando a fase seguinte começa, então o contador começa em 5.
- Dado BPM 90 pedido com música, quando a fase seguinte toca, então toca a versão de 80.
- Dado a trava de N em 1, quando a criança fecha três fases a 100%, então o N fica em 1; o [Mais fácil] e o que desce continuam valendo.
- Dado a interrupção branda no meio da fase, quando a próxima pergunta abre, então ela é em N=0, sem recarregar a cena; o mesmo comando volta ao jogo.

| Task | O que fazer | Horas e camada |
| --- | --- | --- |
| T-06.2.1 | Montar os ajustes do mediador (`MediatorSettingsView`) na seção ajustes: tentativas (1 a 5), BPM (60 a 120), blocos por fase (4 a 12), tempo de resposta (5 a 20 s), sondas (1 a 5), estímulos distintos (3 a 5), N de entrada (0 a 3) e o ritmo do treino (3 a 15 s, ou manual) | 2 h · presentation |
| T-06.2.2 | Aplicar os ajustes em C# puro: o valor do mediador vence a entrada do perfil, vale a partir da fase seguinte (o N de entrada, a partir da partida seguinte) e passa de uma partida para a outra até o fim da sessão; trocar o perfil volta o N de entrada ao padrão; com música, o BPM vai ao degrau de baixo; teste EditMode | 2 h · gameplay |
| T-06.2.3 | Escrever a trava de N e de BPM em C# puro: segura o que sobe acima do travado (a subida de N da US-02.5 inclusive) e deixa passar o que desce, a regressão e o valor do mediador; os interruptores na seção trava, os atalhos `Ctrl+Shift+N` e `Ctrl+Shift+B` e o indicador só no painel; teste EditMode | 2 h · gameplay |
| T-06.2.4 | Escrever a interrupção branda (`SoftInterruptControl` e `Ctrl+Shift+I`): a próxima pergunta vira N=0 (na pausa, a atual), sem recarregar a cena, e o mesmo comando volta ao jogo; o evento vai ao registro | 2 h · gameplay |

## 4.6.3 US-06.3 — A sessão termina na hora certa

**Perfil:** Mediador · **Horas:** 7 · **Prioridade:** P1 · **Milestone:** Expansão · **Depende de:** US-06.1

*Como mediador, quero que a sessão pare no limite de tempo e que eu possa encerrá-la com o motivo, para que a criança não passe do ponto e o pesquisador saiba por quê.*

**Requisitos do SGDD que ela realiza:**

- `§11.2` — Limite de duração da sessão | 15 min, ajustáveis pelo mediador de 5 a 20 min; no limite, a fase em curso termina e a partida fecha na tela final, sem mensagem
- `§11.2` — Interrupção de sessão | Irritabilidade persistente com a dificuldade, dispersão de olhar frequente, desengajamento da tarefa ou vocalizações de recusa.
- `§11.2` — Interrupção do protocolo | Sinais consistentes de sobrecarga sensorial ou recusa persistente em participar ao longo de 3 sessões consecutivas.
- `§13` — Viabilidade real do uso domiciliar sem supervisão para perfil S2
- `§13A` — H-01 — O feedback neutro de falha evitará o abandono prematuro por parte de usuários com baixa tolerância à frustração.
- `§13A` — H-02 — O uso do jogo via tela touchscreen (tablet/celular) aumentará a adesão e o tempo de uso em comparação ao Desktop.

**Cenários de aceite:**

- Dado o limite em 15 min, quando ele passa no meio de uma fase, então a fase termina e a tela final abre, sem mensagem.
- Dado o encerrar com o motivo "recusa", quando o mediador confirma, então a tela final abre sem mensagem de fracasso e o registro grava o motivo.
- Dado três sessões seguidas do mesmo código encerradas por sobrecarga ou recusa, quando a terceira fecha, então o aviso aparece no painel; com uma completa no meio, não aparece.
- Dado o contexto "domiciliar com supervisão" marcado, quando o arquivo é aberto, então o contexto, o tempo de uso e se a sessão foi abandonada estão nele.

| Task | O que fazer | Horas e camada |
| --- | --- | --- |
| T-06.3.1 | Escrever o relógio da sessão (15 min; o controle de 5 a 20 min na seção ajustes, `SessionLimitControl`): no limite, a fase em curso termina e abre a tela final, sem mensagem | 2 h · gameplay |
| T-06.3.2 | Escrever o encerrar (`EndSessionControl` e `Ctrl+Shift+E`), com o motivo por ícone (irritabilidade, olhar disperso, desengajamento, recusa, outro): abre a tela final sem mensagem de fracasso e grava `session_interrupted` com o motivo | 2 h · presentation |
| T-06.3.3 | Escrever o aviso do protocolo em C# puro: três sessões seguidas do mesmo código encerradas por sobrecarga ou recusa avisam, e uma completa no meio recomeça a contagem; teste EditMode; o aviso (`ProtocolWarningView`) no painel | 2 h · gameplay |
| T-06.3.4 | Pôr o contexto de uso na seção contexto (`UsageContextSelector`: domiciliar sem supervisão, domiciliar com supervisão ou clínico) e gravar no registro o contexto, o abandono (H-01) e o tempo de uso (H-02) | 1 h · telemetria |

## 4.7 EP-07 — Treino, tutorial e avaliação

Como a criança aprende o jogo: o treino em N=0 de S3, o tutorial jogável de S1 e S2, e a avaliação curta no começo da partida. **Milestone: Expansão.**

**Por que importa:** O Core começa direto no jogo; para S2 e S3, entender a causa e o efeito do clique vem antes da memória (GP-05).

**Pronto quando:**

- Cada perfil passa pela sua camada antes da partida;
- O registro grava o progresso do treino e o resultado da avaliação.

## 4.7.1 US-07.1 — Treinar sem pressa, em N=0

**Perfil:** Criança · **Horas:** 4 · **Prioridade:** P1 · **Milestone:** Expansão · **Depende de:** US-06.1

*Como criança de S3, quero treinar com o terapeuta, sem tempo nem pontos, para que eu entenda o clique antes do desafio de memória.*

**Requisitos do SGDD que ela realiza:**

- `RT-05` — Modo "Treino Pré-Jogo" sem cronômetro ou contagem de erro
- `§4.4` — Para perfis com necessidade de mediação (Suporte 3): Haverá um modo de "Treino Pré-Jogo" sem contagem de pontuação ou regressiva, desenvolvido para uso com suporte físico e verbal do terapeuta, permitindo a compreensão da associação de causa e efeito na tela antes de introduzir qualquer desafio de memória.
- `§11.3` — O marco de sucesso para finalização da fase é conseguir três acertos consecutivos.
- `§13A` — H-04 — O Modo "Treino Pré-Jogo" (Associação Direta N=0) permitirá que usuários S3 compreendam a relação de clique/toque na tela, possibilitando a futura introdução do N-Back.

**Cenários de aceite:**

- Dado o treino, quando o par toca, então o bloco e o painel Sim/Não aparecem, sem cronômetro nem pontos.
- Dado um erro, quando a criança clica, então nada muda na tela nem no som, e a sequência de acertos volta a zero.
- Dado três acertos seguidos, quando o terceiro acontece, então o treino acaba e aparece o botão Jogar, que abre a partida.
- Dado o modo manual, quando a criança responde, então o par seguinte só vem no comando do mediador.

| Task | O que fazer | Horas e camada |
| --- | --- | --- |
| T-07.1.1 | Montar a tela do treino na `02_Training` (`TrainingController`): o bloco do som e o painel Sim/Não da partida, sem cronômetro nem pontos; o acerto dá o retorno de acerto, e o par seguinte vem depois da resposta e do intervalo (6 s) ou no comando manual | 2 h · presentation |
| T-07.1.2 | Escrever a regra do treino em C# puro (N=0, sem tempo nem contador; três acertos seguidos encerram; o erro zera a sequência em silêncio), com teste EditMode; o botão Jogar, escondido até lá, abre a partida; o progresso do treino vai ao registro (H-04) | 2 h · gameplay |

## 4.7.2 US-07.2 — Aprender jogando o tutorial

**Perfil:** Criança · **Horas:** 9 · **Prioridade:** P2 · **Milestone:** Expansão · **Depende de:** US-06.1

*Como criança de S1 ou S2, quero aprender jogando três degraus curtos, para que eu entenda o objetivo antes da partida.*

**Requisitos do SGDD que ela realiza:**

- `RT-06` — Tutorial rápido embutido com opção de "Pular" (Skip)
- `§4.4` — a criança joga três degraus curtos e só avança acertando (errar repete a pergunta, sem contar erro): (1) N=0, três blocos, e o bloco comparado fica à vista; (2) N=1, quatro blocos, o bloco de 1 atrás marcado com "?"; (3) N=1 como na partida, com resposta "não". Nos degraus 1 e 2, se ela demorar, a mão aponta o bloco comparado (aos 2,5 s) e depois o botão certo (aos 4,5 s).
- `§4.4` — A narração fica sempre ligada no tutorial, com uma frase por degrau. No fim, a mão mostra o botão "mais fácil" e a pausa.
- `§4.4` — Para perfis autônomos (ex: Suporte 1): O tutorial será embutido e opcional: abre antes da primeira partida, com Pular; depois, fica no botão "❔ Como jogar" da tela inicial.
- `§4.4` — Para perfis que requerem instrução (ex: Suporte 2): o mesmo tutorial jogável, obrigatório antes da primeira partida (sem Pular); depois, a partida vai direto ao jogo, e o tutorial fica no botão "❔ Como jogar" da tela inicial, com Pular

**Cenários de aceite:**

- Dado o primeiro degrau (N=0, bloco à vista), quando a criança erra, então a pergunta repete, sem contar erro nem gastar tentativa; quando acerta, abre o degrau 2.
- Dado os degraus 1 e 2 sem resposta, quando passam 2,5 s, então a mão aponta o bloco comparado; aos 4,5 s, o botão certo.
- Dado S2 na primeira vez, quando a partida vai começar, então o tutorial abre sem Pular; na segunda vez, a partida abre direto.
- Dado o "❔ Como jogar" na tela inicial, quando a criança o clica, então o tutorial abre com Pular e, no fim, volta à tela inicial.

| Task | O que fazer | Horas e camada |
| --- | --- | --- |
| T-07.2.1 | Escrever o tutorial jogável (`TutorialSequence`) com o motor da partida e sequências fixas: N=0 com o bloco à vista; N=1 com o bloco marcado; N=1 como na partida, com resposta "não"; só avança com acerto, o erro repete sem contar e sem gastar tentativa, sem tempo; o placar conta os acertos | 2 h · gameplay |
| T-07.2.2 | Desenhar a mão que aponta (estática) e escrever a dica: nos degraus 1 e 2, sem resposta, ela aponta o bloco aos 2,5 s e o botão certo aos 4,5 s; no fim, aponta o [Mais fácil] e a pausa, sem cobrir o que aponta | 2 h · presentation |
| T-07.2.3 | Gravar ou sintetizar em pt-BR as três frases do tutorial, uma por degrau, e tocá-las em cada pergunta do degrau, mesmo com a narração do jogo desligada | 2 h · conteúdo |
| T-07.2.4 | Pôr o Pular (encerra num clique) e o modo obrigatório: em S2, sem a marca de tutorial visto, o tutorial abre antes da primeira partida sem Pular; com a marca, a partida vai direto; a marca é salva por perfil | 2 h · gameplay |
| T-07.2.5 | Pôr o botão "❔ Como jogar" na `01_Profile`, abaixo do ▶: abre o tutorial com Pular, em qualquer perfil, e volta à tela inicial | 1 h · presentation |

## 4.7.3 US-07.3 — Uma avaliação curta no começo da partida

**Perfil:** Criança · **Horas:** 3 · **Prioridade:** P3 · **Milestone:** Expansão · **Depende de:** US-06.2

*Como criança de S1 ou S2, quero jogar duas fases curtas no começo, para que o jogo saiba como está a minha memória hoje.*

**Requisitos do SGDD que ela realiza:**

- `§5.1` — O jogo avalia o nível de memória de curto prazo (especialmente para usuários com TDAH associado).
- `§5.1` — cada partida de S1 e S2 abre com duas fases curtas de avaliação no N do perfil, que só podem baixar a entrada, nunca subir ... S3 não faz a avaliação.
- `§5.1` — (Nota v1.2: ... o jogo joga as duas fases e manda o resultado; o backend aplica a regra acima e devolve a entrada pela API.)

**Cenários de aceite:**

- Dado uma partida de S1, quando ela começa, então joga duas fases de 6 blocos em N=1, com fila, cronômetro e placar, sem retorno de erro.
- Dado S3, quando a partida começa, então não há avaliação.
- Dado a avaliação desligada no painel, quando a partida começa, então ela vai direto à primeira fase.
- Dado as duas fases jogadas, quando o arquivo é aberto, então os acertos e os tempos de resposta delas estão nele, e elas não contaram para a subida de N.

| Task | O que fazer | Horas e camada |
| --- | --- | --- |
| T-07.3.1 | Escrever a avaliação inicial: duas fases de 6 blocos em N=1 no começo de cada partida de S1 e S2 (S3 não), na mesma tela de jogo, sem retorno de erro; o resultado (acertos e tempos de resposta) vai ao registro; a carga da partida não conta essas fases | 2 h · gameplay |
| T-07.3.2 | Pôr o interruptor "avaliação inicial" (ligado por padrão) na seção ajustes do painel | 1 h · presentation |

## 4.8 EP-08 — Parâmetros por interface

A porta por onde o backend vai mandar o N, o BPM, as tentativas e o tamanho de cada fase. Até a API existir, quem responde é um provedor local, com a regra de subida do Core. **Milestone: Expansão.**

**Por que importa:** A adaptação é do backend (padrão CIATEC); com a interface pronta, a conexão com a API (`ABD-1-Lucas-api.md`) entra sem mexer no jogo.

**Pronto quando:**

- O jogo pede os parâmetros no começo de cada fase e antes de cada reescuta, aplica-os pela trava e pelo mediador, e grava o recebido.

## 4.8.1 US-08.1 — Os parâmetros da fase chegam por interface

**Perfil:** Pesquisador · **Horas:** 6 · **Prioridade:** P1 · **Milestone:** Expansão · **Depende de:** US-06.2, US-07.3

*Como pesquisador, quero que o jogo peça os parâmetros de cada fase a um provedor trocável, para que o backend assuma a adaptação sem mudar o jogo.*

**Requisitos do SGDD que ela realiza:**

- `§5.3` — o jogo manda o estado ao fim de cada fase e antes de cada reescuta, o backend executa as regras abaixo e devolve os parâmetros da fase seguinte (N, BPM, tentativas e tamanho), e o jogo os aplica e grava o que recebeu.
- `§5.3.3` — (v1.2: a trava fica no jogo e vale sobre os parâmetros que o backend devolve: segura o que sobe acima do travado e deixa passar o que desce.)
- `§11.1` — Distância do N-Back | faixa: 1 a 3 (ou modo de associação direta 0 para S3)
- `§5.3.2` — No piso (60 BPM e N=1), a segunda zerada vira as perguntas em N=0 até três acertos, contados no total e não seguidos; com o terceiro, a fase acaba e a seguinte volta ao N de antes.
- `RT-10` — Implementar cliente de telemetria no Unity para envio/receção de payloads JSON (via REST) comunicando com a API

**Cenários de aceite:**

- Dado um provedor de teste que manda N=2, 80 BPM, 4 tentativas e 8 blocos, quando a fase seguinte começa, então ela usa esses valores.
- Dado BPM 150 recebido, quando o jogo o aplica, então recusa, a fase repete os parâmetros da anterior, e a recusa vai para o registro.
- Dado a trava de N em 1 e N=2 recebido, quando a fase começa, então fica N=1; um BPM mais baixo vale.
- Dado N=0 recebido, quando a fase começa, então as perguntas são em N=0 até três acertos, e com o terceiro a fase acaba.
- Dado o provedor local, quando a criança fecha três fases a 100%, então o N sobe como na US-02.5.

| Task | O que fazer | Horas e camada |
| --- | --- | --- |
| T-08.1.1 | Escrever a interface `IPhaseParameterProvider` em `Ritmo.Adaptive`, com `PhaseParameters` (N, BPM, tentativas, blocos) e `PhaseState` (o resultado da fase, o perfil, a partida, a avaliação inicial e o que o mediador escolheu); o jogo pede no começo de cada fase e antes de cada reescuta | 2 h · gameplay |
| T-08.1.2 | Escrever o `PhaseParameterApplier` em C# puro: aplica o recebido na fase seguinte; recusa o fora da faixa da §11.1 (a fase repete a anterior); passa pela trava; o valor do mediador vence; um N=0 recebido vira as perguntas em N=0 até três acertos; teste EditMode | 2 h · gameplay |
| T-08.1.3 | Escrever o provedor local (`LocalParameterProvider`), que devolve a entrada do perfil com os ajustes do mediador e aplica a carga da US-02.5, e gravar por fase `phase_parameters_received` (o recebido, o aplicado, a origem `local` ou `server` e as recusas) | 2 h · gameplay |

## 4.9 EP-09 — Música, professor e preferências

O que deixa o jogo com a cara da criança: gêneros e ruídos, a música inteira como prêmio, o metrônomo, o professor que narra e pergunta, o humor, as cores e as preferências. Fecha com a história de marco da Expansão. **Milestone: Expansão.**

**Por que importa:** GP-03: menos atrito sensorial e mais gosto pessoal mantêm a criança na sessão.

**Pronto quando:**

- A criança escolhe entre gêneros e ruídos e ouve a música inteira no fim;
- O professor, as cores e as preferências funcionam;
- A história de marco Expansão foi jogada na build Windows.

## 4.9.1 US-09.1 — Mais sons: gêneros, ruídos, o metrônomo e a música inteira

**Perfil:** Criança · **Horas:** 8 · **Prioridade:** P2 · **Milestone:** Expansão · **Depende de:** US-06.2

*Como criança, quero escolher entre gêneros e ruídos e ouvir a música inteira no fim, para que o jogo tenha o som de que gosto.*

**Requisitos do SGDD que ela realiza:**

- `§2` — No que diz respeito às músicas, haverá diferentes gêneros para maior alcance de gostos pessoais.
- `§10.2 Cultural` — Uso de estímulos musicais familiares ou agradáveis à criança (ex: músicas infantis populares ou temas de interesse), sem imposição de gêneros específicos.
- `§5` — Ao final de uma partida completa, a criança recebe a pontuação enfatizando os acertos e ganha a recompensa de escutar a música inteira sem pausas.
- `§10.3` — Tela de Sessão Finalizada: ... botão para ouvir a música completa (reforçador).
- `§13A` — H-03 — A opção de ouvir a música inteira ao final da partida atuará como um reforçador positivo forte o suficiente para garantir a repetição do ciclo.
- `§5.2` — Velocidade (BPM): Alteração no andamento da música ou ritmo do metrônomo

**Cenários de aceite:**

- Dado a tela inicial, quando ela abre, então há 3 gêneros (um de músicas infantis populares) e 2 ruídos, além dos sons de teste.
- Dado a tela final, quando a criança clica em ouvir a música, então ela toca inteira, sem pausas, com o volume mestre; sem música escolhida, toca a infantil padrão.
- Dado a música inteira tocada, quando o arquivo é aberto, então diz se ela ouviu até o fim ou em que segundo parou.
- Dado o metrônomo ligado nos ajustes, quando a fase toca, então o clique cai no mesmo timestamp do som; desligado (o padrão), não toca.

| Task | O que fazer | Horas e camada |
| --- | --- | --- |
| T-09.1.1 | Escolher 3 gêneros (um de músicas infantis populares de domínio público) e 2 ruídos (como chuva e ondas), de domínio público ou CC0 | 2 h · conteúdo |
| T-09.1.2 | Preparar as quatro versões de BPM de cada música, importar cada fonte e pô-la no `StimulusBank`, como na US-03.3 | 2 h · conteúdo |
| T-09.1.3 | Escrever o catálogo (`StimulusCatalog`, ScriptableObject e asset): fonte → tipo, gênero, ícone e qual música é a infantil padrão; a tela inicial lista o catálogo | 1 h · dados |
| T-09.1.4 | Pôr na tela final o ouvir a música inteira (`FullTrackRewardButton`): toca a fonte inteira, sem pausas (sem música escolhida, a infantil padrão), com o volume mestre; `reward_played` e `reward_finished` no registro (H-03) | 2 h · presentation |
| T-09.1.5 | Escrever o clique do metrônomo (`MetronomeClick`), desligado por padrão, no mesmo `dspTime` dos *timestamps* e com o volume mestre; importar o som de clique e pôr o interruptor nos ajustes | 1 h · presentation |

## 4.9.2 US-09.2 — O professor narra e pergunta

**Perfil:** Criança · **Horas:** 8 · **Prioridade:** P3 · **Milestone:** Expansão · **Depende de:** US-06.2

*Como criança, quero um professor que conta as batidas e me faz a pergunta, para que o jogo vire uma aula de música e eu saiba qual é o N.*

**Requisitos do SGDD que ela realiza:**

- `§7.2` — O jogador assume o papel de um músico aprendiz.
- `§7.2` — Um "professor" narra os trechos tocados e, em seguida, realiza perguntas para testar a memória do aluno, o que justifica a narração de fundo e fornece um envelopamento narrativo amigável para o N-Back.
- `§10.2 Auditivo` — Opção de narração de fundo para os timestamps, facilitando o acompanhamento para pessoas com visão reduzida
- `§10.2 Linguístico` — o balão acima do som novo mostra o ouvido, o número N grande e uma seta para a esquerda

**Cenários de aceite:**

- Dado a pergunta aberta com N=2, quando a sonda toca, então o balão do professor abre acima do cartão, com o ouvido, o 2 grande e a seta; com N=0, só o ouvido; ele fecha com a resposta.
- Dado a narração ligada a 60 BPM, quando a fase toca, então o professor fala o número de cada batida, sem atrasar o som; acima de 80 BPM, de 4 em 4.
- Dado a narração desligada (o padrão), quando a fase toca, então nenhuma voz toca.

| Task | O que fazer | Horas e camada |
| --- | --- | --- |
| T-09.2.1 | Desenhar o professor e o aluno músico aprendiz, estáticos e em cores suaves; pôr o professor na tela de jogo e o aprendiz na inicial e na final | 2 h · arte |
| T-09.2.2 | Escrever o balão do professor (`TeacherBalloon`): abre com a sonda, acima do cartão dela, com o ouvido, o N grande e a seta para a esquerda (N=0: só o ouvido), e fecha com a resposta | 2 h · presentation |
| T-09.2.3 | Gravar ou sintetizar as falas do professor em pt-BR: os números, o início da fase e a pergunta | 2 h · conteúdo |
| T-09.2.4 | Escrever a narração (`Narrator` e `NarrationToggle`): o número a cada *timestamp* até 80 BPM e de 4 em 4 acima, num canal próprio, sem atrasar o som; a pergunta na pausa; desligada por padrão, com o interruptor nos ajustes | 2 h · presentation |

## 4.9.3 US-09.3 — Do meu jeito: humor, cores e preferências

**Perfil:** Criança · **Horas:** 7 · **Prioridade:** P3 · **Milestone:** Expansão · **Depende de:** US-07.1, US-06.2, US-09.1, US-09.2

*Como criança, quero dizer como estou, escolher as cores dos blocos e o meu som, para que o jogo não me incomode.*

**Requisitos do SGDD que ela realiza:**

- `§10.3` — Tela Inicial/Perfil: Avaliação rápida do estado atual (humor) e escolha do estímulo (música/ruído).
- `§7.3` — As cores dos blocos devem ser customizáveis para evitar rejeição intencional por hiperfoco em cores específicas.
- `§3A` — GP-03 — Multipla escolha de gêneros musicais ou tipos de som, além de questionários sobre preferências pessoais para interface e afins
- `RT-02` — Fundo de tela branco/neutro como padrão inicial

**Cenários de aceite:**

- Dado a tela inicial, quando a criança escolhe o rosto "mal", então a entrada fica em 60 BPM e o treino é oferecido; ela pode pular a pergunta, e o humor vai para o registro.
- Dado a paleta trocada nos ajustes, quando a fase toca, então os blocos da fila e o Sim e o Não mudam de cor, e Sim e Não continuam de cores distintas.
- Dado o questionário respondido, quando o jogo fecha e abre de novo, então a paleta, o som e a narração escolhidos voltam; pular mantém os padrões neutros.

| Task | O que fazer | Horas e camada |
| --- | --- | --- |
| T-09.3.1 | Desenhar os 3 rostos (bem, mais ou menos, mal) e escrever a pergunta do humor (`MoodQuestion`) na tela inicial, com ≥ 48 dp e o pular; "mal" deixa a entrada em 60 BPM e oferece o treino; o humor vai ao registro | 2 h · presentation |
| T-09.3.2 | Escrever as paletas (`BlockPalette`, ScriptableObject e asset com ao menos 4, Sim e Não de cores distintas) e o seletor (`PaletteSelector`) nos ajustes, que pinta os blocos da fila e os de resposta | 2 h · presentation |
| T-09.3.3 | Escrever o questionário de preferências (`PreferencesQuestionnaire`) por ícones (paleta, música ou ruído, narração): antes da primeira partida, reabrível e pulável, e pular mantém os padrões neutros | 2 h · presentation |
| T-09.3.4 | Salvar as preferências por perfil no PC e aplicá-las ao abrir cada cena | 1 h · dados |

## 4.9.4 US-09.4 — Marco Expansão: uma sessão por perfil na build de PC

**Perfil:** Time · **Horas:** 4 · **Prioridade:** P1 · **Milestone:** Expansão · **história de marco Expansão** · **Depende de:** todas as outras histórias da Expansão

*Como time, quero jogar uma sessão de cada perfil na build Windows e abrir os arquivos, para que a Expansão se prove jogada.*

**Cenários de aceite:**

- Dado a build Windows nova, quando uma pessoa joga uma sessão de S1, uma de S2 e uma de S3 do menu à tela final, então passa pelo tutorial, pelo treino, pela avaliação, pelo painel do mediador (ajustes, trava, interrupção, encerrar), pela música inteira, pelo professor e pelas preferências.
- Dado essas sessões, quando os arquivos de telemetria são abertos com o documento do formato, então batem com o que foi jogado, também nos campos da Expansão (parâmetros recebidos, eventos do mediador, humor, hipóteses e contexto).
- Dado as sessões, quando o `Player.log` é olhado, então não há exceção.

| Task | O que fazer | Horas e camada |
| --- | --- | --- |
| T-09.4.1 | Gerar a build Windows pelo item de menu e jogar uma sessão por perfil (S1, S2 e S3), do menu à tela final, como no primeiro cenário; corrigir o que aparecer | 2 h · validação |
| T-09.4.2 | Pôr no documento do formato os campos da Expansão e conferir os arquivos das três sessões contra o que foi jogado | 2 h · telemetria |

# 5 ROADMAP

Sem datas. A ordem sai das dependências: dentro de cada milestone, de cima para baixo. A Expansão começa depois do marco Core.

| Ordem | História | Milestone | Horas | Acumulado |
| --- | --- | --- | --- | --- |
| 1 | US-01.1 — O jogo abre na tela inicial, com os valores da fase num lugar só | Core | 6 h | 6 h |
| 2 | US-01.2 — A build para o PC | Core | 3 h | 9 h |
| 3 | US-02.1 — Ouvir os sons no compasso | Core | 7 h | 16 h |
| 4 | US-02.2 — Ouvir o som novo e responder Sim ou Não | Core | 8 h | 24 h |
| 5 | US-02.3 — Errar, perder uma tentativa e ouvir de novo | Core | 3 h | 27 h |
| 6 | US-02.4 — Passar de fase e chegar ao fim da partida | Core | 4 h | 31 h |
| 7 | US-02.5 — O N sobe quando acerto tudo, e desce quando peço | Core | 6 h | 37 h |
| 8 | US-03.1 — Ver a fila de blocos e o cronômetro | Core | 9 h | 46 h |
| 9 | US-03.2 — Acertar e ver o retorno; errar sem castigo | Core | 4 h | 50 h |
| 10 | US-03.3 — Jogar com uma música | Core | 8 h | 58 h |
| 11 | US-04.1 — Escolher o som e começar | Core | 5 h | 63 h |
| 12 | US-04.2 — Pausar, baixar o volume ou voltar ao início | Core | 5 h | 68 h |
| 13 | US-05.1 — O registro da partida, salvo e documentado | Core | 8 h | 76 h |
| 14 | US-05.2 — Marco Core: uma partida inteira na build de PC | Core | 3 h | 79 h |
| 15 | US-06.1 — Abrir o painel e escolher o perfil | Expansão | 6 h | 85 h |
| 16 | US-06.2 — Ajustar a sessão, travar e acalmar | Expansão | 8 h | 93 h |
| 17 | US-06.3 — A sessão termina na hora certa | Expansão | 7 h | 100 h |
| 18 | US-07.1 — Treinar sem pressa, em N=0 | Expansão | 4 h | 104 h |
| 19 | US-07.2 — Aprender jogando o tutorial | Expansão | 9 h | 113 h |
| 20 | US-07.3 — Uma avaliação curta no começo da partida | Expansão | 3 h | 116 h |
| 21 | US-08.1 — Os parâmetros da fase chegam por interface | Expansão | 6 h | 122 h |
| 22 | US-09.1 — Mais sons: gêneros, ruídos, o metrônomo e a música inteira | Expansão | 8 h | 130 h |
| 23 | US-09.2 — O professor narra e pergunta | Expansão | 8 h | 138 h |
| 24 | US-09.3 — Do meu jeito: humor, cores e preferências | Expansão | 7 h | 145 h |
| 25 | US-09.4 — Marco Expansão: uma sessão por perfil na build de PC | Expansão | 4 h | 149 h |

# 6 FORA DO BACKLOG

**O que o SGDD exclui:** o ensino de teoria musical (§3.3) e os instrumentos de validação das hipóteses H-01 a H-04 (nota da §13A: pertencem ao Doc 3). O dado que cada hipótese precisa está no registro (US-06.3, US-07.1, US-09.1).

**O que o orientador tirou do backlog em 26/11/2026** (os IDs entre parênteses são da v1.2):

- **A regra de adaptação**, menos a subida do N: é do backend (padrão CIATEC) e está em `ABD-1-Lucas-api.md`, seção 0 — a redução por duas zeradas, o N=0 no piso, a regra das tentativas, a expansão da fase e o que a avaliação inicial muda na entrada (US-07.1, US-07.2, US-08.9, US-08.10 e TASK-151 da v1.0). A subida do N voltou ao jogo na v2.0 (US-02.5).
- **A conexão com a API**: em `ABD-1-Lucas-api.md`, para depois. No jogo fica a interface (US-08.1).
- **A ética, o consentimento e os dados** (o EP-09 da v1.x): tratados fora do jogo, no CEP e no backend. O registro não tem identificador do jogador.
- **O relatório para o terapeuta e a exportação** (US-10.1 e US-10.3 da v1.x): o relatório vem de fora do jogo.
- **Outros dispositivos**: WebGL, Android, Linux, o toque e a engrenagem de 3 s. A build é só Windows.
- **A burocracia**: conferir no Play e anotar na issue, o teste e o registro de licença (o áudio entra só de domínio público ou CC0), medir contraste e dp, a validação com o ABD na mão, o teste-robô que jogava o jogo inteiro, os validadores (as varreduras de texto, de input e da montagem das cenas) e o JSON Schema do registro (o formato fica num `.md`, T-05.1.4). As tasks da v1.2 que saíram por isto estão no mapa, com o motivo.
- **O multiplayer**, que a §2.2 admite "eventualmente", e a multimodalidade (só em `sugestoes-variaveis-lucas.md`): sem história.

# 7 RASTREIO DOS REQUISITOS

Cada requisito técnico da §12 do SGDD (`RT-01` a `RT-10`, na ordem da tabela) e cada seção citada, com as histórias que os realizam. Esta tabela é gerada pelo script do plano.

| Requisito | Histórias |
| --- | --- |
| `RT-01` | US-03.2 |
| `RT-02` | US-01.1, US-09.3 |
| `RT-03` | US-04.2 |
| `RT-04` | US-02.5 |
| `RT-05` | US-07.1 |
| `RT-06` | US-07.2 |
| `RT-07` | US-05.2 |
| `RT-08` | US-06.1, US-06.2 |
| `RT-09` | US-06.2 |
| `RT-10` | US-05.1, US-08.1 (só o registro local e a interface; o cliente REST está em `ABD-1-Lucas-api.md`) |
| `§2` | US-02.1, US-09.1 |
| `§2.2` | US-01.2 |
| `§2.3` | US-05.1 |
| `§3A` | US-09.3 |
| `§4.1` | US-02.2 |
| `§4.2` | US-02.4, US-03.2, US-03.3, US-04.2 |
| `§4.3` | US-01.1, US-02.2, US-02.3, US-02.4, US-03.3, US-06.2 |
| `§4.4` | US-07.1, US-07.2 |
| `§5` | US-04.1, US-09.1 |
| `§5.1` | US-02.1, US-02.3, US-02.5, US-07.3 |
| `§5.2` | US-01.1, US-02.1, US-03.3, US-09.1 |
| `§5.3` | US-08.1 |
| `§5.3.1` | US-05.1 |
| `§5.3.2` | US-02.5, US-06.1, US-08.1 |
| `§5.3.3` | US-06.1, US-06.2, US-08.1 |
| `§7.2` | US-09.2 |
| `§7.3` | US-03.1, US-09.3 |
| `§7.4` | US-01.2, US-05.1 |
| `§10.1` | US-02.2, US-03.1 |
| `§10.2 Auditivo` | US-09.2 |
| `§10.2 Cultural` | US-03.3, US-09.1 |
| `§10.2 Linguístico` | US-01.1, US-03.1, US-04.2, US-09.2 |
| `§10.2 Motor` | US-02.2, US-04.1 |
| `§10.2 Visual` | US-03.1, US-04.1 |
| `§10.3` | US-01.1, US-02.2, US-02.4, US-03.1, US-04.1, US-04.2, US-06.1, US-09.1, US-09.3 |
| `§11.1` | US-01.1, US-08.1 |
| `§11.2` | US-02.5, US-06.3 |
| `§11.3` | US-01.1, US-02.5, US-06.1, US-07.1 |
| `§13` | US-06.3 |
| `§13A` | US-06.3, US-07.1, US-09.1 |

# 8 DECISÕES DESTE PLANO

## 8.1 Decisões de organização

- **No molde do Caça às Cores** (orientador, 26/11/2026): uma história por coisa que a criança ou o mediador faz; tasks de 1 ou 2 h; o teste dentro da task da regra; nada de par `[agente]`/`[aluno]`.
- **Cada épico pertence a um milestone só** (orientador, 26/11/2026): um tema com parte no Core e parte na Expansão virou dois épicos (os menus no EP-04 e as preferências no EP-09; a fase no EP-02 e o mediador no EP-06).
- **O plano conta em horas, e as tasks têm 1 ou 2 h**: uma sessão de trabalho. Sem pontos de história no plano.
- **O registro vem no fim do Core** (EP-05) e recolhe os eventos que as histórias anteriores produzem; a T-05.1.2 liga cada um.
- **Os ícones vêm na fundação** (T-01.1.3), porque o painel Sim/Não, o [Mais fácil] e a pausa os usam.

## 8.2 Decisões do orientador que o plano segue

Todas de 26/11/2026, já escritas no SGDD v1.2, menos a primeira.

- **O N sobe dentro do jogo no Core, como no protótipo** ("Sobem, como no protótipo"): três fases seguidas a 100% sobem o N em 1, até 3 (US-02.5, com as linhas de `nback.js`). Convive com o [Mais fácil], que passa a ter o que baixar. O backend pode trocar a regra depois, pela interface da US-08.1, que fica na Expansão. **Ainda não está no SGDD**, que diz que a subida é do backend (§5.3.2 e a nota da §11.3) e que, sem a API, o jogo usa parâmetros fixos, sem regra (§5.3, §7.4).
- **O Core joga com os valores de entrada do S1** fixos no asset (N=1, 60 BPM, fase de 6 blocos, 3 tentativas, 3 sondas, 10 s), e começa direto na tela inicial, sem tutorial.
- **O BPM não sobe sozinho** (L-39): só desce pelo [Mais fácil], ou muda pelo mediador.
- **A partida**: 3 sondas por fase; a fase avança com as sondas acabadas e o contador acima de zero; 6 fases com sons, ou até a música acabar (L-05). A sequência é sorteada com semente, 50% de Sim, metade das outras como distrator (L-06); de 3 a 5 sons distintos, padrão 5 (L-34).
- **O tempo de resposta**: 10 s, de 5 a 20; esgotado, a sonda toca de novo, sem gastar tentativa (L-12).
- **O retorno**: arpejo curto, pulso de 8% em 0,45 s, contorno verde e ✓ por 0,9 s, placar "✓ n" (L-42); escurecimento de 35% em 0,25 s na pergunta (L-41); o erro não faz nada (RT-01).
- **A fila mostra a identidade do som atual e da sonda** (L-25); o bloco de N atrás ganha contorno e "?" (L-38).
- **A música**: cada batida é uma nota; as versões em 60, 80, 100 e 120 BPM são preparadas fora da Unity e fatiadas em tempo de execução; um BPM entre degraus vai ao de baixo (L-29). O áudio entra só de domínio público ou CC0 (L-02). Sem música escolhida, tocam os 5 sons de teste (L-40).
- **A pausa** tem [Continuar], [Mais fácil] e [Voltar ao início] (L-26, L-35); o [Mais fácil] desce um degrau na hora e fica apagado no piso (L-28).
- **O mediador**: o painel abre só pelo `Ctrl+Shift+M` (L-13); o valor dele vence o resto e vale a partir da fase seguinte (L-32); a trava segura só o que sobe; os ajustes e a trava valem até o fim da sessão; cada partida recomeça na entrada do perfil (L-36). Limite da sessão de 15 min, de 5 a 20 (L-11).
- **O treino N=0** tem o par seguinte depois de 6 s (de 3 a 15) ou no comando do mediador, e acaba com três acertos seguidos (L-31). O tutorial é jogável, em três degraus.
- **A narração** é em pt-BR e vem desligada (L-17); o metrônomo audível também (L-21).

## 8.3 Dúvidas que só o orientador decide

1. **O BPM sobe?** A decisão diz "N e BPM sobem, como no protótipo", mas no protótipo o BPM não sobe sozinho: só desce (`nback.js:425`) ou vem do painel do mediador (`nback.js:606`), como no SGDD (§5.3.2) e na L-39. O plano faz subir só o N.
2. **Só a subida veio para o jogo?** O protótipo também roda no jogo a redução forçada por duas zeradas (`nback.js:409-412` e `422-436`) e o N=0 depois de uma avaliação abaixo de 50% (`nback.js:452-459`). O plano deixa as duas no backend, como na v1.2.
3. **O SGDD precisa da decisão nova.** Ele ainda diz que a subida é do backend e que o jogo sem a API usa parâmetros fixos (§5.3, §5.3.2, §7.4, nota da §11.3). Este plano não altera o SGDD.
4. **A meta de tasks não coube**: 82 tasks e 149 h, contra 50 a 70 tasks (seção 2). Chegar a 70 pede cortar escopo.

# 9 ARQUIVOS E MAPA DA v1.2

| Arquivo | O que é |
| --- | --- |
| `ABD-1-Lucas-issues.csv` | Os épicos, as histórias e as tasks deste plano, para o importador do GitHub (as mesmas colunas da v1.2) |
| `ABD-1-Lucas-labels.csv` | As labels do repositório; as camadas das tasks usam as `layer:*` que já existem |
| `ABD-1-Lucas-api.md` | A conexão com a API, fora do backlog; aponta para a US-08.1 e as tasks dela |

**Mapa das histórias da v1.2 para a v2.0.** Nenhuma história sumiu: cada uma está dentro de uma história nova. O mapa task a task, com o motivo de cada task da v1.2 que saiu, está em `mapa-molde-caca.md`, fora do repositório.

| História v2.0 | Histórias da v1.2 que ela cobre |
| --- | --- |
| US-01.1 | US-01.1, US-01.2, US-05.1 |
| US-01.2 | US-01.4 |
| US-02.1 | US-02.1, US-02.2, US-03.1 |
| US-02.2 | US-02.3, US-02.6, US-04.3 |
| US-02.3 | US-02.4 |
| US-02.4 | US-02.5, US-04.5 |
| US-02.5 | US-07.3 |
| US-03.1 | US-04.2 |
| US-03.2 | US-04.4, US-04.7 |
| US-03.3 | US-03.2 |
| US-04.1 | US-04.1, US-05.6 |
| US-04.2 | US-05.2, US-05.7 |
| US-05.1 | US-08.1, US-08.2 |
| US-05.2 | US-M1, US-05.5 |
| US-06.1 | US-07.10, US-06.5, US-07.7 |
| US-06.2 | US-07.6, US-07.4, US-07.5 |
| US-06.3 | US-07.8, US-07.9, US-10.4, US-10.5, US-10.2 |
| US-07.1 | US-06.1, US-06.2 |
| US-07.2 | US-06.3, US-06.4 |
| US-07.3 | US-08.6 |
| US-08.1 | US-08.12 |
| US-09.1 | US-03.3, US-03.4, US-02.7 |
| US-09.2 | US-03.5, US-04.8 |
| US-09.3 | US-04.6, US-05.3, US-05.4 |
| US-09.4 | US-M2 |
