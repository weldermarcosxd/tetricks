using Microsoft.Extensions.Configuration;
using Tetricks.Crud.Entities.Abstractions;
using Tetricks.Crud.Entities.Abstractions.DTOs;
using Tetricks.Crud.Entities.DTOs;
using Tetricks.Crud.Repositories.Abstractions;
using Tetricks.Crud.Repositories.Abstractions.Extensions;
using Tetricks.Crud.Services.Abstractions;

namespace Tetricks.Crud.Services;

public class TarefaService(ITarefaRepository tarefaRepository, IConfiguration configuration) : ITarefaService
{
    public async Task<IResultadoPaginado<ITarefa>> ObterTodasAsTarefasAsync(
        IFiltroDePesquisa filtroDePesquisa,
        CancellationToken cancellationToken
    )
    {
        var queryable = tarefaRepository.GetQueryable(cancellationToken);
        var resultadoPaginado = await queryable.CriarResultadosPaginadosAsync<ITarefa, ResultadoPaginado<ITarefa>>(
            filtroDePesquisa,
            configuration,
            cancellationToken
        );

        return resultadoPaginado;
    }
}
