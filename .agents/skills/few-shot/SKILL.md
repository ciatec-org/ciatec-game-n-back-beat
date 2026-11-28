---
name: few-shot
description: Orienta a execução de uma tarefa fornecendo alguns exemplos de entradas e saídas esperadas (few-shot prompting). Use quando o usuário pedir "few-shot", "com exemplos", ou quando o formato, estilo ou critério de saída precisar ser seguido de forma consistente e for difícil de descrever apenas em palavras.
---

# Few-shot

Fornecer **alguns exemplos de entradas e saídas esperadas** para orientar o modelo na execução da tarefa.

## Quando usar
- O formato de saída é específico, padronizado ou incomum.
- O critério de decisão (classificação, estilo, tom) é difícil de explicar em texto.
- Respostas zero-shot saíram inconsistentes.

## Quando NÃO usar
- A tarefa é trivial e uma instrução clara basta (prefira `zero-shot`).
- Os exemplos consumiriam contexto demais sem ganho real.

## Como aplicar
1. Defina a tarefa em uma frase.
2. Reúna de 2 a 5 exemplos (use os fornecidos pelo usuário; se não houver, peça ou proponha e confirme).
3. Garanta que os exemplos sejam **diversos** (cubram casos distintos, incluindo um caso limite) e **consistentes** entre si no formato.
4. Mantenha exatamente o mesmo formato em todos os exemplos.
5. Apresente a nova entrada no mesmo formato, deixando a saída em aberto.
6. Gere a saída seguindo o padrão dos exemplos, sem comentários extras.

## Estrutura do prompt
```
<Descrição da tarefa>

Entrada: <exemplo 1>
Saída: <saída 1>

Entrada: <exemplo 2>
Saída: <saída 2>

Entrada: <exemplo 3>
Saída: <saída 3>

Entrada: <nova entrada>
Saída:
```

## Exemplo
```
Converta a mensagem de commit informal em Conventional Commits.

Entrada: arrumei o bug do login
Saída: fix(auth): corrige falha no login

Entrada: adicionei página de perfil
Saída: feat(profile): adiciona página de perfil

Entrada: atualizei o readme
Saída: docs: atualiza README

Entrada: removi código morto do carrinho
Saída:
```

## Boas práticas
- Evite exemplos que induzam viés (ex.: todos com a mesma classe).
- Não misture formatos diferentes entre exemplos.
- Se o resultado destoar dos exemplos, revise os exemplos antes de alterar a instrução.
