using Microsoft.Extensions.Configuration;
using Tetricks.Crud.Entities.Abstractions;
using Tetricks.Crud.Entities.Abstractions.DTOs;
using Tetricks.Crud.Entities.DTOs;
using Tetricks.Crud.Repositories.Abstractions;
using Tetricks.Crud.Repositories.Abstractions.Extensions;
using Tetricks.Crud.Services.Abstractions;

namespace Tetricks.Crud.Services;

public class ProdutoService(IProdutoRepository produtoRepository, IConfiguration configuration) : IProdutoService
{
    public async Task<IResultadoPaginado<IProduto>> ObterTodasOsProdutosAsync(
        IFiltroDePesquisa filtroDePesquisa,
        CancellationToken cancellationToken
    )
    {
        var queryable = produtoRepository.GetQueryable(cancellationToken);
        var resultadoPaginado = await queryable.CriarResultadosPaginadosAsync<IProduto, ResultadoPaginado<IProduto>>(
            filtroDePesquisa,
            configuration,
            cancellationToken
        );

        return resultadoPaginado;
    }
}
