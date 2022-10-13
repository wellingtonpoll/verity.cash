Teste Verity

## Resumo
- O teste consiste em expor 2 endpoints.
- Temos o insert de uma entidade que representa pagamentos (payment) onde ela é diferenciada por pagamentos de entrada (CashIn) e pagamentos de saida (CashOut).
- O relatório consolidado diário é uma consulta simples de filtro por data onde o retorno exibe o total de pagamentos CashIn e CashOut e um balanço entre os dois no dia em questão.
- A base de dados foi criada no Mongo Atlas utilizando uma assinatura gratuita.
