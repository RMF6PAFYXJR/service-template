# ⚙️ RKFFSW ASP.NET 9 Web API Template

**Version 1.1**
A clean and modern **ASP.NET 9 Web API template** built around **Clean Architecture** principles — serving as a foundation for all your backend microservices.

---

## 🚀 Overview

This template provides a **scalable**, **modular**, and **testable** base for service-oriented APIs.
It’s ready for production with:

* ✅ Preconfigured **Swagger** (with API Key authentication example)
* ✅ Built-in **PostgreSQL** and **Redis** integration
* ✅ Automatic **EF Core migrations**
* ✅ Global **middleware pipeline**
* ✅ Modular extension-based startup (clean `Program.cs`)
* ✅ Ready-to-deploy **Docker** & **NGINX reverse proxy** setup
* ✅ Based on **Domain-Driven Design (DDD)** & **Use Case** patterns

---

## 🧩 Technologies

| Component                 | Description                     |
| ------------------------- | ------------------------------- |
| **.NET 9**                | Core framework for the API      |
| **PostgreSQL**            | Primary database                |
| **Redis**                 | Caching and data storage        |
| **Entity Framework Core** | ORM with migrations             |
| **Swagger / OpenAPI**     | API documentation and testing   |
| **Docker & Compose**      | Containerized deployment        |
| **Nginx-ready setup**     | Works seamlessly behind a proxy |

---

## 🧠 Architecture Overview

```
          ┌──────────────────────────┐
          │        Presentation       │
          │ (Controllers, Middleware) │
          └────────────┬──────────────┘
                       │
                       ▼
          ┌──────────────────────────┐
          │        Application        │
          │ (UseCases, DTOs, Mappers) │
          └────────────┬──────────────┘
                       │
                       ▼
          ┌──────────────────────────┐
          │          Domain           │
          │ (Entities, Interfaces)    │
          └────────────┬──────────────┘
                       │
                       ▼
          ┌──────────────────────────┐
          │      Infrastructure       │
          │ (Repositories, Services,  │
          │  DbContext, Email, Redis) │
          └──────────────────────────┘
```

**Flow Example:**

```
Controller → UseCase → Service → Repository → Database
```

---

## 🗂 Project Structure

```
📁 src/
├─ 📘 Domain/
│   ├─ Entities/
│   ├─ Interfaces/
│   └─ Common/
│
├─ ⚙️ Application/
│   ├─ DTOs/
│   ├─ UseCases/
│   ├─ Mappers/
│   └─ Validators/
│
├─ 🏗 Infrastructure/
│   ├─ Persistence/
│   │   ├─ AppDbContext.cs
│   │   └─ Repositories/
│   │   
│   ├─ Services/
│   └─ Extensions/
│
├─ 🌐 API/
│   ├─ Controllers/
│   ├─ Middleware/
│   └─ Extensions/
│
└─ 🏁 Program.cs
```

---

## 🧱 Usage

### 🛠 Create a new project from this template

```bash
dotnet new install ./
dotnet new service_template -n MyNewService
```

### 🧰 Run with Docker

```bash
docker compose up --build -d
```

Your service will be available at:

```
http://localhost:8080/swagger
```

---

## ⚙️ Commands and Tools

| Action               | Command                                    |
| -------------------- | ------------------------------------------ |
| Add migration        | `dotnet ef migrations add "MigrationName"` |
| Apply migrations     | `dotnet ef database update`                |
| Run Docker container | `docker compose up --build -d`             |
| Create from template | `dotnet new service_template -n MyService` |

---

## 🧩 Layer Summary

| Layer              | Responsibility                                                 |
| ------------------ | -------------------------------------------------------------- |
| **Domain**         | Core entities and contracts (pure logic, no dependencies)      |
| **Application**    | UseCases and DTOs that coordinate services                     |
| **Infrastructure** | Implementations (repositories, external APIs, services)        |
| **API**            | Entry point layer — controllers, middleware, swagger, DI setup |

---

## 💡 Notes

* Designed for **Clean Architecture** and **DDD** enthusiasts.
* You can easily extend it with **CQRS**, **MediatR**, or **gRPC**.
* Keeps dependencies flowing **inward** — outer layers depend on inner ones, never the reverse.

---

## 🧑‍💻 Author

**RKFFSW**
*“Built once, reused everywhere.”*
