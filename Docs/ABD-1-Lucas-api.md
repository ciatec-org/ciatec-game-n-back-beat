---
faixa: CIATec
doc: Doc 2 — Backlog Ágil (parte à parte)
titulo: Ritmo (N-Back Beat) — Conexão com a API
subtitulo: As histórias, spikes e tasks da conexão com a API, fora do backlog do Lucas
versao: v0.7 — a regra de adaptação é do backend (decisão do orientador, 26/11/2026, padrão CIATEC); sem o EP-09
data: 26/11/2026
tipo: backlog
status: guardado para outro momento — fora do backlog (decisão do orientador, 26/11/2026)
fonte_principal: ABD-1-Lucas.md (v0.4; na v0.7, o ABD v1.0 e o SGDD v1.2), seções 6, 9.8, 12 e 13
data_criacao: 26/11/2026
data_atualizacao: 26/11/2026
---

# Ritmo (N-Back Beat) — Conexão com a API

> **Por que este arquivo existe.** Em 25/11/2026 o orientador decidiu que *"conexão com API vem num outro momento"*,
> e em 26/11/2026 que ela **sai do backlog** do jogo, que fica com os milestones Core e Expansão. Para nada se perder,
> tudo o que era do antigo milestone "Conexão com a API" no `ABD-1-Lucas.md` v0.4 está aqui, **inteiro e como
> estava**: as 6 histórias e os 2 spikes do EP-08, as 25 tasks (com o dono, `[agente]` ou `[aluno]`), as lacunas, os
> critérios do DoD, as linhas da validação e as linhas do CSV. Quando a conexão voltar, este arquivo é o ponto de
> partida, e o backlog dela se revisa contra o jogo que existir. Nada daqui está no `ABD-1-Lucas-issues.csv`.
>
> **v0.7 (26/11/2026).** Duas decisões do orientador mudaram o que está aqui. (1) **A regra de adaptação é do backend**
> (padrão CIATEC): as regras que o ABD tinha no jogo (US-07.1, US-07.2, US-08.9, US-08.10 e TASK-151, cortadas do ABD
> v1.0) passam a ser executadas pelo servidor, e estão na seção 0; o jogo recebe os parâmetros pela interface da
> US-08.1 do ABD e, sem a API, usa o provedor local (desde o ABD v2.0, com a subida do N do Core). (2) **O EP-09 (o da v1.x do ABD) foi cortado do jogo** (ética,
> consentimento e dados são tratados fora do jogo, no CEP e no backend): a TASK-199 e a TASK-200, que dependiam dele,
> foram reescritas. A telemetria do jogo fica em arquivo local até a API existir; o relatório e a exportação saíram do
> jogo (US-10.1 e US-10.3 cortadas), e a exportação fica só no servidor (US-08.11).

## 0 A regra de adaptação roda no backend

Decisão do orientador de 26/11/2026, no padrão CIATEC. O servidor (US-08.4, US-08.5, US-08.8) executa, a cada pedido do
jogo, as regras do SGDD v1.2, que continuam escritas lá:

| Regra | SGDD | O que o backend devolve |
| --- | --- | --- |
| Aumento de carga: N sobe 1 só com 100% em 3 fases consecutivas da mesma partida (a contagem recomeça a cada partida), em S1 e S2 | §5.3.2, §11.3 | N + 1, até 3 |
| Redução de carga: duas zeradas na mesma fase reduzem na hora: BPM −20 até 60; já em 60, N −1 até 1 | §5.3.2, §11.2 | os parâmetros reduzidos, antes da reescuta |
| Piso: em 60 BPM e N=1, a segunda zerada vira as perguntas em N=0 até três acertos no total; com o terceiro, a fase acaba e a seguinte volta ao N de antes | §5.3.2 (L-37) | N=0 para a fase, depois o N de antes |
| O BPM só desce: nenhuma regra automática o sobe; a partida entra em 60 BPM e no N do perfil | §5.3.2 (L-39) | nunca um BPM maior que o atual, salvo o valor do mediador |
| Tentativas: +1 se zerou em 2 das 3 últimas fases; −1 depois de 3 fases sem gastar tentativa; faixa 3 a 5 | §4.3 (L-07) | as tentativas da fase seguinte |
| Expansão: engajado (3 fases seguidas sem tempo esgotado e sem reescuta) → a fase cresce 1 bloco, até 9 em S1 e 7 em S2; S3 não cresce | §5.2, §11.3 (L-24, LA-10) | os blocos da fase seguinte |
| Avaliação inicial: abaixo de 50% de acertos nas duas fases, a primeira fase da partida pergunta em N=0 até três acertos; só baixa | §5.1 (L-09) | os parâmetros da primeira fase |
| S3: o N não sobe | §11.3 | N=0 |

