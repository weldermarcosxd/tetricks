using Microsoft.Extensions.DependencyInjection;
using Tetricks.Crud.Repositories.Abstractions;

namespace Tetricks.Crud.Repositories.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AdicionarRepositorios(this IServiceCollection services)
    {
        services.AddScoped<ITarefaRepository, TarefaRepository>();
    }
}
