# Task Manager — C# .NET
 
![.NET](https://img.shields.io/badge/.NET-8.0-512BD4?style=flat-square&logo=dotnet)
![C#](https://img.shields.io/badge/C%23-console%20app-239120?style=flat-square&logo=csharp)
 
Aplicação console de **CRUD** feita com C# e .NET para gerenciar tarefas pelo terminal. O projeto foi desenvolvido com foco em organização de código e separação de responsabilidades.
 
---
 
## Funcionalidades
 
- Criar tarefa com título e descrição
- Listar todas as tarefas com status
- Buscar tarefa por ID
- Editar título e/ou descrição
- Deletar tarefa com confirmação
- Marcar tarefa como concluída
---
 
## Estrutura do projeto
 
```
task-manager-csharp/
├── CrudTarefas.csproj
├── Program.cs                      # Ponto de entrada
├── Models/
│   └── Tarefa.cs                   # Entidade
├── Repositories/
│   └── TarefaRepository.cs         # Camada de dados (em memória)
└── UI/
    └── Menu.cs                     # Interface de console
```
 
Cada classe tem uma única responsabilidade:
 
- **Program.cs** — ponto de entrada, inicializa o app
- **Tarefa.cs** — define a entidade Tarefa
- **TarefaRepository.cs** — realiza todas as operações de dados
- **Menu.cs** — gerencia toda entrada e saída no console
---
 
## Como rodar
 
### Pré-requisitos
 
- [.NET 8 SDK](https://dotnet.microsoft.com/download) ou superior
### Clonar o repositório
 
```bash
git clone https://github.com/panicq-dev/task-manager-csharp.git
cd task-manager-csharp
```
 
### Executar
 
```bash
dotnet run
```
 
---
 
## Como usar
 
Ao rodar o projeto, um menu aparece no terminal:
 
```
========================================
         GERENCIADOR DE TAREFAS
========================================
1. Criar nova tarefa
2. Listar todas as tarefas
3. Buscar tarefa por ID
4. Editar tarefa
5. Deletar tarefa
6. Marcar tarefa como concluída
0. Sair
========================================
Escolha uma opção:
```
 
Digite o número da opção desejada e pressione **Enter**.
 
### Exemplo
 
```
Escolha uma opção: 1
 
--- CRIAR NOVA TAREFA ---
Título: Comprar mantimentos
Descrição: Leite, ovos, pão
 
Tarefa criada com sucesso! ID: 1
```
 
---
 
## Tecnologias
 
- **Linguagem:** C#
- **Framework:** .NET 8
- **Armazenamento:** Em memória (sem banco de dados)
- **Interface:** Aplicação console
---
 
## Conceitos abordados
 
- Operações CRUD
- Separação de responsabilidades por classe
- Namespaces e organização por pastas
- Manipulação de listas com List\<T\>
- Validação básica de entrada
- Leitura e escrita no console
---
 
## Ideias para evoluir o projeto
 
- [ ] Adicionar data de vencimento nas tarefas
- [ ] Filtrar tarefas por status (pendente / concluída)
- [ ] Persistir dados em arquivo JSON ou SQLite
- [ ] Adicionar categorias nas tarefas
- [ ] Criar uma versão Web API com ASP.NET Core