**O que o jogo manda** (`PhaseState`, T-08.1.1 do ABD), no fim de cada fase e antes de cada reescuta: o resultado da
fase (tempo de resposta por sonda, acertos, tentativas gastas, zeradas), o perfil, a partida e se é nova, o resultado
da avaliação inicial, os ajustes e a trava do mediador, a interrupção branda e a regressão pedida pela criança.

**O que o jogo recebe** (`PhaseParameters`): N (0 a 3), BPM (60 a 120), tentativas (1 a 5) e blocos por fase (4 a 12). O
jogo recusa o que está fora da faixa (a fase repete a anterior), passa N e BPM pela trava (segura o que sobe acima do
travado) e deixa o valor do mediador vencer (T-08.1.2 do ABD).

**Sem rede**, ou antes de a API existir, o jogo usa o provedor local (T-08.1.3 do ABD): os de entrada
do perfil com os ajustes do mediador e a subida do N do Core (US-02.5 do ABD v2.0: três fases seguidas a 100% sobem o N,
decisão do orientador de 26/11/2026, "como no protótipo"). As outras regras da seção 0 ficam só no servidor.

## 1 Onde isto se liga ao jogo

- **Épico:** EP-08 — Motor adaptativo e telemetria (Unity ↔ FastAPI), o épico da v1.x do `ABD-1-Lucas.md`; na v2.0 do ABD,
  a interface fica no EP-08 — Parâmetros por interface (US-08.1). O registro local e o formato documentado dele
  (US-05.1, no Core) são a base do contrato da API (TASK-196 parte da T-05.1.4).
- **Dependências no jogo:** a interface que recebe os parâmetros e o provedor local (T-08.1.1 a T-08.1.3, US-08.1)
  e a trava (T-06.2.3, US-06.2). O EP-09 (a chave de coleta, o consentimento, a pseudonimização e a varredura de
  campos proibidos) foi cortado do jogo pelo orientador em 26/11/2026.
- **Requisito:** RT-10 — cliente de telemetria no Unity, JSON via REST, comunicando com a API (SGDD §12).

## 2 Critérios do DoD do EP-08 (a parte da API)

- [ ] Conexão com a API: uma sessão jogada envia a telemetria e recebe do servidor os parâmetros de cada fase (RT-10, §7.4)
- [ ] Conexão com a API: o servidor executa as regras da seção 0 e devolve os parâmetros; o jogo recusa o que está fora da faixa e a trava segura o que sobe (§5.3.2, §5.3.3)
- [ ] Conexão com a API: a latência das rotas foi medida e a escolha REST ou WebSocket registrada no SGDD (ação da L-04)
- [ ] Conexão com a API: o tempo de reação medido não muda com atraso de rede simulado; sem rede, a fila é reenviada (L-04, L-19)

## 3 Lacunas da API (como estavam na seção 6 do ABD v0.4)

| ID | Lacuna | Fonte | Decisão provisória | Por quê | Histórias |
| --- | --- | --- | --- | --- | --- |
| L-04 | Latência Unity–FastAPI; esquema JSON; REST ou WebSocket | §13 linha 4 | REST com JSON (o RT-10 já diz REST), trocado só entre fases; o tempo de reação é medido no jogo pelo `dspTime`; WebSocket só se o p95 de ida e volta passar de 300 ms | Trocar só entre fases tira a rede do cronômetro do N-Back, que é o risco que a §13 aponta | US-08.3, US-08.4, SPIKE-02 (milestone da API) |
| L-07 | Algoritmo adaptativo, regra que muda as tentativas e onde fica o backend | §5.3.1, §4.3, §7.4 | A adaptação é do backend (decisão do orientador, 26/11/2026, padrão CIATEC): as regras da seção 0 (as de borda e a das tentativas: +1 se zerou em 2 das 3 últimas fases, −1 depois de 3 fases sem gastar tentativa, faixa 3–5) rodam no servidor; no jogo, sem a API, o provedor local devolve parâmetros fixos (US-08.1 do ABD). Backend em `Server/`, no repositório do jogo, com política inicial de regras e exploração ε-greedy entre as quatro ações da §5.3.1, filtradas pelas regras de borda; o SPIKE-03 confirma ou troca o método | A §5.3.1 diz "por exemplo" e não obriga aprendizado por reforço; começar simples dá um método medível com os dados de uma sessão; o repositório já existe | US-08.9 (jogo); US-08.4, US-08.5, US-08.8, SPIKE-03 (API) |
| L-19 | O que o jogo faz sem conexão com o servidor | §7.4, §13 linha 4 | Sem a API, o jogo usa o provedor local, com a subida do N do Core (US-08.1 do ABD; a adaptação é do backend, decisão do orientador de 26/11/2026), e o registro vai só para arquivo local (US-05.1, US-05.1). Quando a API vier: sem resposta em 1 s, a fase usa o provedor local, e a telemetria entra numa fila local reenviada quando a rede volta | O jogo é seguro sem servidor (EP-06); é também o que o README do fork propõe | EP-06, US-05.1, US-08.1 (jogo); US-08.7 (API) |

