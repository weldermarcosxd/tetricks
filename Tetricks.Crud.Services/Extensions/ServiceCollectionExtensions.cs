using Microsoft.Extensions.DependencyInjection;
using Tetricks.Crud.Services.Abstractions;

namespace Tetricks.Crud.Services.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AdicionarServicos(this IServiceCollection services)
    {
        services.AddScoped<ITarefaService, TarefaService>();
    }
}
