---
name: self-consistency
description: Gera múltiplas soluções independentes para o mesmo problema e seleciona a resposta mais consistente entre elas, geralmente por votação (self-consistency). Use quando o usuário pedir "self-consistency", "autoconsistência", "várias soluções", "confirme por votação", ou em problemas de raciocínio onde um único caminho possa errar e a confiabilidade importe.
---

# Self-consistency

Gerar **múltiplas soluções para o mesmo problema** e selecionar a resposta **mais consistente entre elas**, geralmente por votação.

## Quando usar
- Problemas de raciocínio, cálculo ou lógica em que um único caminho pode conter erros.
- Decisões em que a confiabilidade da resposta final é importante.
- Há mais de uma forma plausível de resolver o problema.

## Quando NÃO usar
- Tarefas subjetivas ou criativas sem uma resposta "correta".
- Tarefas simples, em que o custo de várias tentativas não compensa.

## Como aplicar
1. Defina o problema e o formato da resposta final (para que possam ser comparadas).
2. Resolva o problema **de forma independente N vezes** (padrão: N = 3 a 5), variando a abordagem/ordem de raciocínio. Cada solução deve usar `chain-of-thought` e **não** reaproveitar conclusões das anteriores.
3. Extraia a resposta final de cada solução.
4. Faça a votação: a resposta mais frequente vence.
5. Em caso de empate ou divergência grande, analise onde os caminhos divergem, identifique qual contém erro e decida com justificativa.
6. Informe o resultado com o nível de concordância (ex.: 4 de 5).

## Estrutura de saída
```
## Soluções independentes
### Solução 1
<raciocínio resumido> → Resposta: X
### Solução 2
<raciocínio resumido> → Resposta: Y
### Solução 3
<raciocínio resumido> → Resposta: X

## Votação
X: 2 votos | Y: 1 voto

## Resposta final
X (concordância: 2 de 3)
<observação sobre a divergência, se houver>
```

## Boas práticas
- Diversifique as abordagens; soluções idênticas não agregam confiança.
- Baixa concordância é um sinal de que o problema é ambíguo: peça esclarecimento ao usuário.