O orientador decidiu em 26/11/2026 que o registro é **só local** (o relatório e a exportação saíram do jogo no mesmo dia); o resto destas três lacunas segue
provisório.

## 4 Histórias e spikes

#### US-08.3 — Cliente REST no Unity

**Epic:** EP-08 · **Perfil:** pesquisador · **SP:** 3 · **Prioridade:** P2 · **Milestone:** Conexão com a API · **Horas:** 9 h · **Seções:** §7.4, §2, GP-02, §13 linha 4 · **RT-10** · **Decisão provisória:** L-04

**História.** Como pesquisador, quero que o jogo envie a telemetria e receba a próxima fase, para que o servidor
adapte o desafio.

**Contexto.** Conexão com a API (decisão do orientador em 25/11/2026: a conexão com a API vem em
outro momento). O cliente fala com o serviço do US-08.4, por configuração; os testes usam um serviço falso no Unity
(TASK-141). O tempo de reação é medido no jogo pelo `dspTime`, e a rede só é usada entre fases (L-04). O cliente é um
`IPhaseParameterProvider` (US-08.1 do ABD): entra no lugar do provedor local, sem mexer no jogo. O envio fica
desligado por configuração até o pesquisador ligá-lo (o consentimento é tratado fora do jogo).

**Critérios de aceite**
- [ ] RT-10 — o cliente **envia** o resultado da fase em JSON por REST
- [ ] RT-10 — o cliente **recebe** os parâmetros da fase seguinte
- [ ] §5.3.2, §5.3.3 — o cliente **entrega** os parâmetros recebidos ao `PhaseParameterApplier` (T-08.1.2 do ABD), que recusa o fora da faixa e passa pela trava
- [ ] §13 linha 4 — com 2 s de atraso de rede, o tempo de reação registrado **não muda**
- [ ] com o envio desligado na configuração, **nada sai** do aparelho
- [ ] **para o pesquisador:** registrado na issue: o cliente falando com o serviço publicado, ou esperando o local de hospedagem

**Cenário 1:** **Dado** o serviço local no ar, **quando** a fase termina, **então** a fase seguinte usa os parâmetros recebidos.
**Cenário 2:** **Dado** um parâmetro com BPM 150, **quando** chega, **então** é recusado, e a fase repete os parâmetros da anterior.

`user-story` `domain:backend` `priority:p2` `sp:3`

#### US-08.4 — Serviço FastAPI e contrato da API

**Epic:** EP-08 · **Perfil:** pesquisador · **SP:** 5 · **Prioridade:** P2 · **Milestone:** Conexão com a API · **Horas:** 10 h · **Seções:** §7.4, §13 linha 4 · **Decisões provisórias:** L-04, L-07

**História.** Como pesquisador, quero um servidor que receba a telemetria e devolva a fase, para que a adaptação
rode fora do jogo.

**Contexto.** Conexão com a API. Pela L-07, o serviço mora em `Server/`, no repositório do jogo. O
contrato da API deriva do formato do registro local (US-05.1) e fica em `Docs/api/`. O local de hospedagem fica a
definir (o SGDD sugere research.ciatec.org); a publicação é do pesquisador, e o código entrega o Dockerfile e as
instruções.

**Critérios de aceite**
- [ ] §13 linha 4, L-04 — o contrato da API (`session`, `phase_result`, `next_phase_params`) **está escrito** em `Docs/api/`, com versão, e **é leve**: um resultado por fase
- [ ] §7.4 — o serviço **recebe** a telemetria e **devolve** os parâmetros da fase
- [ ] o serviço **valida** a entrada pelo contrato e **responde** 422 nomeando o campo inválido
- [ ] LGPD — o serviço **recusa** payload com nome, documento ou data de nascimento
- [ ] L-07 — o serviço **vive** em `Server/` e **sobe** por Dockerfile
- [ ] **para o pesquisador:** registrado na issue: o serviço publicado (com o endereço), ou esperando o local de hospedagem

**Cenário 1:** **Dado** uma telemetria válida, **quando** chega, **então** o serviço devolve parâmetros válidos.
**Cenário 2:** **Dado** uma telemetria sem o campo `phase`, **quando** chega, **então** o serviço responde 422 com o campo.

`user-story` `domain:backend` `priority:p2` `sp:5`

#### US-08.5 — Política adaptativa: estado e ação

**Epic:** EP-08 · **Perfil:** pesquisador · **SP:** 3 · **Prioridade:** P2 · **Milestone:** Conexão com a API · **Horas:** 7 h · **Seções:** §5.3.1, §5.1, GP-02 · **Decisão provisória:** L-07 · depende do SPIKE-03

