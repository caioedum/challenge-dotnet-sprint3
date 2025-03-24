# 🦷 ChallengeDotnet - ASP.NET Core Web API - Parrot Tech

## 👥 Integrantes do Grupo

- **Caio Eduardo Nascimento Martins - RM554025**
- **Julia Mariano Barsotti Ferreira - RM552713**
- **Leonardo Gaspar Saheb - RM553383**

## 📌 Descrição do Projeto

Esta API foi desenvolvida utilizando .NET 8 com arquitetura monolítica, integrando-se diretamente com um banco de dados Oracle.

🔹 O principal objetivo da API é fornecer funcionalidades para gerenciamento de usuários, atendimentos e previsões odontológicas.

## 🏗 Arquitetura Monolítica

A API segue uma arquitetura monolítica, onde todas as funcionalidades estão contidas dentro de um único código base. Essa abordagem simplifica o desenvolvimento e a manutenção, garantindo uma comunicação direta entre os componentes.

## 🔍 Principais características:

- ✅ Comunicação direta com Oracle Database para operações CRUD.
- ✅ Aplicação centralizada sem dependência de microsserviços.

## 🎨 Design Patterns Utilizados

1. **Repository Pattern**:
   - Abstração da camada de acesso a dados para facilitar testes e manutenção.
2. **Singleton**:
   - Garantia de que certas instâncias (como configuração do banco) sejam únicas durante o ciclo de vida da aplicação.
3. **Dependency Injection**:
   - Redução do acoplamento entre componentes por meio da injeção de dependências.

## 🛠 Tecnologias Utilizadas

- 🚀 .NET 8
- 💾 Entity Framework Core
- 🎯 Oracle Database
- 📜 Swagger (Documentação interativa da API)

## 🚀 Como Rodar a API Localmente

### 📌 Pré-requisitos

Certifique-se de ter instalado:

- ✅ .NET 8 SDK

- ✅ Visual Studio ou VS Code

## 📄 Passos para Execução

**1️⃣ Clone o repositório:**
```
git clone https://github.com/caioedum/challenge-dotnet-sprint3.git
```
```
cd challenge-dotnet-sprint3
```
```
cd WebApiChallenge
```
**2️⃣ Restaurar pacotes NuGet:**
```
dotnet restore
```
**3️⃣ Rodar a API:**
```
dotnet run
```
**4️⃣ Acesse a API no navegador ou via Postman:**

- **🔗 Endpoint padrão:**
```
https://localhost:7185
```
- **📜 Documentação Swagger:**
```
https://localhost:7185/swagger/index.html
```

## 📌 Endpoints da API

🔹 Endpoints:

### AtendimentosUsuarios

- GET /api/AtendimentosUsuarios - Retorna todos os atendimentos

- POST /api/AtendimentosUsuarios - Adiciona um novo atendimento
  
- GET /api/AtendimentosUsuarios/{id} - Retorna por Id

- PUT /api/AtendimentosUsuarios/{id} - Atualiza um atendimento

- DELETE /api/AtendimentosUsuarios/{id} - Remove um atendimento

### ContatosUsuarios

- GET /api/ContatosUsuarios - Retorna todos os contatos

- POST /api/ContatosUsuarios - Adiciona um novo contato
  
- GET /api/ContatosUsuarios/{id} - Retorna por Id

- PUT /api/ContatosUsuarios/{id} - Atualiza um contato

- DELETE /api/ContatosUsuarios/{id} - Remove um contato

### Dentistas

- GET /api/Dentistas - Retorna todos os dentistas

- POST /api/Dentistas - Adiciona um novo dentista
  
- GET /api/Dentistas/{id} - Retorna por Id

- PUT /api/Dentistas/{id} - Atualiza um dentista

### Previsoes

- GET /api/Previsoes - Retorna todas as previsões

- POST /api/Previsoes - Adiciona uma nova previsão
  
- GET /api/Dentistas/{id} - Retorna por Id

- PUT /api/Dentistas/{id} - Atualiza uma previsão

- DELETE /api/Dentistas/{id} - Remove uma nova previsão

### Usuarios

- GET /api/Usuarios - Retorna todos os usuários

- POST /api/Usuarios - Adiciona um novo usuário
  
- GET /api/Usuarios/{id} - Retorna por Id

- PUT /api/Usuarios/{id} - Atualiza um usuário

## 📜 Licença

- 📝 Este projeto é de uso acadêmico - FIAP.
