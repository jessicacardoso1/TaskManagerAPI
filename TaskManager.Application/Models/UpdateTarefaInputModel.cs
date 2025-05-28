using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Domain.Enums;

namespace TaskManager.Application.Models
{
    public class UpdateTarefaInputModel
    {
        public string Titulo { get; set; } = string.Empty;
        public string? Descricao { get; set; }
        public StatusTarefa Status { get; set; }
        public DateTime? DataConclusao { get; set; }
    }
}