**História.** Como pesquisador, quero que o servidor leia o estado do jogador e escolha a próxima ação, para manter a
criança na zona de desafio.

**Contexto.** Conexão com a API. Pela L-07, a política inicial é de regras com exploração
ε-greedy; o SPIKE-03 confirma ou troca o método antes da TASK-148. Desde 26/11/2026 a regra de adaptação inteira
roda aqui (seção 0; decisão do orientador, padrão CIATEC).

**Critérios de aceite**
- [ ] §5.3.1 — o estado **considera** o tempo de resposta, os acertos contínuos e as tentativas gastas
- [ ] §5.3.1 — a ação **é** subir N, subir BPM, manter ou facilitar
- [ ] §5.3.2, §5.3.3 — a ação **respeita** as regras da seção 0 (borda, piso, BPM que só desce, tentativas, expansão, avaliação inicial, S3) e as travas do terapeuta
- [ ] a ação escolhida **vai** para o registro como `adaptive_adjustment_applied`, com a origem "servidor"

**Cenário 1:** **Dado** um estado de domínio, **quando** a política decide, **então** sobe a carga dentro das bordas.
**Cenário 2:** **Dado** a trava de N ligada, **quando** a política decide, **então** a ação nunca muda N.

`user-story` `domain:ai` `priority:p2` `sp:3` `needs-spike`

#### US-08.7 — Jogar sem servidor

**Epic:** EP-08 · **Perfil:** paciente · **SP:** 3 · **Prioridade:** P2 · **Milestone:** Conexão com a API · **Horas:** 4 h · **Seções:** §7.4, §13 linha 4 · **Decisão provisória:** L-19

**História.** Como paciente, quero jogar mesmo sem internet, para que a sessão não pare por causa da rede.

**Contexto.** Conexão com a API. Sem a API, o jogo não tem conexão: o provedor local
(US-08.1 do ABD) e o registro em arquivo (L-19) já são o modo sem rede. Esta história é o que muda quando o cliente existe.

**Critérios de aceite**
- [ ] L-19 — sem resposta em 1 s, a fase seguinte **usa** o provedor local
- [ ] L-19 — a telemetria **fica** numa fila local e **não se perde**
- [ ] L-19 — quando a rede volta, a fila **é reenviada** sem duplicar

**Cenário 1:** **Dado** a rede caindo no meio, **quando** a fase termina, **então** a partida segue pelo provedor local.
**Cenário 2:** **Dado** a rede voltando, **quando** o cliente tenta de novo, **então** a fila esvazia uma vez só.

`user-story` `domain:backend` `priority:p2` `sp:3`

#### US-08.8 — Recompensa e ajuste da política

**Epic:** EP-08 · **Perfil:** pesquisador · **SP:** 5 · **Prioridade:** P2 · **Milestone:** Conexão com a API · **Horas:** 5 h · **Seções:** §5.3.1, §7.4 · **Decisão provisória:** L-07 · depende do US-08.5

**História.** Como pesquisador, quero que a política aprenda com a recompensa das sessões, para que a adaptação
melhore com o uso.

**Contexto.** Conexão com a API, no servidor do US-08.4.

**Critérios de aceite**
- [ ] §5.3.1 — a recompensa **favorece** partidas longas sem falhas consecutivas
- [ ] §5.3.1 — a recompensa **penaliza** zeradas consecutivas e abandono
- [ ] §5.3.1 — a política **muda** a escolha da ação com as sessões, pelo método do SPIKE-03

**Cenário 1:** **Dado** sessões longas sem falha, **quando** a política aprende, **então** mantém a carga que as produziu.
**Cenário 2:** **Dado** falhas consecutivas, **quando** a política aprende, **então** passa a facilitar mais cedo.

`user-story` `domain:ai` `priority:p2` `sp:5` `needs-spike`

#### SPIKE-02 — Latência das rotas REST (L-04)

**Epic:** EP-08 · **Time-box:** 4 h · **Prioridade:** P2 · **Milestone:** Conexão com a API · **Seções:** §13 linha 4 · **Decisão provisória:** L-04

**Pergunta.** O p95 de ida e volta das rotas passa de 300 ms (o limiar da L-04)?

**Critérios de aceite**
- [ ] §13 linha 4 — o script **mede** p50 e p95 em 100 idas e voltas, no servidor local
- [ ] **para o pesquisador:** registrado na issue: a medida repetida no servidor publicado, ou esperando o local de hospedagem
- [ ] L-04 — a escolha entre REST e WebSocket **está registrada** no SGDD §13

**Cenário:** **Dado** o servidor no ar, **quando** o script roda, **então** p50 e p95 ficam gravados e a escolha sai deles.

**Saída.** Os números no SGDD §13 e a escolha entre REST e WebSocket.

`spike` `domain:backend` `priority:p2`

#### SPIKE-03 — Método da política adaptativa (L-07)

