# customer-management-app

> API para gerenciamento de clientes.
>

## Web Reference

- ASP.NET Core MVC CORE (.Net 8)
- AutoMapper 12.0.1
- Entity Framework Core 8.0
- Entity Framework Core SqlServer 8.0

## Database 📂

- SqlServer localdb

## Local Usage

**Pre requisitos**

- SDK do .NET 8
- Um editor de código .NET ou IDE (por exemplo, Visual Studio ou JetBrains Rider)

**Database**

Ao subir a aplicação será executado as migrations de forma automática, neste momento será criado as entidades na base de dados;

**Web**

Executar aplicação através do botão IIS EXPRESS do visual studio.

## In Progress

- Add UnitTests (controllers, extensions, repositories, etc)
- Add FluentValidation
- Criar `exceptions` customizadas;
- Centralizar as mensagem de erros em um resource;
- Melhorar mensagem de validação no web;
- Separar web x api
- Configurar database para rodar em docker/wsl2
