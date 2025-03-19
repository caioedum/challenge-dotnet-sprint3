# challenge-dotnet-sprint3
 
🦷 ChallengeDotnet - ASP.NET Core Web API - Parrot Tech

👥 Integrantes do Grupo

🧑‍💻 Nome 1

🧑‍💻 Nome 2

🧑‍💻 Nome 3

🧑‍💻 Nome 4

📌 Descrição do Projeto

Esta API foi desenvolvida utilizando .NET 8 com arquitetura monolítica, integrando-se diretamente com um banco de dados Oracle.

🔹 O principal objetivo da API é fornecer funcionalidades para gerenciamento de usuários, atendimentos e previsões odontológicas.

🏗 Arquitetura Monolítica

A API segue uma arquitetura monolítica, onde todas as funcionalidades estão contidas dentro de um único código base. Essa abordagem simplifica o desenvolvimento e a manutenção, garantindo uma comunicação direta entre os componentes.

🔍 Principais características:

✅ Estrutura baseada no padrão MVC (Model-View-Controller).
✅ Comunicação direta com Oracle Database para operações CRUD.
✅ Aplicação centralizada sem dependência de microsserviços.

🎨 Design Patterns Utilizados

🗄 Repository Pattern: Facilita a separação da lógica de acesso a dados, tornando o código mais modular e testável.

🏭 Factory Pattern: Utilizado para a criação de objetos de forma desacoplada e flexível.

🔗 Dependency Injection: Permite maior modularidade e facilita a substituição de implementações sem impactar outras partes do código.

🛠 Tecnologias Utilizadas

🚀 .NET 8
💾 Entity Framework Core
🎯 Oracle Database
📜 Swagger (Documentação interativa da API)
🐳 Docker (Para containerização da API, opcional)

🚀 Como Rodar a API Localmente

📌 Pré-requisitos

Certifique-se de ter instalado:

✅ .NET 8 SDK

✅ Oracle Database configurado

✅ Visual Studio ou VS Code

✅ Docker (opcional, caso queira rodar o banco em container)

📄 Passos para Execução

1️⃣ Clone o repositório:

git clone https://github.com/seu-repositorio/challenge-dotnet.git
cd challenge-dotnet

2️⃣ Configurar a conexão com o Oracle

Edite o arquivo appsettings.json e insira suas credenciais do Oracle.

{
  "ConnectionStrings": {
    "OracleDb": "User Id=rm554025;Password=caio2024;Data Source=seu_oracle_host"
  }
}

3️⃣ Restaurar pacotes NuGet:

dotnet restore

4️⃣ Executar as migrações do banco de dados:

dotnet ef database update

5️⃣ Rodar a API:

dotnet run

6️⃣ Acesse a API no navegador ou via Postman:

🔗 Endpoint padrão: http://localhost:5000

📜 Documentação Swagger: http://localhost:5000/swagger

🤝 Contribuição

Quer contribuir com o projeto? Siga os passos abaixo:
1️⃣ Faça um fork do repositório.
2️⃣ Crie uma branch para sua feature: git checkout -b minha-feature
3️⃣ Commit suas mudanças: git commit -m 'Adiciona nova feature'
4️⃣ Faça um push para a branch: git push origin minha-feature
5️⃣ Abra um Pull Request 🚀

📜 Licença

📝 Este projeto é de uso acadêmico e segue as diretrizes estabelecidas pela FIAP Paulista.