**Epic:** EP-08 · **Time-box:** 8 h · **Prioridade:** P2 · **Milestone:** Conexão com a API · **Seções:** §5.3.1 · **Decisão provisória:** L-07

**Pergunta.** Regras, bandido ε-greedy ou aprendizado por reforço (citado na §5.3.1): qual cabe nos dados de uma
sessão e nas regras de borda?

**Critérios de aceite**
- [ ] §5.3.1 — os três métodos **são comparados** em sessões sintéticas geradas dos registros do US-05.1
- [ ] o ADR **registra** o método e o porquê
- [ ] o US-08.5 e o US-08.8 **são reestimados**

**Cenário:** **Dado** sessões sintéticas, **quando** rodo os três métodos, **então** o ADR diz qual manteve a criança na zona de desafio sem violar as bordas.

**Saída.** ADR com o método; US-08.5 e US-08.8 reestimados.

`spike` `domain:ai` `priority:p2`

#### US-08.11 — Exportação e auditoria no servidor

**Epic:** EP-08 · **Perfil:** pesquisador · **SP:** 1 · **Prioridade:** P2 · **Milestone:** Conexão com a API · **Horas:** 4 h · **Seções:** §3.2, §7.4 · **Decisão provisória:** L-16

**História.** Como pesquisador, quero exportar os dados do servidor com cada acesso registrado, para analisar as
sessões de todos os aparelhos e responder a uma auditoria.

**Contexto.** Conexão com a API. O jogo não exporta (a US-10.3, exportação anonimizada, foi cortada pelo orientador
em 26/11/2026) nem tem log de auditoria (saiu com o EP-09): a exportação e o log ficam só no servidor, nesta história.

**Critérios de aceite**
- [ ] `context-ciatec.md` — toda leitura e exportação no servidor **gera** uma linha no log, com quem, quando e o quê
- [ ] §3.2 — a rota de exportação **sai** sem identificador direto
- [ ] a exportação **passa** pelo log de auditoria

**Cenário 1:** **Dado** uma exportação no servidor, **quando** ela termina, **então** há uma linha no log com o filtro usado.
**Cenário 2:** **Dado** uma leitura dos dados, **quando** ela termina, **então** há uma linha no log.

`user-story` `domain:backend` `priority:p2` `sp:1`

## 5 Tasks

