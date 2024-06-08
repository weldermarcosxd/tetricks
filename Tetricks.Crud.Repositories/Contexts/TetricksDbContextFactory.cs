using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Tetricks.Crud.Repositories.Extensions;

namespace Tetricks.Crud.Repositories.Contexts;

public class TetricksDbContextFactory : IDesignTimeDbContextFactory<TetricksDbContext>
{
    public TetricksDbContext CreateDbContext(string[] args)
    {
        var connectionString = Environment.GetEnvironmentVariable("PostgresSql__ConnectionString");

        var optionsBuilder = new DbContextOptionsBuilder<TetricksDbContext>();
        optionsBuilder.UseNpgsql(connectionString);
        optionsBuilder.EnableSensitiveDataLogging();
        optionsBuilder.EnableDetailedErrors();

        return new TetricksDbContext(optionsBuilder.Options);
    }
}
