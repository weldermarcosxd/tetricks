using Tetricks.Crud.Entities.Abstractions;
using Tetricks.Crud.Entities.Abstractions.DTOs;

namespace Tetricks.Crud.Services.Abstractions;

public interface IProdutoService
{
    Task<IResultadoPaginado<IProduto>> ObterTodasAsTarefasAsync(
        IFiltroDePesquisa filtroDePesquisa,
        CancellationToken cancellationToken
    );
}