| Task | Story | O que fazer (dono) | Camada | h | Depende de | Pronta quando |
| --- | --- | --- | --- | --- | --- | --- |
| TASK-140 | US-08.3 | [agente] `TelemetryClient` (UnityWebRequest, JSON, tempo limite de 1 s, URL por configuração), um `IPhaseParameterProvider` (T-08.1.1 do ABD): envia o estado da fase e recebe os parâmetros da seguinte, só entre fases e antes da reescuta, pelo contrato da TASK-196 | platform | 3 | TASK-196, T-08.1.1 | o cliente fala com o serviço local no Play |
| TASK-141 | US-08.3 | [agente] Serviço adaptativo falso no Unity (`IAdaptiveService` de teste), para os testes do cliente sem o servidor no ar | tests | 2 | TASK-140 | os testes do cliente rodam contra o serviço falso |
| TASK-142 | US-08.3 | [agente] O cliente entrega os parâmetros recebidos ao `PhaseParameterApplier` (T-08.1.2 do ABD), que recusa o fora da faixa e passa pela trava; a origem `server` vai para o registro | gameplay | 1 | TASK-140, T-08.1.2 | EditMode verde |
| TASK-143 | US-08.3 | [agente] PlayMode com atraso simulado de 2 s: o tempo de reação registrado não muda (medido pelo `dspTime` local) | tests | 1 | TASK-141 | teste verde, executado |
| TASK-199 | US-08.3 | [agente] O cliente só envia com o envio ligado na configuração (desligado por padrão; o consentimento é tratado fora do jogo); desligado, nada sai do aparelho; PlayMode dos dois casos | platform | 2 | TASK-140 | teste verde, executado |
| TASK-144 | US-08.4 | [agente] Serviço FastAPI em `Server/` no repositório do jogo (L-07): `POST /sessions`, `POST /sessions/{id}/phases`, `GET /health`, validando pelo contrato da TASK-196 | backend | 4 | TASK-196 | o serviço sobe local e responde |
| TASK-145 | US-08.4 | [agente] pytest das rotas: válido → 200 com parâmetros; inválido → 422 com o campo | tests | 2 | TASK-144 | pytest verde, executado |
| TASK-146 | US-08.4 | [agente] Dockerfile e instruções de publicação; o local de hospedagem fica a definir (o SGDD sugere research.ciatec.org), e a publicação é do pesquisador | infra | 1 | TASK-144 | a imagem sobe local |
| TASK-196 | US-08.4 | [agente] Contrato da API em JSON Schema versionado (`session`, `phase_result`, `next_phase_params`) em `Docs/api/`, derivado do formato do registro local (T-05.1.4); linha da L-04 proposta ao SGDD §13 | docs | 2 | T-05.1.4 | schema no repositório |
| TASK-200 | US-08.4 | [agente] Varredura de campos proibidos no servidor (nome, documento, data de nascimento), com pytest: payload com `nome` → 422 | backend | 1 | TASK-144 | pytest verde, executado |
| TASK-147 | US-08.5 | [agente] Estado a partir do resultado da fase: tempo de resposta médio, acertos contínuos, tentativas gastas | ai | 2 | TASK-144 | pytest verde |
| TASK-148 | US-08.5 | [agente] Política provisória (L-07): as regras da seção 0 (borda, piso em N=0, BPM que só desce, tentativas, expansão, avaliação inicial, S3) com exploração ε-greedy entre subir N, subir BPM, manter e facilitar, filtrada pelas regras e pelas travas | ai | 3 | TASK-147, TASK-165 | pytest verde |
| TASK-149 | US-08.5 | [agente] pytest das regras da seção 0: 3 fases a 100% → N+1; duas zeradas → BPM −20, em 60 → N −1, no piso → N=0 até três acertos; o BPM nunca sobe; tentativas +1/−1 na faixa 3–5; engajado → +1 bloco até 9 (S1) e 7 (S2); avaliação abaixo de 50% → N=0; trava de N → a ação nunca sobe N | tests | 2 | TASK-148 | pytest verde, executado |
| TASK-153 | US-08.7 | [agente] Sem resposta em 1 s, a fase seguinte usa o provedor local (T-08.1.3 do ABD); a telemetria fica numa fila local persistida | platform | 2 | TASK-140, T-08.1.3 | a partida segue sem rede no Play |
| TASK-154 | US-08.7 | [agente] Reenvio da fila quando a rede volta, com id idempotente | platform | 1 | TASK-153 | a fila esvazia no Play |
| TASK-155 | US-08.7 | [agente] PlayMode com o serviço falso: desligado no meio → a partida segue; religado → a fila esvazia sem duplicar | tests | 1 | TASK-154 | teste verde, executado |
| TASK-156 | US-08.8 | [agente] Recompensa (§5.3.1): + por fase concluída sem zerar, − por zeradas consecutivas e abandono; atualização da política por perfil | ai | 3 | TASK-148 | pytest verde |
| TASK-157 | US-08.8 | [agente] pytest com sessões sintéticas: longas sem falha mantêm a carga; falhas consecutivas fazem facilitar mais cedo | tests | 2 | TASK-156 | pytest verde, executado |
| TASK-162 | SPIKE-02 | [agente] Script de medida: 100 idas e voltas das rotas, p50 e p95, com o servidor local e com o publicado | tests | 2 | TASK-144 | números gravados |
| TASK-163 | SPIKE-02 | [aluno] Registrar os números no SGDD §13 e decidir REST ou WebSocket pelo limiar da L-04 | research | 2 | TASK-162 | linha da L-04 atualizada no SGDD |
| TASK-164 | SPIKE-03 | [agente] Comparar regras, bandido ε-greedy e aprendizado por reforço em sessões sintéticas geradas dos registros do US-05.1 | ai | 6 | T-05.1.1 | notebook com a comparação |
| TASK-165 | SPIKE-03 | [aluno] ADR com o método escolhido; reestimar o US-08.5 e o US-08.8 | docs | 2 | TASK-164 | ADR no repositório |
| TASK-182 | US-08.11 | [agente] Rota de exportação no servidor, passando pelo middleware de auditoria | backend | 1 | TASK-197 | pytest verde |
| TASK-197 | US-08.11 | [agente] Middleware de auditoria no FastAPI: toda leitura e exportação no servidor grava quem, quando e o quê | backend | 2 | TASK-144 | pytest verde |
| TASK-198 | US-08.11 | [agente] pytest: leitura e exportação no servidor geram linha no log; a exportação não tem identificador | tests | 1 | TASK-197, TASK-182 | pytest verde, executado |

**Total: 25 tasks (23 [agente], 2 [aluno]), 51 h.**

## 6 Linhas da validação final (seção 12 do ABD)

| Requisito | O que se olha | História | Evidência (teste) | Resultado (vi / não vi / não dava) | Valor visto |
| --- | --- | --- | --- | --- | --- |
| §5.3.1 | a política lê o estado, escolhe a ação e aprende com a recompensa, dentro das bordas | US-08.5, US-08.8 | | | |
| §7.4 | o servidor FastAPI recebe a telemetria e devolve a fase | US-08.4 | | | |
| §7.4, L-19 | sem rede, a partida segue e a telemetria é reenviada depois | US-08.7 | | | |
| §13 linha 4, L-04 | latência medida; o tempo de reação não muda com atraso de rede | US-08.3, SPIKE-02 | | | |
| §5.3, seção 0 | o servidor executa as regras da seção 0 e devolve os parâmetros; o jogo os aplica pela interface da US-08.1 | US-08.5, US-08.3 | | | |
| **RT-10** | o cliente envia a telemetria em JSON por REST e recebe a fase seguinte | US-08.3 | | | |

