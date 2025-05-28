using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Application.Models;
using TaskManager.Domain.Entities;

namespace TaskManager.Application.Interfaces
{
    public interface ITarefaService
    {
        Task<ResultViewModel<List<TarefaViewModel>>> GetAllAsync();
        Task<ResultViewModel<TarefaViewModel>> GetByIdAsync(int id);
        Task<ResultViewModel<int>> CreateAsync(CreateTarefaInputModel input);
        Task<ResultViewModel> UpdateAsync(int id, UpdateTarefaInputModel input);
        Task<ResultViewModel> DeleteAsync(int id);
    }
}
