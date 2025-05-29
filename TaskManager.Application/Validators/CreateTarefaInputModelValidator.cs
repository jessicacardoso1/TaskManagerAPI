using FluentValidation;
using TaskManager.Application.Models;

public class CreateTarefaInputModelValidator : AbstractValidator<CreateTarefaInputModel>
{
    public CreateTarefaInputModelValidator()
    {
        RuleFor(x => x.Titulo)
            .NotEmpty().WithMessage("Título é obrigatório.")
            .MaximumLength(100).WithMessage("Título não pode ter mais que 100 caracteres.");

        RuleFor(x => x.Descricao)
            .MaximumLength(500).WithMessage("Descrição não pode ter mais que 500 caracteres.");
    }
}
