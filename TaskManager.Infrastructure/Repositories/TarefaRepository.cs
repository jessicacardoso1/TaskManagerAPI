using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Domain.Entities;
using TaskManager.Domain.Repositories;

namespace TaskManager.Infrastructure.Repositories
{
    public class TarefaRepository : ITarefaRepository
    {
        private readonly AppDbContext _context;

        public TarefaRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<int> CreateAsync(Tarefa tarefa)
        {
            await _context.Tarefas.AddAsync(tarefa);
            await _context.SaveChangesAsync();

            return tarefa.Id;
        }

        public async Task DeleteAsync(int id)
        {
            var tarefa = await GetByIdAsync(id);
            if (tarefa != null)
            {
                tarefa.MarcarComoDeletado();
                _context.Tarefas.Update(tarefa);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Tarefa>> GetAllAsync()
        {
            return await _context.Tarefas
                .Where(t => !t.EstaDeletado)
                .ToListAsync();
        }

        public async Task<Tarefa?> GetByIdAsync(int id)
        {
            return await _context.Tarefas
                .Where(t => !t.EstaDeletado)
                .SingleOrDefaultAsync(t => t.Id == id);
        }

        public async Task UpdateAsync(Tarefa tarefa)
        {
            _context.Tarefas.Update(tarefa);
            await _context.SaveChangesAsync();
        }
    }
}
