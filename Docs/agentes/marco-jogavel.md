# Fechar a story de marco

Cada milestone termina com uma **story de marco** (por exemplo, `US-M1`): a última a fechar, e a única que exige o
jogo inteiro rodando, montado, pelo caminho que o jogador percorre. Ela tem duas partes: a do agente e a da pessoa.

## Parte A — o que o agente fecha

1. **Suíte inteira:** o aluno roda todos os testes no Test Runner (EditMode e PlayMode). Falhou: corrija antes de
   seguir.
2. **Teste-robô:** um teste PlayMode (`Assets/Tests/PlayMode/RoboJogaTudoTests.cs`) abre a **cena de entrada** que o
   aluno montou (a primeira do Build Settings) e, com a entrada falsa e o relógio falso ou real (`testes.md`),
   percorre o caminho do jogador do menu ao fim: cada tela, fase e modo, pausa e volta, configurações, fim de sessão,
   registro gravado. Confere o estado em cada passo e falha no primeiro que não acontece.
3. **Requisitos:** percorra o ABD e marque cada requisito como:
   - **verificado pelo agente** (diga o teste);
   - **não acontece, e devia** → corrija agora, ou registre por que não deu;
   - **só uma pessoa verifica** → Parte B;
   - **nenhum caminho do jogo exercita isso** → avise o orientador.
4. **Perguntas abertas:** liste no topo da entrega toda lacuna `ABERTA` de `Docs/decisoes-provisorias.md`. O marco
   não fecha com lacuna de jogo sem resposta do desenvolvedor.

## Parte B — o que só uma pessoa fecha

A build é do aluno, no Editor. Jogar a build com o ABD na mão, conferir cada tela (layout, texto, cor, som),
playtest, piloto, CEP, aparelho real. O agente não marca nada disto como feito: entrega a lista do que olhar, onde no
jogo e o que se espera ver.

## Modelo da seção em `Docs/progresso.md`

```markdown
## Marco <ID> — <título>

### A. Fechado pelo agente
- Suíte inteira: <N> testes, <N> passaram (EditMode <n>, PlayMode <n>).
- Robô: `RoboJogaTudoTests` — <o caminho que ele percorre, em uma linha>; passou.
- Requisitos: <n> verificados, <n> corrigidos no marco, <n> sem caminho no jogo (listados abaixo).

### B. Para uma pessoa fechar
| Requisito | Onde no jogo | O que se espera ver |
|---|---|---|
| ... | ... | ... |
```
