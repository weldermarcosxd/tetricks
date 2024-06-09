using System.Reflection;
using Bogus;
using Microsoft.EntityFrameworkCore;
using Tetricks.Crud.Entities;

namespace Tetricks.Crud.Repositories.Contexts;

public class TetricksDbContext : DbContext
{
    public TetricksDbContext(DbContextOptions<TetricksDbContext> dbContextOptions)
        : base(dbContextOptions) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        var tenantIdFake = new Faker().Random.Long(1, 1_000_000);

        var usuarioFake = new Faker<Usuario>()
            .RuleFor(x => x.Id, f => f.Random.Guid())
            .RuleFor(x => x.TenantId, _ => tenantIdFake)
            .RuleFor(x => x.Descricao, f => f.Name.FirstName())
            .RuleFor(x => x.Descricao, f => f.Commerce.ProductName())
            .Generate();

        modelBuilder.Entity<Usuario>().HasData(usuarioFake);

        var produtosFake = new Faker<Produto>()
            .RuleFor(x => x.Id, f => f.Random.Guid())
            .RuleFor(x => x.TenantId, _ => tenantIdFake)
            .RuleFor(x => x.CriadoEm, f => f.Date.PastOffset(1).UtcDateTime)
            .RuleFor(x => x.AtualizadoEm, f => null)
            .RuleFor(x => x.CriadoPorId, _ => usuarioFake.Id)
            .RuleFor(x => x.Descricao, f => f.Commerce.ProductName())
            .RuleFor(x => x.ValorUnitario, f => decimal.Parse(f.Commerce.Price()))
            .Generate(10_000);

        modelBuilder.Entity<Produto>().HasData(produtosFake);
    }

    public DbSet<Produto> Produtos { get; set; }
    public DbSet<Tarefa> Tarefas { get; set; }
    public DbSet<Usuario> Usuarios { get; set; }
}
