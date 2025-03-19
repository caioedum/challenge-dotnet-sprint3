# 🦷 ChallengeDotnet - ASP.NET Core Web API - Parrot Tech

## 👥 Integrantes do Grupo

- **Nome 1** - [Perfil do GitHub](https://github.com/usuario1)
- **Nome 1** - [Perfil do GitHub](https://github.com/usuario1)
- **Nome 1** - [Perfil do GitHub](https://github.com/usuario1)

## 📌 Descrição do Projeto

Esta API foi desenvolvida utilizando .NET 8 com arquitetura monolítica, integrando-se diretamente com um banco de dados Oracle.

🔹 O principal objetivo da API é fornecer funcionalidades para gerenciamento de usuários, atendimentos e previsões odontológicas.

## 🏗 Arquitetura Monolítica

A API segue uma arquitetura monolítica, onde todas as funcionalidades estão contidas dentro de um único código base. Essa abordagem simplifica o desenvolvimento e a manutenção, garantindo uma comunicação direta entre os componentes.

## 🔍 Principais características:

✅ Comunicação direta com Oracle Database para operações CRUD.
✅ Aplicação centralizada sem dependência de microsserviços.

## 🎨 Design Patterns Utilizados

1. **Repository Pattern**:
   - Abstração da camada de acesso a dados para facilitar testes e manutenção.
2. **Singleton**:
   - Garantia de que certas instâncias (como configuração do banco) sejam únicas durante o ciclo de vida da aplicação.
3. **Factory Method**:
   - Criação dinâmica de objetos para maior flexibilidade.
4. **Dependency Injection**:
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

- ✅ Oracle Database configurado

- ✅ Visual Studio ou VS Code

## 📄 Passos para Execução

**1️⃣ Clone o repositório:**
```
git clone https://github.com/seu-repositorio/challenge-dotnet.git
cd challenge-dotnet
```
**2️⃣ Restaurar pacotes NuGet:**
```
dotnet restore
```
**4️⃣ Rodar a API:**
```
dotnet run
```
**6️⃣ Acesse a API no navegador ou via Postman:**
```
🔗 Endpoint padrão: http://localhost:5000
```
### 📜 Documentação Swagger: http://localhost:5000/swagger

## 📜 Licença

-- 📝 Este projeto é de uso acadêmico e segue as diretrizes estabelecidas pela FIAP.
