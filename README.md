# CadastroClientesAPP
# CadastroClientesAPP (API)

Este é um projeto de **Cadastro de Clientes** que expõe uma API RESTful construída com **.NET 8**, **Entity Framework Core** e **SQL Server**. A API permite gerenciar clientes com operações básicas de CRUD (Create, Read, Update, Delete).

### Tecnologias Utilizadas

- **.NET 8**
- **Entity Framework Core** (SQL Server)
- **ASP.NET Core Web API**
- **Swagger** para documentação da API

### Funcionalidades

- **GET /api/Cliente**: Retorna a lista de todos os clientes cadastrados.
- **GET /api/Cliente/{id}**: Retorna um cliente específico, identificado pelo `id`.
- **POST /api/Cliente**: Adiciona um novo cliente.
- **PUT /api/Cliente/{id}**: Atualiza os dados de um cliente existente.
- **DELETE /api/Cliente/{id}**: Deleta um cliente específico.

### Pré-requisitos

- **.NET 8 SDK** ou superior instalado.
- **SQL Server** configurado e rodando (local ou remoto).
- **Visual Studio** ou **Visual Studio Code** (recomendado).

### Instalação

1. Clone o repositório:
    ```bash
    git clone https://github.com/SeuUsuario/CadastroClientesAPP.git
    ```

2. Navegue até o diretório do projeto:
    ```bash
    cd CadastroClientesAPP
    ```

3. Restaure as dependências:
    ```bash
    dotnet restore
    ```

4. Configure a string de conexão no **`appsettings.json`** para o SQL Server:
    ```json
    {
      "ConnectionStrings": {
        "DefaultConnection": "Server=localhost;Database=CadastroClientesDB;Trusted_Connection=True;TrustServerCertificate=True;"
      }
    }
    ```

5. Execute as migrações para criar o banco de dados:
    ```bash
    dotnet ef migrations add InitialCreate
    dotnet ef database update
    ```

6. Execute a API:
    ```bash
    dotnet run
    ```

7. A API estará disponível em `https://localhost:5001` (ou o endereço configurado).

### Testando a API

Você pode testar a API utilizando ferramentas como **Postman**, **Swagger** ou **curl**. O Swagger estará disponível em `https://localhost:5001/swagger` para testar todos os endpoints da API.

### Contribuindo

1. Fork o repositório.
2. Crie uma nova branch (`git checkout -b feature/nova-feature`).
3. Faça suas alterações e commit (`git commit -am 'Adiciona nova funcionalidade'`).
4. Envie a branch (`git push origin feature/nova-feature`).
5. Abra um Pull Request.

---
