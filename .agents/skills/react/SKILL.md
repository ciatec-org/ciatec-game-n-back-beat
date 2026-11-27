---
name: react
description: Combina raciocínio e execução de ações (ReAct, Reason + Act), permitindo que o modelo use ferramentas, observe seus resultados e ajuste os próximos passos. Use quando o usuário pedir "ReAct", "pense e aja", "investigue", "use as ferramentas", ou quando a resposta depender de consultar arquivos, rodar comandos, buscar informações ou testar hipóteses no projeto.
---

# ReAct (Reasoning + Acting)

Combinar **raciocínio e execução de ações**, permitindo que o modelo **utilize ferramentas, observe seus resultados e ajuste os próximos passos**.

> Nota: não se refere à biblioteca React de front-end.

## Quando usar
- A resposta depende de informação que precisa ser obtida (ler arquivos, buscar no código, rodar testes, consultar a web).
- Investigação de bugs, exploração de código desconhecido, tarefas com ferramentas disponíveis na IDE.
- O plano precisa ser ajustado conforme o que for sendo descoberto.

## Quando NÃO usar
- A resposta pode ser dada apenas com o conhecimento já disponível na conversa.

## Como aplicar
Repita o ciclo **Pensamento → Ação → Observação** até concluir:

1. **Pensamento**: explique brevemente o que se sabe, o que falta saber e qual é a próxima ação mais útil.
2. **Ação**: execute **uma** ação com a ferramenta adequada (ler arquivo, buscar texto, rodar comando, executar teste).
3. **Observação**: leia o resultado real da ferramenta, sem presumir ou inventar saída.
4. **Ajuste**: com base na observação, confirme, descarte ou refine a hipótese e decida o próximo passo.
5. Encerre quando houver evidência suficiente e entregue a **resposta final** fundamentada nas observações.

## Regras
- Uma ação por ciclo, para que cada observação oriente a seguinte.
- Prefira ações de leitura/inspeção antes de ações que modificam arquivos ou o ambiente.
- Peça confirmação ao usuário antes de ações destrutivas ou irreversíveis.
- Se uma ação falhar, registre o erro, ajuste a abordagem e não repita a mesma ação às cegas.
- Defina um limite razoável de ciclos; se não houver progresso, informe o impasse ao usuário.

## Estrutura de saída
```
Pensamento 1: <o que sei / o que falta / próxima ação>
Ação 1: <ferramenta e parâmetros>
Observação 1: <resultado real>

Pensamento 2: <ajuste com base na observação>
Ação 2: ...
Observação 2: ...

...

Resposta final: <conclusão baseada nas observações>
```

## Exemplo
```
Pensamento 1: O erro cita `UserService.save`. Preciso ver onde está definido.
Ação 1: buscar "UserService" no projeto.
Observação 1: definido em src/services/user.ts, linha 42.

Pensamento 2: Vou ler o método para checar a validação do e-mail.
Ação 2: ler src/services/user.ts (linhas 30-80).
Observação 2: o método não trata e-mail nulo.

Resposta final: a falha ocorre porque `save` não valida e-mail nulo (user.ts:57). Correção sugerida: ...
```
