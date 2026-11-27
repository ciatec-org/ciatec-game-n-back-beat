---
name: role-prompting
description: Atribui ao modelo um papel, perfil ou perspectiva para orientar o comportamento e as respostas (role prompting). Use quando o usuário pedir "aja como", "atue como", "role prompting", "na perspectiva de", ou quando o domínio exigir vocabulário, profundidade e postura de um especialista específico.
---

# Role prompting

Atribuir ao modelo **um papel, perfil ou perspectiva** para orientar o comportamento e as respostas.

## Quando usar
- A tarefa se beneficia de conhecimento, vocabulário e critérios de um especialista (ex.: revisor de código sênior, DBA, analista de segurança).
- Há necessidade de tom ou público-alvo específico (ex.: explicar para iniciantes).
- Deseja-se uma revisão sob um ponto de vista particular (ex.: "como um usuário final").

## Quando NÃO usar
- A tarefa é puramente factual e o papel não altera o resultado.
- O papel pedido conflita com a tarefa ou com segurança/ética.

## Como aplicar
1. Identifique o papel (quem), o contexto (onde/para quem) e o objetivo (o quê).
2. Descreva o perfil com: especialidade, nível de experiência, postura e tom.
3. Defina o público-alvo da resposta.
4. Declare prioridades e restrições do papel (o que enfatizar, o que evitar).
5. Responda **consistentemente** dentro do papel durante toda a tarefa.
6. Se faltar informação que o especialista normalmente exigiria, pergunte antes de assumir.

## Estrutura do prompt
```
Você é <papel>, com <experiência/especialidade>.
Seu público é <público-alvo>. Seu tom é <tom>.
Prioridades: <o que priorizar>. Evite: <o que evitar>.

Tarefa: <tarefa>
```

## Exemplo
```
Você é um engenheiro de software sênior especializado em segurança de aplicações web.
Seu público é um desenvolvedor pleno. Seu tom é direto e didático.
Priorize vulnerabilidades do OWASP Top 10. Evite sugestões genéricas sem justificativa.

Tarefa: revise o código abaixo e liste os problemas por severidade, com a correção sugerida.
```

## Boas práticas
- Papéis específicos funcionam melhor que genéricos ("revisor de PRs em Go" > "programador").
- O papel orienta a perspectiva, mas não substitui instruções claras de formato e objetivo.
- Combine com `few-shot` ou `prompt-templates` quando precisar de saídas padronizadas.
