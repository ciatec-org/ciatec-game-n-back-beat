---
name: task-decomposition
description: Divide uma tarefa complexa em subtarefas menores, resolvidas individualmente e combinadas para produzir o resultado final (decomposição de tarefas). Use quando o usuário pedir "decomponha", "quebre em etapas", "divida a tarefa", "planeje", ou quando a tarefa for grande, com várias partes, dependências ou múltiplas entregas.
---

# Decomposição de tarefas

Dividir uma **tarefa complexa em subtarefas menores**, resolvidas individualmente e **combinadas para produzir o resultado final**.

## Quando usar
- Tarefas grandes (novas features, refatorações, documentos longos, migrações).
- Há várias partes com dependências entre si.
- Uma única resposta ficaria superficial ou propensa a erros.

## Quando NÃO usar
- Tarefas pequenas, que podem ser resolvidas em um único passo.

## Como aplicar
1. **Entender**: reformule o objetivo final e o critério de "pronto".
2. **Decompor**: liste as subtarefas, cada uma pequena, com entrada e saída claras e verificável de forma independente.
3. **Ordenar**: identifique dependências e defina a sequência (indique o que pode ser feito em paralelo).
4. **Resolver**: execute uma subtarefa por vez, registrando o resultado de cada uma.
5. **Validar**: confira cada subresultado antes de seguir para a próxima.
6. **Combinar**: integre os resultados e verifique se o objetivo final foi atendido.
7. Se uma subtarefa se mostrar grande demais, decomponha-a novamente.

## Estrutura de saída
```
## Objetivo
<resultado final e critério de pronto>

## Plano
| # | Subtarefa | Depende de | Saída esperada |
|---|-----------|------------|----------------|
| 1 | ...       | -          | ...            |
| 2 | ...       | 1          | ...            |

## Execução
### 1. <subtarefa>
<resultado>
### 2. <subtarefa>
<resultado>

## Integração
<resultado final combinado e verificação contra o critério de pronto>
```

## Boas práticas
- Cada subtarefa deve ter um único propósito.
- Apresente o plano ao usuário antes de executar quando a tarefa for grande ou arriscada.
- Mantenha os resultados parciais acessíveis para a etapa de integração.
