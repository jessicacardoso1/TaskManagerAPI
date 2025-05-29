using FluentValidation.TestHelper;
using TaskManager.Application.Models;
using TaskManager.Application.Validators;
using Xunit;

namespace TaskManager.Tests.Application.Validators
{
    public class CreateTarefaInputModelValidatorTests
    {
        private readonly CreateTarefaInputModelValidator _validador = new();

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("   ")]
        public void Deve_Retornar_Erro_Quando_Titulo_Eh_Invalido(string titulo)
        {
            var modelo = new CreateTarefaInputModel { Titulo = titulo };
            var resultado = _validador.TestValidate(modelo);
            resultado.ShouldHaveValidationErrorFor(x => x.Titulo);
        }

        [Fact]
        public void Deve_Retornar_Erro_Quando_Titulo_Excede_Tamanho_Maximo()
        {
            var modelo = new CreateTarefaInputModel { Titulo = new string('a', 101) };
            var resultado = _validador.TestValidate(modelo);
            resultado.ShouldHaveValidationErrorFor(x => x.Titulo);
        }

        [Fact]
        public void Deve_Aceitar_Quando_Titulo_Eh_Valido()
        {
            var modelo = new CreateTarefaInputModel { Titulo = "Título válido" };
            var resultado = _validador.TestValidate(modelo);
            resultado.ShouldNotHaveValidationErrorFor(x => x.Titulo);
        }

        [Fact]
        public void Deve_Retornar_Erro_Quando_Descricao_Excede_Tamanho_Maximo()
        {
            var modelo = new CreateTarefaInputModel { Descricao = new string('a', 501) };
            var resultado = _validador.TestValidate(modelo);
            resultado.ShouldHaveValidationErrorFor(x => x.Descricao);
        }

        [Theory]
        [InlineData("Descrição válida!")]
        [InlineData(null)]
        [InlineData("")]
        public void Deve_Aceitar_Quando_Descricao_Eh_Valida(string descricao)
        {
            var modelo = new CreateTarefaInputModel { Descricao = descricao };
            var resultado = _validador.TestValidate(modelo);
            resultado.ShouldNotHaveValidationErrorFor(x => x.Descricao);
        }
    }
}