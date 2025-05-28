using Microsoft.EntityFrameworkCore;
using TaskManager.Domain.Entities;

public class AppDbContext : DbContext
{
    public AppDbContext() { }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Tarefa> Tarefas { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Tarefa>()
            .Property(t => t.Titulo)
            .IsRequired()
            .HasMaxLength(100);
    }
}
