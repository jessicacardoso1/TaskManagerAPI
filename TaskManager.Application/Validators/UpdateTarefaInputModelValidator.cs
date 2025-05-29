using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Application.Models;
using TaskManager.Domain.Enums;

namespace TaskManager.Application.Validators
{
    public class UpdateTarefaInputModelValidator : AbstractValidator<UpdateTarefaInputModel>
    {
        public UpdateTarefaInputModelValidator()
        {
            RuleFor(x => x.Titulo)
                .NotEmpty().WithMessage("Título é obrigatório.")
                .MaximumLength(100).WithMessage("Título não pode ter mais que 100 caracteres.");

            RuleFor(x => x.Status)
                .IsInEnum().WithMessage("Status inválido.");

            RuleFor(x => x.DataConclusao)
                .NotNull()
                .When(x => x.Status == StatusTarefa.Concluida)
                .WithMessage("Data de conclusão é obrigatória para status 'Concluída'.");

            RuleFor(x => x.DataConclusao)
                .Null()
                .When(x => x.Status != StatusTarefa.Concluida)
                .WithMessage("Data de conclusão só deve ser informada para status 'Concluída'.");
        }
    }
}
