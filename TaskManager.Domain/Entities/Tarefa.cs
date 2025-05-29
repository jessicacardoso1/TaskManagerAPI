using DevFreela.Core.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Domain.Enums;

namespace TaskManager.Domain.Entities
{
    public class Tarefa : EntidadeBase
    {
        public string Titulo { get; private set; } = string.Empty;
        public string? Descricao { get; private set; }
        public DateTime? DataConclusao { get; private set; }
        public StatusTarefa Status { get; private set; }

        public Tarefa(string titulo, string? descricao) : base()
        {
            SetTitulo(titulo);
            Descricao = descricao;
            Status = StatusTarefa.Pendente;
        }

        public void SetTitulo(string titulo)
        {
            if (string.IsNullOrWhiteSpace(titulo))
                throw new ArgumentException("Título é obrigatório.");

            if (titulo.Length > 100)
                throw new ArgumentException("Título não pode ter mais que 100 caracteres.");

            Titulo = titulo;
        }
        public void SetDescricao(string? descricao)
        {
            Descricao = descricao;
        }

        public void Concluir(DateTime dataConclusao)
        {
            if (dataConclusao < DataCriacao)
                throw new Exception("Data de conclusão não pode ser anterior à data de criação.");

            DataConclusao = dataConclusao;
            Status = StatusTarefa.Concluida;
        }

        public void Iniciar()
        {
            Status = StatusTarefa.EmProgresso;
        }

        public void Atualizar(string titulo, string? descricao, StatusTarefa status, DateTime? dataConclusao)
        {
            SetTitulo(titulo);
            SetDescricao(descricao);

            switch (status)
            {
                case StatusTarefa.Pendente:
                    Status = StatusTarefa.Pendente;
                    DataConclusao = null;
                    break;

                case StatusTarefa.EmProgresso:
                    Iniciar();
                    DataConclusao = null;
                    break;

                case StatusTarefa.Concluida:
                    Concluir(dataConclusao ?? DateTime.Now);
                    break;
            }
        }

    }

}
