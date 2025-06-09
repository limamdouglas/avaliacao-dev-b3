AvaliacaoDevCalculoCDB

Este projeto consiste em uma API desenvolvida em C# .NET 8 e um frontend em Angular 20 para realizar cálculos de investimentos em CDB (Certificado de Depósito Bancário). Ele foi projetado com arquitetura em camadas, promovendo a separação de responsabilidades e manutenção simplificada.

A aplicação backend está publicada no serviço de nuvem AWS App Runner, garantindo alta disponibilidade e escalabilidade automática.

1 - Estrutura do Projeto

A solução é composta por 5 projetos principais:

    - AvaliacaoDevCalculoCDB.Api: Contém a API Web com os endpoints REST.
    - AvaliacaoDevCalculoCDB.Application: Implementa a lógica de negócio e os serviços.
    - AvaliacaoDevCalculoCDB.Domain: Define as entidades, DTOs (Data Transfer Objects) e recursos compartilhados.
    - AvaliacaoDevCalculoCDB.Tests: Inclui testes unitários para validação do sistema.
    - Frontend Angular (fora da solução C#): Interface para o usuário interagir com o sistema.

2 - Tecnologias Utilizadas
- Backend:
    - C# .NET 8
    - ASP.NET Core
    - Arquitetura em camadas (API, Application, Domain)
    - Logging com ILogger
    - Testes unitários com XUnit

- Frontend:
    - Angular 20
    - HttpClient para consumo da API
	
- Docker: Utilizado para criar imagens padronizadas e consistentes para execução da aplicação em diferentes ambientes.

3 - Configuração e Execução
Requisitos:
  - .NET SDK 8.0 ou superior
  - Node.js 18 ou superior (para o Angular)

Backend

    Clone o repositório.
    Navegue até a pasta AvaliacaoDevCalculoCDB.Api.
    Execute o comando:
    dotnet run
    A API estará disponível em https://localhost:7176.
	
	Teste os endpoints diretamente pelo Postman no ambiente de desenvolvimento:

	Desenvolvimento: https://qdftdknygq.us-east-1.awsapprunner.com/api/v1/CdbInvestment/calculate
	
Frontend

    Navegue até a pasta do projeto Angular.
    Instale as dependências:
    npm install
    Inicie o servidor:
    ng serve
    Acesse a aplicação em http://localhost:4200.

4 - Funcionalidades

API Endpoints

  - POST /api/v1/CdbInvestment/calculate: Calcula os rendimentos de um investimento em CDB com base nos valores informados pelo usuário.

    Request Body:
    {
          "initialValue": 1000,
          "months": 12
    }

    Response Body:
    {
          "statusCode": 200,
          "message": "Calculation successful",
          "data": {
            "grossReturn": 1123.45,
            "netReturn": 1100.00
          }
    }

Frontend
  
  - Interface simples que permite o envio de dados (valor inicial e período) para a API.
  - Exibe os resultados calculados ou mensagens de erro.

5 - Testes

  Os testes unitários estão localizados no projeto AvaliacaoDevCalculoCDB.Tests.
  Para executar os testes:
  dotnet test

6 - Contato
  
  Em caso de dúvidas ou sugestões, entre em contato:
  
  Email: lima.mdouglas@gmail.com
