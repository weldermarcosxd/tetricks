using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Tetricks.Crud.Repositories.Enums;

namespace Tetricks.Crud.Repositories.Contexts;

internal class TetricksPostgresDbContextFactory : IDesignTimeDbContextFactory<PgTetricksDbContext>
{
    public PgTetricksDbContext CreateDbContext(string[] args)
    {
        var connectionString = Environment.GetEnvironmentVariable($"{DatabaseProvider.PostgresSql}__ConnectionString");

        var optionsBuilder = new DbContextOptionsBuilder<TetricksDbContext>();
        optionsBuilder.UseNpgsql(connectionString);
        optionsBuilder.EnableSensitiveDataLogging();
        optionsBuilder.EnableDetailedErrors();

        return new PgTetricksDbContext(optionsBuilder.Options);
    }
}

internal class PgTetricksDbContext : TetricksDbContext
{
    public PgTetricksDbContext(DbContextOptions<TetricksDbContext> dbContextOptions)
        : base(dbContextOptions) { }
}
