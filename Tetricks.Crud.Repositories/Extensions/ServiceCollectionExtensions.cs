using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Tetricks.Crud.Repositories.Abstractions;
using Tetricks.Crud.Repositories.Contexts;

namespace Tetricks.Crud.Repositories.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AdicionarRepositorios(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<ITarefaRepository, TarefaRepository>();
        services.AddScoped<IProdutoRepository, ProdutoRepository>();

        var connectionString = configuration.ObterConnectionString();

        var tipoDoProvedorDeBancoDeDados = configuration.ObterTipoDoDatabaseProvider();
        if (tipoDoProvedorDeBancoDeDados is Enums.DatabaseProvider.PostgresSql)
            services.AddDbContext<TetricksDbContext>(opt => opt.UseNpgsql(connectionString));
        if (tipoDoProvedorDeBancoDeDados is Enums.DatabaseProvider.SQLServer)
            services.AddDbContext<TetricksDbContext>(opt => opt.UseSqlServer(connectionString));
    }
}
