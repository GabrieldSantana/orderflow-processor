# OrderFlow Processor

Sistema de processamento assíncrono de pedidos desenvolvido com .NET.

## 📌 Objetivo

Este projeto tem como objetivo demonstrar:

- Arquitetura em camadas
- Processamento assíncrono com Worker Service
- Mensageria com RabbitMQ
- Resiliência com Polly
- Controle de concorrência com SemaphoreSlim
- Cache com Redis
- Observabilidade
- Testes unitários e de integração

## 🏗️ Estrutura do Projeto

```
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

## 🚀 Status
Em desenvolvimento.