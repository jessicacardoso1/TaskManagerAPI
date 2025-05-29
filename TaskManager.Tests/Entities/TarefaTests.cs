using TaskManager.Domain.Entities;
using TaskManager.Domain.Enums;
using Xunit;

public class TarefaTests
{
    [Fact]
    public void Deve_Criar_Tarefa_Com_Status_Pendente_Por_Padrao()
    {
        var tarefa = new Tarefa("Título", "Descrição");

        Assert.Equal(StatusTarefa.Pendente, tarefa.Status);
        Assert.Null(tarefa.DataConclusao);
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("   ")]
    public void Deve_Lancar_Excecao_Quando_Titulo_Eh_Invalido(string titulo)
    {
        Assert.Throws<ArgumentException>(() =>
            new Tarefa(titulo, "Descrição"));
    }

    [Fact]
    public void Nao_Deve_Concluir_Com_Data_Anterior_A_Criacao()
    {
        // Arrange
        var tarefa = new Tarefa("Teste", "Descrição");
        var dataConclusao = tarefa.DataCriacao.AddDays(-1);

        // Act & Assert
        var ex = Assert.Throws<ArgumentException>(() =>
            tarefa.Atualizar("Teste", "Descrição", StatusTarefa.Concluida, dataConclusao));

        Assert.Equal("Data de conclusão não pode ser anterior à data de criação.", ex.Message);
    }

    [Fact]
    public void Deve_Atualizar_Campos_Corretamente_Quando_Dados_Validos()
    {
        // Arrange
        var tarefa = new Tarefa("Título", "Descrição");

        // Act
        tarefa.Atualizar("Novo Título", "Nova Descrição", StatusTarefa.EmProgresso, null);

        // Assert
        Assert.Equal("Novo Título", tarefa.Titulo);
        Assert.Equal("Nova Descrição", tarefa.Descricao);
        Assert.Equal(StatusTarefa.EmProgresso, tarefa.Status);
    }
    [Fact]
    public void Deve_Lancar_Excecao_Quando_Concluir_Sem_DataConclusao()
    {
        var tarefa = new Tarefa("Título", "Descrição");

        Assert.Throws<ArgumentException>(() =>
            tarefa.Atualizar("Título", "Descrição", StatusTarefa.Concluida, null));
    }

    [Fact]
    public void Deve_Concluir_Tarefa_Quando_Data_Valida()
    {
        var tarefa = new Tarefa("Título", "Descrição");
        var data = DateTime.Now;

        tarefa.Concluir(data);

        Assert.Equal(StatusTarefa.Concluida, tarefa.Status);
        Assert.Equal(data, tarefa.DataConclusao);
    }
}
