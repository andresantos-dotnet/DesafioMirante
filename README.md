# 🚀 Desafio Mirante — Web API (.NET 8.0)

Este projeto foi desenvolvido como parte do desafio técnico da **Mirante**, utilizando **.NET 8.0 Web API**, com foco em arquitetura limpa, boas práticas e alguns padrões clássicos de design.

---

## 🏛 Arquitetura e Padrões Utilizados

O projeto adota uma **arquitetura em camadas**, separando responsabilidades e facilitando manutenção, testes e evolução:

- **Domain** → regras de negócio e abstrações
- **Infra** → acesso a dados (EF Core) e implementações
- **CrossCutting** → configurações transversais, DI e mapeamentos
- **Web API** → controllers e endpoints expostos (Swagger habilitado)

### Padrões de Projeto implementados:

| Padrão | Responsabilidade no projeto |

| **Repository (Genérico)** | Abstrai e encapsula o acesso ao banco de dados com operações CRUD |
| **Unit of Work** | Centraliza commits e controla transações compartilhadas |
| **Dependency Injection (DI)** | Inversão de controle via container nativo do .NET |
| **AutoMapper Profiles** | Centraliza mapeamento entre **DTO ↔ Entities** |
| **DTO Pattern** | Controllers não expõem entidades diretamente, usam objetos de transferência |

> 💡 O projeto também incorpora princípios como **SOLID**, **DRY** e **Separation of Concerns**.

---

## ⚙️ Tecnologias Principais

- .NET 8.0 Web API
- Entity Framework Core
- AutoMapper
- Swagger (Swashbuckle)
- Injeção de dependência via `CrossCutting.DependencyInjection`

---

## 📦 Como rodar o projeto

1. Clone o repositório
2. Instale as dependências:
   powershell
   dotnet restore
Execute em modo Debug (F5) ou via terminal:

powershell
Copiar código
dotnet run
O Swagger estará disponível em:

bash
Copiar código
https://localhost:{PORT}/swagger/index.html

🧪 Próximos passos / melhorias possíveis
Implementar novos repositories conforme expansão do domínio

Versionamento da API no Swagger

Autenticação JWT (Bearer Token) na UI do Swagger

Logs, observabilidade e testes unitários com mocks

✍️ Autor
André Santos
Developer .NET / JavaScript / UI Designer
Apaixonado por código limpo, arquitetura e energético ☕👨‍💻
