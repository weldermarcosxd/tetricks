using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Tetricks.Crud.Entities;
using Tetricks.Crud.Repositories.Enums;

namespace Tetricks.Crud.Repositories.Contexts;

internal class TetricksDbContextFactory : IDesignTimeDbContextFactory<SSTetricksDbContext>
{
    public SSTetricksDbContext CreateDbContext(string[] args)
    {
        var connectionString = Environment.GetEnvironmentVariable($"{DatabaseProvider.SQLServer}__ConnectionString");

        var optionsBuilder = new DbContextOptionsBuilder<TetricksDbContext>();
        optionsBuilder.UseSqlServer(connectionString);
        optionsBuilder.EnableSensitiveDataLogging();
        optionsBuilder.EnableDetailedErrors();

        return new SSTetricksDbContext(optionsBuilder.Options);
    }
}

internal class SSTetricksDbContext : TetricksDbContext
{
    public SSTetricksDbContext(DbContextOptions<TetricksDbContext> dbContextOptions)
        : base(dbContextOptions) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Produto>().HasAlternateKey(x => x.Sequencial);
        modelBuilder.Entity<Produto>().Property(x => x.Sequencial).ValueGeneratedOnAdd();
        base.OnModelCreating(modelBuilder);
    }
}
