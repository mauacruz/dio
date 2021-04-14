DIO.Bank

DIO.Bank é o projeto para a implementação para o desafio Criando uma aplicação de transferências bancárias com .NET.

É uma aplicação console, desenvolvida em C#, que possua um cadastro de Contas Correntes e execute ações como Sacar, Depositar e Transferir valores entre as contas.

### Tela principal

![](.\docs\images\1-TelaPrincipal.PNG)

A tela inicial da aplicação apresenta o menu de opções. 

As opções disponíveis são Inserir Conta, Transferir, Sacar, Depositar e Sair. O acesso às opções é feito através do número correspondente.

Na primeira vez que rodar a aplicação o cadastro de contas estará vazio. 

#### 1  - Inserir conta

Para inserir uma conta basta informar os valores, conforme o sistema for pedindo. A qualquer momento o usuário poderá digitar 'sair', o que cancelará a inclusão e fará com que a aplicação volte ao menu principal.

![](.\docs\images\1.1-InserirConta1.PNG)

As informações necessárias para inclusão da conta são:

- Nome - Nome do titular da conta.
- Credito - Valor de crédito disponível para a conta (caso exceda o valor do saldo).
- Saldo - O saldo inicial da conta
- Tipo - O tipo da conta, se é 1 - Física ou 2 - Jurídica.

![](.\docs\images\1.2-InserirConta2.PNG)