## 7 Linhas do CSV de issues (como estavam)

```csv
"title","type","epic_id","domain","priority","story_points","sprint","milestone","assignee","parent_id","estimate_h","labels","blocked_by"
"[US-08.3] Cliente REST no Unity (RT-10)","user-story","EP-08","backend","p2","3","","Conexão com a API","","EP-08","","user-story domain:backend priority:p2 sp:3","US-06.2, US-08.4, US-08.1"
"[US-08.4] Serviço FastAPI e contrato da API","user-story","EP-08","backend","p2","5","","Conexão com a API","","EP-08","","user-story domain:backend priority:p2 sp:5","US-05.1"
"[US-08.5] Política adaptativa no servidor: estado e ação","user-story","EP-08","ai","p2","3","","Conexão com a API","","EP-08","","user-story domain:ai priority:p2 sp:3 needs-spike","US-08.4, SPIKE-03"
"[US-08.7] Jogar sem servidor, com a fila reenviada","user-story","EP-08","backend","p2","3","","Conexão com a API","","EP-08","","user-story domain:backend priority:p2 sp:3","US-08.3, US-08.1"
"[US-08.8] Recompensa e ajuste da política","user-story","EP-08","ai","p2","5","","Conexão com a API","","EP-08","","user-story domain:ai priority:p2 sp:5 needs-spike","US-08.5"
"[SPIKE-02] Latência das rotas REST (L-04)","spike","EP-08","backend","p2","","","Conexão com a API","","EP-08","","spike domain:backend priority:p2","US-08.4"
"[SPIKE-03] Método da política adaptativa (L-07)","spike","EP-08","ai","p2","","","Conexão com a API","","EP-08","","spike domain:ai priority:p2","US-05.1"
"[US-08.11] Exportação e auditoria no servidor","user-story","EP-08","backend","p2","1","","Conexão com a API","","EP-08","","user-story domain:backend priority:p2 sp:1","US-08.4"
"[TASK-140] `TelemetryClient` (UnityWebRequest, JSON, tempo limite de 1 s, URL por configuração), um `IPhaseParameterProvider` (T-08.1.1 do ABD): envia o estado da fase e recebe os parâmetros da seguinte, só entre fases e antes da reescuta, pelo contrato da TASK-196","task","EP-08","backend","p2","","","Conexão com a API","","US-08.3","3","task layer:platform priority:p2","TASK-196, T-08.1.1"
"[TASK-141] Serviço adaptativo falso no Unity (`IAdaptiveService` de teste), para os testes do cliente sem o servidor no ar","task","EP-08","backend","p2","","","Conexão com a API","","US-08.3","2","task layer:tests priority:p2","TASK-140"
"[TASK-142] O cliente entrega os parâmetros recebidos ao `PhaseParameterApplier` (T-08.1.2 do ABD), que recusa o fora da faixa e passa pela trava; a origem `server` vai para o registro","task","EP-08","backend","p2","","","Conexão com a API","","US-08.3","1","task layer:gameplay priority:p2","TASK-140, T-08.1.2"
"[TASK-143] PlayMode com atraso simulado de 2 s: o tempo de reação registrado não muda (medido pelo `dspTime` local)","task","EP-08","backend","p2","","","Conexão com a API","","US-08.3","1","task layer:tests priority:p2","TASK-141"
"[TASK-144] Serviço FastAPI em `Server/` no repositório do jogo (L-07): `POST /sessions`, `POST /sessions/{id}/phases`, `GET /health`, validando pelo contrato da TASK-196","task","EP-08","backend","p2","","","Conexão com a API","","US-08.4","4","task layer:backend priority:p2","TASK-196"
"[TASK-145] pytest das rotas: válido → 200 com parâmetros; inválido → 422 com o campo","task","EP-08","backend","p2","","","Conexão com a API","","US-08.4","2","task layer:tests priority:p2","TASK-144"
"[TASK-146] Dockerfile e instruções de publicação; o local de hospedagem fica a definir (o SGDD sugere research.ciatec.org), e a publicação é do pesquisador","task","EP-08","backend","p2","","","Conexão com a API","","US-08.4","1","task layer:infra priority:p2","TASK-144"
"[TASK-147] Estado a partir do resultado da fase: tempo de resposta médio, acertos contínuos, tentativas gastas","task","EP-08","ai","p2","","","Conexão com a API","","US-08.5","2","task layer:ai priority:p2","TASK-144"
"[TASK-148] Política provisória (L-07): as regras da seção 0 (borda, piso em N=0, BPM que só desce, tentativas, expansão, avaliação inicial, S3) com exploração ε-greedy entre subir N, subir BPM, manter e facilitar, filtrada pelas regras e pelas travas","task","EP-08","ai","p2","","","Conexão com a API","","US-08.5","3","task layer:ai priority:p2","TASK-147, TASK-165"
"[TASK-149] pytest das regras da seção 0: 3 fases a 100% → N+1; duas zeradas → BPM −20, em 60 → N −1, no piso → N=0 até três acertos; o BPM nunca sobe; tentativas +1/−1 na faixa 3–5; engajado → +1 bloco até 9 (S1) e 7 (S2); avaliação abaixo de 50% → N=0; trava de N → a ação nunca sobe N","task","EP-08","ai","p2","","","Conexão com a API","","US-08.5","2","task layer:tests priority:p2","TASK-148"
"[TASK-153] Sem resposta em 1 s, a fase seguinte usa o provedor local (T-08.1.3 do ABD); a telemetria fica numa fila local persistida","task","EP-08","backend","p2","","","Conexão com a API","","US-08.7","2","task layer:platform priority:p2","TASK-140, T-08.1.3"
"[TASK-154] Reenvio da fila quando a rede volta, com id idempotente","task","EP-08","backend","p2","","","Conexão com a API","","US-08.7","1","task layer:platform priority:p2","TASK-153"
"[TASK-155] PlayMode com o serviço falso: desligado no meio → a partida segue; religado → a fila esvazia sem duplicar","task","EP-08","backend","p2","","","Conexão com a API","","US-08.7","1","task layer:tests priority:p2","TASK-154"
"[TASK-156] Recompensa (§5.3.1): + por fase concluída sem zerar, − por zeradas consecutivas e abandono; atualização da política por perfil","task","EP-08","ai","p2","","","Conexão com a API","","US-08.8","3","task layer:ai priority:p2","TASK-148"
"[TASK-157] pytest com sessões sintéticas: longas sem falha mantêm a carga; falhas consecutivas fazem facilitar mais cedo","task","EP-08","ai","p2","","","Conexão com a API","","US-08.8","2","task layer:tests priority:p2","TASK-156"
"[TASK-162] Script de medida: 100 idas e voltas das rotas, p50 e p95, com o servidor local e com o publicado","task","EP-08","backend","p2","","","Conexão com a API","","SPIKE-02","2","task layer:tests priority:p2","TASK-144"
"[TASK-163] Registrar os números no SGDD §13 e decidir REST ou WebSocket pelo limiar da L-04","task","EP-08","backend","p2","","","Conexão com a API","","SPIKE-02","2","task layer:research priority:p2","TASK-162"
"[TASK-164] Comparar regras, bandido ε-greedy e aprendizado por reforço em sessões sintéticas geradas dos registros do US-05.1","task","EP-08","ai","p2","","","Conexão com a API","","SPIKE-03","6","task layer:ai priority:p2","T-05.1.1"
"[TASK-165] ADR com o método escolhido; reestimar o US-08.5 e o US-08.8","task","EP-08","ai","p2","","","Conexão com a API","","SPIKE-03","2","task layer:docs priority:p2","TASK-164"
"[TASK-182] Rota de exportação no servidor, passando pelo middleware de auditoria","task","EP-08","backend","p2","","","Conexão com a API","","US-08.11","1","task layer:backend priority:p2","TASK-197"
"[TASK-196] Contrato da API em JSON Schema versionado (`session`, `phase_result`, `next_phase_params`) em `Docs/api/`, derivado do formato do registro local (T-05.1.4); linha da L-04 proposta ao SGDD §13","task","EP-08","backend","p2","","","Conexão com a API","","US-08.4","2","task layer:docs priority:p2","T-05.1.4"
"[TASK-197] Middleware de auditoria no FastAPI: toda leitura e exportação no servidor grava quem, quando e o quê","task","EP-08","backend","p2","","","Conexão com a API","","US-08.11","2","task layer:backend priority:p2","TASK-144"
"[TASK-198] pytest: leitura e exportação no servidor geram linha no log; a exportação não tem identificador","task","EP-08","backend","p2","","","Conexão com a API","","US-08.11","1","task layer:tests priority:p2","TASK-197, TASK-182"
"[TASK-199] O cliente só envia com o envio ligado na configuração (desligado por padrão; o consentimento é tratado fora do jogo); desligado, nada sai do aparelho; PlayMode dos dois casos","task","EP-08","backend","p2","","","Conexão com a API","","US-08.3","2","task layer:platform priority:p2","TASK-140"
"[TASK-200] Varredura de campos proibidos no servidor (nome, documento, data de nascimento), com pytest: payload com `nome` → 422","task","EP-08","backend","p2","","","Conexão com a API","","US-08.4","1","task layer:backend priority:p2","TASK-144"
```
