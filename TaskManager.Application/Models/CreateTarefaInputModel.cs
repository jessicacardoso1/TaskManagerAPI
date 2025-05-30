﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Domain.Entities;

namespace TaskManager.Application.Models
{
    public class CreateTarefaInputModel
    {
        public string Titulo { get; set; } = string.Empty;
        public string? Descricao { get; set; }
        public Tarefa ToEntity()
        {
            return new Tarefa(Titulo, Descricao);
        }
    }
}
