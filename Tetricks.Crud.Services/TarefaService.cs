using Microsoft.Extensions.Configuration;
using Tetricks.Crud.Entities;
using Tetricks.Crud.Entities.Abstractions;
using Tetricks.Crud.Entities.Abstractions.DTOs;
using Tetricks.Crud.Repositories.Abstractions;
using Tetricks.Crud.Services.Abstractions;

namespace Tetricks.Crud.Services;

public class TarefaService(ITarefaRepository tarefaRepository, IConfiguration configuration) : ITarefaService
{
    private readonly ITarefaRepository _tarefaRepository = tarefaRepository;
    private readonly IConfiguration configuration = configuration;

    public async Task<IResultadoPaginado<ITarefa>> ObterTodasAsTarefasAsync(
        IFiltroDePesquisa filtroDePesquisa,
        CancellationToken cancellationToken
    )
    {
        var queryable = await _tarefaRepository.GetQueryableAsync(cancellationToken);
        var resultadoPaginado = await queryable.CriarResultadosPaginadosAsync(
            filtroDePesquisa,
            configuration,
            cancellationToken
        );

        return resultadoPaginado;
    }
}
