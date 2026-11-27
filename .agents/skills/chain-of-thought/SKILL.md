---
name: chain-of-thought
description: Induz o modelo a produzir etapas intermediárias de raciocínio antes de apresentar a resposta final (CoT, Chain-of-Thought). Use quando o usuário pedir "passo a passo", "raciocine", "chain of thought", "CoT", ou em problemas de lógica, matemática, depuração e análise que exijam várias etapas de dedução.
---

# CoT (Chain-of-Thought)

Induzir o modelo a produzir **etapas intermediárias de raciocínio antes de apresentar a resposta final**.

## Quando usar
- Problemas de lógica, cálculo, planejamento ou análise com várias etapas.
- Depuração: rastrear causa raiz a partir de sintomas.
- Decisões com critérios e trade-offs que precisam ser justificados.

## Quando NÃO usar
- Perguntas diretas, factuais ou de uma única etapa.
- Quando o usuário pediu resposta curta e sem explicações.

## Como aplicar
1. Reescreva o problema com suas próprias palavras, identificando dados, incógnita e restrições.
2. Quebre o raciocínio em etapas numeradas, uma dedução por etapa.
3. Em cada etapa, mostre o que foi usado e o que foi concluído.
4. Verifique o resultado (reveja a conta, teste com um caso simples, confira restrições).
5. Apresente a **resposta final** separada e claramente identificada.

## Estrutura de saída
```
## Entendimento
<dados, incógnita, restrições>

## Raciocínio
1. <etapa 1 e conclusão parcial>
2. <etapa 2 e conclusão parcial>
3. ...

## Verificação
<checagem do resultado>

## Resposta final
<resposta objetiva>
```

## Exemplo
```
Pergunta: Um serviço processa 120 requisições/s por instância. O pico é de 1.500 req/s
e quero 25% de folga. Quantas instâncias?

Raciocínio:
1. Capacidade necessária com folga: 1.500 × 1,25 = 1.875 req/s.
2. Instâncias: 1.875 ÷ 120 = 15,625.
3. Arredondando para cima: 16.

Verificação: 16 × 120 = 1.920 ≥ 1.875.

Resposta final: 16 instâncias.
```

## Variante zero-shot CoT
Basta acrescentar à tarefa: "Pense passo a passo antes de responder."
