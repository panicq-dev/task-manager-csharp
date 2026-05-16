using System.Collections.Generic;
using CrudTarefas.Models;

namespace CrudTarefas.Repositories
{
    class TarefaRepository
    {
        private List<Tarefa> tarefas = new List<Tarefa>();
        private int proximoId = 1;

        public Tarefa Criar(string titulo, string descricao)
        {
            Tarefa nova = new Tarefa
            {
                Id = proximoId,
                Titulo = titulo,
                Descricao = descricao,
                Concluida = false
            };

            tarefas.Add(nova);
            proximoId++;

            return nova;
        }

        public List<Tarefa> ListarTodas()
        {
            return tarefas;
        }

        public Tarefa BuscarPorId(int id)
        {
            foreach (Tarefa t in tarefas)
            {
                if (t.Id == id)
                    return t;
            }
            return null;
        }

        public bool Editar(int id, string novoTitulo, string novaDescricao)
        {
            Tarefa tarefa = BuscarPorId(id);

            if (tarefa == null)
                return false;

            if (!string.IsNullOrWhiteSpace(novoTitulo))
                tarefa.Titulo = novoTitulo;

            if (!string.IsNullOrWhiteSpace(novaDescricao))
                tarefa.Descricao = novaDescricao;

            return true;
        }

        public bool Deletar(int id)
        {
            Tarefa tarefa = BuscarPorId(id);

            if (tarefa == null)
                return false;

            tarefas.Remove(tarefa);
            return true;
        }

        public bool MarcarConcluida(int id)
        {
            Tarefa tarefa = BuscarPorId(id);

            if (tarefa == null || tarefa.Concluida)
                return false;

            tarefa.Concluida = true;
            return true;
        }
    }
}
