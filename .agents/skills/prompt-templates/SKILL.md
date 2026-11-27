---
name: prompt-templates
description: Cria e utiliza templates de prompt reutilizáveis, com partes fixas e variáveis preenchidas conforme a tarefa. Use quando o usuário pedir "template", "modelo de prompt", "prompt reutilizável", ou quando uma mesma tarefa for repetida com entradas diferentes e precisar de padronização.
---

# Templates

Utilizar **estruturas reutilizáveis de prompts**, com partes fixas e variáveis preenchidas conforme a tarefa.

## Quando usar
- A mesma tarefa se repete com entradas diferentes (code review, geração de testes, changelog, commits).
- É preciso padronizar qualidade e formato entre execuções ou entre pessoas.
- Deseja-se versionar e compartilhar prompts no projeto.

## Quando NÃO usar
- A tarefa é única e não será repetida.

## Como aplicar

### Para CRIAR um template
1. Identifique a tarefa recorrente.
2. Separe o que é **fixo** (instruções, formato, regras) do que **varia** (entradas).
3. Marque as variáveis com chaves duplas: `{{variavel}}`.
4. Dê nomes descritivos às variáveis e indique quais são obrigatórias ou opcionais.
5. Salve o template em um arquivo do projeto (sugestão: `.agents/templates/<nome>.md`).

### Para USAR um template
1. Localize o template adequado.
2. Liste as variáveis necessárias e preencha com os dados fornecidos.
3. Se alguma variável obrigatória estiver ausente, pergunte ao usuário.
4. Execute o prompt já preenchido.

## Anatomia de um template
```
# Template: <nome>

## Variáveis
- {{linguagem}} (obrigatória): linguagem do código
- {{codigo}} (obrigatória): trecho a ser analisado
- {{foco}} (opcional): aspecto a priorizar. Padrão: legibilidade

## Prompt
Revise o código {{linguagem}} abaixo com foco em {{foco}}.
Liste problemas por severidade (alta, média, baixa), com trecho afetado e correção sugerida.

Código:
{{codigo}}
```

## Boas práticas
- Mantenha a parte fixa enxuta e a saída esperada explícita.
- Evite variáveis demais; prefira poucas e bem nomeadas.
- Versione os templates junto com o projeto.
