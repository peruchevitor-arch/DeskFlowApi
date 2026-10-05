# DeskFlow API

-Nome: Vitor Peruch
  
-Turma: backend-netv1-ciclo2

-Vídeo: https://drive.google.com/file/d/1HjaDZx3chaRY7THWd4qgo12KlzqqbCIJ/view?usp=drive_link

-obs:meu microfone esta com problemas e quebrado, não consegui providenciar peço desculpas se acaso não conseguirem entender o audio.

## Sobre o projeto

O DeskFlow API é uma API para gerenciamento de chamados de suporte de TI.

A ideia é ter um sistema onde seja possível cadastrar categorias, criar chamados, acompanhar o status dos chamados e registrar interações durante o atendimento.

## Tecnologias

* C#
* .NET 10
* ASP.NET Core Web API
* Entity Framework Core
* SQL Server
* Swagger
* Git e GitHub

## Estrutura do projeto

O projeto foi separado em algumas partes para organizar melhor o código.

* Controllers: recebem as requisições da API
* Services: ficam com as regras de negócio
* Repositories: fazem as operações com o banco
* Models: entidades e enums do sistema
* Context: configuração do Entity Framework e banco
* Middlewares: tratamento de erros
* Migrations: controle das alterações do banco

## Categorias

As categorias são usadas para organizar os chamados.

É possível:

* Criar categoria
* Listar categorias
* Buscar categoria por ID
* Atualizar categoria
* Excluir categoria

Não é permitido excluir uma categoria que esteja sendo usada por algum chamado.

## Chamados

Os chamados são a principal parte do sistema.

É possível:

* Criar chamado
* Listar chamados
* Buscar chamado por ID
* Atualizar chamado
* Excluir chamado
* Filtrar chamados
* Iniciar chamado
* Encerrar chamado

Quando um chamado é criado, ele começa com o status Aberto e recebe a data de abertura.

Os status usados são:

* Aberto
* EmAndamento
* Fechado

Quando o chamado é iniciado, passa para EmAndamento.

Quando é encerrado, é necessário informar a solução e o chamado passa para Fechado.

## Interações

As interações servem para registrar mensagens durante o atendimento de um chamado.

É possível:

* Criar interação
* Listar interações
* Buscar interação por ID
* Atualizar interação
* Excluir interação
* Listar as interações de um chamado

Não é permitido adicionar uma nova interação em um chamado que já foi fechado.

## Filtros

Os chamados podem ser filtrados usando parâmetros na URL.

Os filtros são:

* Status
* Prioridade
* Categoria

Também é possível combinar os filtros.

Exemplo:

`GET /api/chamados?status=Aberto&prioridade=Alta`

## Banco de dados

O projeto utiliza SQL Server com Entity Framework Core.

As tabelas principais são:

* Categorias
* Chamados
* Interacoes

Um chamado possui uma categoria e pode ter várias interações.

## Migrations

As alterações do banco são controladas através das migrations do Entity Framework.

Para atualizar o banco:

```bash
dotnet ef database update
```

## Tratamento de erros

O projeto possui um middleware para tratamento global de exceções.

Assim, quando acontece algum erro inesperado, a API retorna uma resposta organizada em vez de mostrar informações internas do sistema.

## Injeção de dependência

Os Services e Repositories são registrados no `Program.cs` usando injeção
## 🚀 Como Executar a Aplicação

### Pré-requisitos
- .NET SDK 10 (ou superior)
- SQL Server em execução (LocalDB, SQL Server Express ou Docker)

### Passo a Passo
1. Clone este repositório:
   git clone https://github.com/seu-usuario/deskflow-api.git

2. Acesse a pasta do projeto:
   cd deskflow-api/src/DeskFlow.API

3. Configure a Connection String no arquivo `appsettings.json`:
   "ConnectionStrings": {
     "DefaultConnection": "Server=localhost;Database=DeskFlowDb;Trusted_Connection=True;TrustServerCertificate=True;"
   }

4. Execute as Migrations para criar a estrutura no banco de dados:
   dotnet ef database update

5. Execute a API:
   dotnet run

6. Acesse a documentação do Swagger para testar os endpoints:
   https://localhost:7000/swagger
