using Tetricks.Crud.Entities.Abstractions;
using Tetricks.Crud.Entities.Abstractions.DTOs;

namespace Tetricks.Crud.Services.Abstractions;

public interface ITarefaService
{
    Task<IResultadoPaginado<ITarefa>> ObterTodasAsTarefasAsync(
        IFiltroDePesquisa filtroDePesquisa,
        CancellationToken cancellationToken
    );
}
