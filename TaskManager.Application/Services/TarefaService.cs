using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Application.Interfaces;
using TaskManager.Application.Models;
using TaskManager.Domain.Entities;
using TaskManager.Domain.Enums;
using TaskManager.Domain.Repositories;

namespace TaskManager.Application.Services
{
    public class TarefaService : ITarefaService
    {
        private readonly ITarefaRepository _repository;

        public TarefaService(ITarefaRepository repository)
        {
            _repository = repository;
        }

        public async Task<ResultViewModel<List<TarefaViewModel>>> GetAllAsync()
        {
            var tarefas = await _repository.GetAllAsync();

            var result = tarefas
                .Select(TarefaViewModel.FromEntity)
                .ToList();

            return ResultViewModel<List<TarefaViewModel>>.Success(result);
        }

        public async Task<ResultViewModel<TarefaViewModel>> GetByIdAsync(int id)
        {
            var tarefa = await _repository.GetByIdAsync(id);

            if (tarefa == null)
                return ResultViewModel<TarefaViewModel>.Failure("Tarefa não encontrada.");

            var result = TarefaViewModel.FromEntity(tarefa);
            return ResultViewModel<TarefaViewModel>.Success(result);
        }

        public async Task<ResultViewModel<int>> CreateAsync(CreateTarefaInputModel input)
        {
            var tarefa = input.ToEntity();

            var id = await _repository.CreateAsync(tarefa);

            return ResultViewModel<int>.Success(id, "Tarefa criada com sucesso.");
        }

        public async Task<ResultViewModel> UpdateAsync(int id, UpdateTarefaInputModel input)
        {
            var tarefa = await _repository.GetByIdAsync(id);

            if (tarefa == null)
                return ResultViewModel.Error("Tarefa não encontrada.");

            if (!Enum.IsDefined(typeof(StatusTarefa), input.Status))
                return ResultViewModel.Error("Status inválido.");

            try
            {
                tarefa.Atualizar(input.Titulo, input.Descricao, input.Status, input.DataConclusao);

                await _repository.UpdateAsync(tarefa);

                return ResultViewModel.Success("Tarefa atualizada com sucesso.");
            }
            catch (ArgumentException ex)
            {
                return ResultViewModel.Error(ex.Message);
            }
        }


        public async Task<ResultViewModel> DeleteAsync(int id)
        {
            var tarefa = await _repository.GetByIdAsync(id);

            if (tarefa == null)
                return ResultViewModel.Error("Tarefa não encontrada.");

            await _repository.DeleteAsync(id);

            return ResultViewModel.Success("Tarefa excluída com sucesso.");
        }
    }
}