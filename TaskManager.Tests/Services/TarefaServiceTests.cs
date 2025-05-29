using Moq;
using TaskManager.Application.Interfaces;
using TaskManager.Application.Models;
using TaskManager.Application.Services;
using TaskManager.Domain.Entities;
using TaskManager.Domain.Enums;
using TaskManager.Domain.Repositories;
using Xunit;

namespace TaskManager.Tests.Application.Services
{
    public class TarefaServiceTests
    {
        private readonly Mock<ITarefaRepository> _mockRepositorio;
        private readonly TarefaService _servico;

        public TarefaServiceTests()
        {
            _mockRepositorio = new Mock<ITarefaRepository>();
            _servico = new TarefaService(_mockRepositorio.Object);
        }

        #region Testes de Criação
        [Fact]
        public async Task Deve_Criar_Tarefa_Com_Sucesso_Quando_Dados_Validos()
        {
            var entrada = new CreateTarefaInputModel
            {
                Titulo = "Nova Tarefa",
                Descricao = "Descrição da tarefa"
            };

            _mockRepositorio.Setup(x => x.CreateAsync(It.IsAny<Tarefa>()))
                .ReturnsAsync(1);

            var resultado = await _servico.CreateAsync(entrada);

            Assert.True(resultado.IsSuccess);
            Assert.Equal(1, resultado.Data);
            _mockRepositorio.Verify(x => x.CreateAsync(It.Is<Tarefa>(t =>
                t.Titulo == entrada.Titulo &&
                t.Descricao == entrada.Descricao &&
                t.Status == StatusTarefa.Pendente)), Times.Once);
        }

        #endregion

        #region Testes de Atualização
        [Fact]
        public async Task Deve_Atualizar_Tarefa_Com_Sucesso_Quando_Dados_Validos()
        {
            var tarefaExistente = new Tarefa("Tarefa Antiga", "Descrição Antiga");
            var entrada = new UpdateTarefaInputModel
            {
                Titulo = "Tarefa Atualizada",
                Descricao = "Nova Descrição",
                Status = StatusTarefa.Concluida,
                DataConclusao = DateTime.Now
            };

            _mockRepositorio.Setup(x => x.GetByIdAsync(1))
                .ReturnsAsync(tarefaExistente);

            var resultado = await _servico.UpdateAsync(1, entrada);

            Assert.True(resultado.IsSuccess);
            Assert.Equal("Tarefa Atualizada", tarefaExistente.Titulo);
            Assert.Equal(StatusTarefa.Concluida, tarefaExistente.Status);
            _mockRepositorio.Verify(x => x.UpdateAsync(tarefaExistente), Times.Once);
        }

        [Fact]
        public async Task Deve_Retornar_Falha_Quando_Tarefa_Nao_Encontrada()
        {
            _mockRepositorio.Setup(x => x.GetByIdAsync(1))
                .ReturnsAsync((Tarefa)null);

            var entrada = new UpdateTarefaInputModel { Titulo = "Título" };

            var resultado = await _servico.UpdateAsync(1, entrada);

            Assert.False(resultado.IsSuccess);
            Assert.Equal("Tarefa não encontrada.", resultado.Message);
        }

        #endregion
    }
}