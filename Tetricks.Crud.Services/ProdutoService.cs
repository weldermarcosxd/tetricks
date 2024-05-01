using Microsoft.Extensions.Configuration;
using Tetricks.Crud.Entities;
using Tetricks.Crud.Entities.Abstractions;
using Tetricks.Crud.Entities.Abstractions.DTOs;
using Tetricks.Crud.Repositories.Abstractions;
using Tetricks.Crud.Services.Abstractions;

namespace Tetricks.Crud.Services;

public class ProdutoService(IProdutoRepository produtoRepository, IConfiguration configuration) : IProdutoService
{
    private readonly IProdutoRepository _produtoRepository = produtoRepository;
    private readonly IConfiguration _configuration = configuration;

    public async Task<IResultadoPaginado<IProduto>> ObterTodasAsTarefasAsync(
        IFiltroDePesquisa filtroDePesquisa,
        CancellationToken cancellationToken
    )
    {
        var produtos = new List<IProduto>(100_000);
        for (int i = 0; i < 100_000; i++)
        {
            produtos.Add(
                new Produto
                {
                    Id = Guid.NewGuid(),
                    Descricao = $"Produto {i}",
                    ValorUnitario = 10 + i / 10
                }
            );
        }
        var resultadoPaginado = await produtos
            .AsQueryable()
            .CriarResultadosPaginadosAsync(filtroDePesquisa, _configuration, cancellationToken);

        return resultadoPaginado;
    }
}
