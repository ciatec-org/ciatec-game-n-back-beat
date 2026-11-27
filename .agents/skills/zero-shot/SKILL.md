---
name: zero-shot
description: Executa uma tarefa diretamente, sem exemplos de como realizá-la (zero-shot prompting). Use quando o usuário pedir "zero-shot", "sem exemplos", ou quando a tarefa for simples, bem definida e o modelo já souber fazê-la apenas com uma instrução clara.
---

# Zero-shot

Solicitar ao modelo que execute uma tarefa **sem fornecer exemplos** de como realizá-la.

## Quando usar
- A tarefa é comum, simples e bem definida (resumir, traduzir, classificar, explicar código).
- Não há exemplos disponíveis ou o formato de saída é óbvio.
- Quer-se uma resposta rápida e com baixo custo de contexto.

## Quando NÃO usar
- O formato de saída é muito específico ou fora do padrão (prefira `few-shot`).
- A tarefa exige raciocínio em várias etapas (prefira `chain-of-thought`).

## Como aplicar
1. Identifique o objetivo exato da tarefa.
2. Escreva uma instrução direta, clara e sem ambiguidade.
3. Especifique explicitamente: formato de saída, idioma, tamanho e restrições.
4. Não inclua exemplos de entrada/saída.
5. Execute a tarefa e entregue o resultado.

## Estrutura do prompt
```
<Instrução clara do que fazer>
<Restrições: formato, tamanho, idioma, tom>

<Entrada>
```

## Exemplo
```
Classifique o sentimento do texto abaixo como "positivo", "negativo" ou "neutro".
Responda apenas com uma dessas três palavras.

Texto: "A entrega atrasou, mas o atendimento resolveu rápido."
```

## Checklist
- [ ] A instrução tem um único objetivo claro?
- [ ] O formato de saída está especificado?
- [ ] Nenhum exemplo foi necessário?
