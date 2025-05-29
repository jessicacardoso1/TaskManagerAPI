using FluentValidation.TestHelper;
using TaskManager.Application.Models;
using TaskManager.Application.Validators;
using TaskManager.Domain.Enums;
using Xunit;

namespace TaskManager.Tests.Application.Validators
{
    public class UpdateTarefaInputModelValidatorTests
    {
        private readonly UpdateTarefaInputModelValidator _validador = new();

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("   ")]
        public void Deve_Retornar_Erro_Quando_Titulo_Eh_Invalido(string titulo)
        {
            var modelo = new UpdateTarefaInputModel { Titulo = titulo };
            var resultado = _validador.TestValidate(modelo);
            resultado.ShouldHaveValidationErrorFor(x => x.Titulo);
        }

        [Fact]
        public void Deve_Retornar_Erro_Quando_Status_Eh_Invalido()
        {
            var modelo = new UpdateTarefaInputModel { Status = (StatusTarefa)99 };
            var resultado = _validador.TestValidate(modelo);
            resultado.ShouldHaveValidationErrorFor(x => x.Status);
        }

        [Fact]
        public void Deve_Retornar_Erro_Quando_Concluida_Sem_DataConclusao()
        {
            var modelo = new UpdateTarefaInputModel { Status = StatusTarefa.Concluida, DataConclusao = null };
            var resultado = _validador.TestValidate(modelo);
            resultado.ShouldHaveValidationErrorFor(x => x.DataConclusao);
        }

        [Fact]
        public void Deve_Retornar_Erro_Quando_Nao_Concluida_Com_DataConclusao()
        {
            var modelo = new UpdateTarefaInputModel
            {
                Status = StatusTarefa.Pendente,
                DataConclusao = DateTime.Now
            };
            var resultado = _validador.TestValidate(modelo);
            resultado.ShouldHaveValidationErrorFor(x => x.DataConclusao);
        }

        [Fact]
        public void Deve_Aceitar_Quando_Concluida_Com_DataConclusao_Valida()
        {
            var modelo = new UpdateTarefaInputModel
            {
                Status = StatusTarefa.Concluida,
                DataConclusao = DateTime.Now,
                Titulo = "Título válido"
            };
            var resultado = _validador.TestValidate(modelo);
            resultado.ShouldNotHaveAnyValidationErrors();
        }
    }
}