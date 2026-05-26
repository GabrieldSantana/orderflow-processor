# OrderFlow Processor

Sistema de processamento assíncrono de pedidos desenvolvido com ASP.NET Core, RabbitMQ e Worker Services, utilizando arquitetura orientada a eventos.

---

## 📌 Objetivo

Este projeto tem como objetivo demonstrar conceitos modernos de backend utilizando .NET, com foco em:

- Arquitetura em camadas
- Processamento assíncrono
- Mensageria com RabbitMQ
- Comunicação orientada a eventos
- Worker Services
- Dependency Injection
- Repository Pattern
- Controle de concorrência com SemaphoreSlim
- Resiliência com Polly
- Cache com Redis
- Observabilidade
- Testes unitários e de integração

---

## 🛠️ Tecnologias Utilizadas

- ASP.NET Core 8
- Worker Services
- RabbitMQ
- Docker
- Swagger
- xUnit
- FluentAssertions
- Dependency Injection
- Repository Pattern

---

## 🏗️ Estrutura do Projeto

```text
src/
├── OrderFlow.API
├── OrderFlow.Worker
├── OrderFlow.Application
├── OrderFlow.Domain
└── OrderFlow.Infrastructure

tests/
├── OrderFlow.UnitTests
└── OrderFlow.IntegrationTests
```

---

## 🔄 Fluxo da Aplicação

1. A API recebe a criação de um pedido.
2. Um evento `OrderCreatedEvent` é publicado no RabbitMQ.
3. O Worker consome a mensagem da fila.
4. O pedido é processado de forma assíncrona.

---

## ▶️ Como Executar o Projeto

### Pré-requisitos

Antes de iniciar, certifique-se de possuir instalado:

- .NET 8 SDK
- Docker Desktop

---

### 1. Clonar o repositório

```bash
git clone <URL_DO_REPOSITORIO>
cd OrderFlow
```

---

### 2. Restaurar as dependências

```bash
dotnet restore
```

---

### 3. Subir o RabbitMQ com Docker

```bash
docker run -d --name rabbitmq -p 5672:5672 -p 15672:15672 rabbitmq:3-management
```

Painel de gerenciamento:

```text
http://localhost:15672
```

Credenciais padrão:

```text
Usuário: guest
Senha: guest
```

---

### 4. Executar o Worker

Abra um terminal:

```bash
cd src/OrderFlow.Worker
dotnet run
```

---

### 5. Executar a API

Abra outro terminal:

```bash
cd src/OrderFlow.API
dotnet run
```

---

### 6. Acessar o Swagger

Após iniciar a API, acesse:

```text
http://localhost:5056/swagger
```

A porta pode variar dependendo do ambiente.

---

## 📬 Exemplo de Requisição

### Criar Pedido

**POST** `/api/orders`

```json
{
  "customerEmail": "customer@test.com",
  "totalAmount": 120.50
}
```

---

## 📦 Exemplo do Fluxo de Mensageria

### Evento publicado

```json
{
  "orderId": "7f5a4f8c-3d88-4e35-9db3-b6cb53a0d8e7",
  "customerEmail": "customer@test.com",
  "totalAmount": 120.50
}
```

### Consumidor processando

```text
Processing order event: 7f5a4f8c-3d88-4e35-9db3-b6cb53a0d8e7
```

---

## 🧠 Conceitos Aplicados

### Arquitetura em Camadas

Separação de responsabilidades entre:

- API
- Application
- Domain
- Infrastructure
- Worker

---

### Processamento Assíncrono

Os pedidos são enviados para uma fila RabbitMQ e processados posteriormente pelo Worker Service.

---

### Encapsulamento de Regras de Negócio

As regras de mudança de estado do pedido ficam centralizadas na própria entidade `Order`, evitando alterações inválidas diretamente pela aplicação.

---

### Dependency Injection

Toda a resolução de dependências é realizada através do container nativo do ASP.NET Core.

---

## 🚧 Status do Projeto

Funcionalidades implementadas:

- Criação de pedidos
- Swagger
- RabbitMQ Publisher
- Worker Consumer
- Comunicação assíncrona
- Arquitetura em camadas
- Repository Pattern

Próximos passos:

- Retry Policies com Polly
- Redis Cache
- Observabilidade
- Logs estruturados
- Testes automatizados
- Dead Letter Queue
- Processamento concorrente com SemaphoreSlim

---

## 📚 Aprendizados do Projeto

Este projeto foi desenvolvido com foco em aprofundamento prático nos seguintes tópicos:

- Mensageria
- Arquitetura orientada a eventos
- Background Services
- Concorrência
- Resiliência
- Boas práticas de backend com .NET

---

## 📄 Licença

Este projeto foi desenvolvido para fins de estudo e aprendizado.