using System;
using System.Collections.Generic;
using CrudTarefas.Models;
using CrudTarefas.Repositories;

namespace CrudTarefas.UI
{
    class Menu
    {
        private TarefaRepository _repository;

        public Menu()
        {
            _repository = new TarefaRepository();
        }

        public void Executar()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            bool rodando = true;

            while (rodando)
            {
                MostrarOpcoes();
                string opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1":
                        CriarTarefa();
                        break;
                    case "2":
                        ListarTarefas();
                        break;
                    case "3":
                        BuscarTarefa();
                        break;
                    case "4":
                        EditarTarefa(); // A fazer
                        break;
                    case "5":
                        DeletarTarefa(); // A fazer
                        break;
                    case "6":
                        MarcarConcluida(); // A fazer
                        break;
                    case "0":
                        rodando = false;
                        Console.WriteLine("\nSaindo... Até logo!");
                        break;
                    default:
                        Console.WriteLine("\nOpção inválida! Tente novamente.");
                        break;
                }

                if (rodando)
                {
                    Console.WriteLine("\nPressione qualquer tecla para continuar...");
                    Console.ReadKey();
                    Console.Clear();
                }
            }
        }

        private void MostrarOpcoes()
        {
            Console.WriteLine("========================================");
            Console.WriteLine("         GERENCIADOR DE TAREFAS         ");
            Console.WriteLine("========================================");
            Console.WriteLine("1. Criar nova tarefa");
            Console.WriteLine("2. Listar todas as tarefas");
            Console.WriteLine("3. Buscar tarefa por ID");
            Console.WriteLine("4. Editar tarefa");
            Console.WriteLine("5. Deletar tarefa");
            Console.WriteLine("6. Marcar tarefa como concluída");
            Console.WriteLine("0. Sair");
            Console.WriteLine("========================================");
            Console.Write("Escolha uma opção: ");
        }

        private void CriarTarefa()
        {
            Console.WriteLine("\n--- CRIAR NOVA TAREFA ---");

            Console.Write("Título: ");
            string titulo = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(titulo))
            {
                Console.WriteLine("Erro: o título não pode ser vazio!");
                return;
            }

            Console.Write("Descrição: ");
            string descricao = Console.ReadLine();

            Tarefa nova = _repository.Criar(titulo, descricao);
            Console.WriteLine($"\nTarefa criada com sucesso! ID: {nova.Id}");
        }

        private void ListarTarefas()
        {
            Console.WriteLine("\n--- LISTA DE TAREFAS ---");

            List<Tarefa> lista = _repository.ListarTodas();

            if (lista.Count == 0)
            {
                Console.WriteLine("Nenhuma tarefa cadastrada ainda.");
                return;
            }

            foreach (Tarefa t in lista)
            {
                string status = t.Concluida ? "✓ Concluída" : "○ Pendente";
                Console.WriteLine($"[{t.Id}] {t.Titulo} - {status}");
                Console.WriteLine($"    Descrição: {t.Descricao}");
                Console.WriteLine();
            }

            Console.WriteLine($"Total: {lista.Count} tarefa(s)");
        }

        private void BuscarTarefa()
        {
            Console.WriteLine("\n--- BUSCAR TAREFA ---");

            int id = LerId();
            if (id == -1) return;

            Tarefa tarefa = _repository.BuscarPorId(id);

            if (tarefa == null)
            {
                Console.WriteLine($"Tarefa com ID {id} não encontrada.");
                return;
            }

            string status = tarefa.Concluida ? "✓ Concluída" : "○ Pendente";
            Console.WriteLine($"\nID: {tarefa.Id}");
            Console.WriteLine($"Título: {tarefa.Titulo}");
            Console.WriteLine($"Descrição: {tarefa.Descricao}");
            Console.WriteLine($"Status: {status}");
        }

        private void EditarTarefa()
        {
            Console.WriteLine("\n--- EDITAR TAREFA ---");

            int id = LerId();
            if (id == -1) return;

            Tarefa tarefa = _repository.BuscarPorId(id);

            if (tarefa == null)
            {
                Console.WriteLine($"Tarefa com ID {id} não encontrada.");
                return;
            }

            Console.WriteLine($"Título atual: {tarefa.Titulo}");
            Console.Write("Novo título (deixe em branco para manter): ");
            string novoTitulo = Console.ReadLine();

            Console.WriteLine($"Descrição atual: {tarefa.Descricao}");
            Console.Write("Nova descrição (deixe em branco para manter): ");
            string novaDescricao = Console.ReadLine();

            _repository.Editar(id, novoTitulo, novaDescricao);
            Console.WriteLine("\nTarefa atualizada com sucesso!");
        }

        private void DeletarTarefa()
        {
            Console.WriteLine("\n--- DELETAR TAREFA ---");

            int id = LerId();
            if (id == -1) return;

            Tarefa tarefa = _repository.BuscarPorId(id);

            if (tarefa == null)
            {
                Console.WriteLine($"Tarefa com ID {id} não encontrada.");
                return;
            }

            Console.Write($"Tem certeza que deseja deletar \"{tarefa.Titulo}\"? (s/n): ");
            string confirmacao = Console.ReadLine();

            if (confirmacao.ToLower() == "s")
            {
                _repository.Deletar(id);
                Console.WriteLine("Tarefa deletada com sucesso!");
            }
            else
            {
                Console.WriteLine("Operação cancelada.");
            }
        }

        private void MarcarConcluida()
        {
            Console.WriteLine("\n--- MARCAR COMO CONCLUÍDA ---");

            int id = LerId();
            if (id == -1) return;

            Tarefa tarefa = _repository.BuscarPorId(id);

            if (tarefa == null)
            {
                Console.WriteLine($"Tarefa com ID {id} não encontrada.");
                return;
            }

            if (tarefa.Concluida)
            {
                Console.WriteLine("Essa tarefa já está concluída!");
                return;
            }

            _repository.MarcarConcluida(id);
            Console.WriteLine($"Tarefa \"{tarefa.Titulo}\" marcada como concluída!");
        }

        // Método auxiliar para ler e validar um ID do console
        private int LerId()
        {
            Console.Write("Digite o ID da tarefa: ");

            int id;
            bool converteu = int.TryParse(Console.ReadLine(), out id);

            if (!converteu)
            {
                Console.WriteLine("ID inválido!");
                return -1;
            }

            return id;
        }
    }
}
