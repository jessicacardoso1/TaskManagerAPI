# 🗂️ TaskManagerAPI

API para gerenciamento de tarefas, desenvolvida em .NET 8 com arquitetura em camadas, validações robustas e aplicação de boas práticas.

---

## 🔥 Funcionalidades

- ✅ Listar todas as tarefas
- ✅ Criar nova tarefa
- ✅ Atualizar uma tarefa (incluindo status e data de conclusão)
- ✅ Excluir uma tarefa
- ✅ Filtrar tarefas por status (Pendente, Em Progresso, Concluída)
- ✅ Validação de dados com FluentValidation
- ✅ Tratamento global de erros via Middleware
- ✅ API seguindo boas práticas de status HTTP
- ✅ Testes unitários para entidades, services e validators

---

## 🏛️ Arquitetura do Projeto

/TaskManager.API
├── 📁 Application → Serviços, DTOs, Validações
├── 📁 Domain → Entidades, Regras de Negócio
├── 📁 Infrastructure → Banco de Dados, Repositórios
├── 📁 API → Controllers, Middlewares
└── 📁 Tests → Testes Unitários e Integração

## 🔗 Tecnologias Utilizadas

- ✔️ ASP.NET Core 8
- ✔️ Entity Framework Core
- ✔️ SQL Server
- ✔️ FluentValidation
- ✔️ Swagger (Swashbuckle)
- ✔️ xUnit + Moq (Testes Unitários)

---

## 🔧 Configuração e Execução do Projeto

### ✔️ Clonar o projeto

```bash
git clone https://github.com/jessicacardoso1/TaskManagerAPI
````

### ✔️ Configurar o banco de dados

No arquivo `appsettings.json`, configure sua string de conexão:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=SEU_SERVIDOR;Database=TaskManagerDB;User Id=SEU_USER;Password=SEU_PASSWORD;TrustServerCertificate=True"
  }
}
```

### ✔️ Aplicar as Migrations

```bash
cd TaskManager.API
dotnet ef database update
```

### ✔️ Rodar o projeto

```bash
dotnet run --project TaskManager.API
```

Acesse o Swagger:
`https://localhost:7005/swagger` ou `http://localhost:5193/swagger`

---

## 🧪 Rodar os Testes

```bash
cd TaskManager.Tests
dotnet test
```

Testa:

* ✔️ Entidade `Tarefa`
* ✔️ Service `TarefaService`
* ✔️ Validators (`Create` e `Update`)

---

## 🚦 Validação e Tratamento de Erros

* 🔥 **400 Bad Request** → Erros de validação de entrada
* 🔥 **404 Not Found** → Tarefa não encontrada
* 🔥 **201 Created** → Tarefa criada com sucesso
* 🔥 **500 Internal Server Error** → Erros inesperados (tratados via Middleware)

---

## 📜 Melhorias Implementadas

* ✔️ Validação de enums (`StatusTarefa`) via FluentValidation
* ✔️ Regras de negócio na entidade `Tarefa` protegendo transição de status e datas
* ✔️ Middleware global para tratamento de erros padronizados
* ✔️ API responde com mensagens claras e status HTTP corretos

---
## 🌐 Frontend

O frontend deste projeto está disponível no repositório:

👉 [TaskManagerWeb](https://github.com/jessicarocha/taskmanager-web)

Ele consome os endpoints desta API e permite:

- ✅ Listar tarefas
- ✅ Criar nova tarefa
- ✅ Atualizar tarefas
- ✅ Excluir tarefas
- ✅ Filtrar tarefas por status (Pendente, Em Progresso, Concluída)

Tecnologias usadas no frontend:

- ⚛️ React 18
- 🎨 Material-UI v5
- ♻️ React Router v6
- 🔗 Axios para chamadas à API
