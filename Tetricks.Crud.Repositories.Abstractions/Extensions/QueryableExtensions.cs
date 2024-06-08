using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Tetricks.Crud.Entities.Abstractions.DTOs;
using Tetricks.Crud.Entities.Abstractions.Repositorios;

namespace Tetricks.Crud.Repositories.Abstractions.Extensions;

public static class QueryableExtensions
{
    public static async Task<TResult> CriarResultadosPaginadosAsync<TModel, TResult>(
        this IQueryable<TModel> queryable,
        IFiltroDePesquisa filtroDePesquisa,
        IConfiguration configuration,
        CancellationToken cancellationToken
    )
        where TModel : class, IEntidadeDeCrud
        where TResult : IResultadoPaginado<TModel>, new()
    {
        cancellationToken.ThrowIfCancellationRequested();

        var quantidade = await queryable.CountAsync(cancellationToken);

        if (quantidade <= decimal.Zero)
            return new TResult() { Sucesso = true };

        var primeiraEntidade = await queryable.FirstAsync(cancellationToken);
        var nomeDaentidadeListada = primeiraEntidade.GetType().Name;

        var dominioBase = configuration.ObterDominioBase();
        var quantidadeTotal = await queryable.CountAsync(cancellationToken);
        var totalDePaginas = (int)Math.Ceiling((double)quantidadeTotal / filtroDePesquisa.QuantidadePorPagina);
        var urlPaginaAnterior =
            filtroDePesquisa.NumeroDaPagina <= 1
                ? null
                : $"{dominioBase}/{nomeDaentidadeListada}?NumeroDaPagina={filtroDePesquisa.NumeroDaPagina - 1}&QuantidadePorPagina={filtroDePesquisa.QuantidadePorPagina}";

        var urlProximaPagina =
            filtroDePesquisa.NumeroDaPagina >= totalDePaginas
                ? null
                : $"{dominioBase}/{nomeDaentidadeListada}?NumeroDaPagina={filtroDePesquisa.NumeroDaPagina + 1}&QuantidadePorPagina={filtroDePesquisa.QuantidadePorPagina}";

        var resultadoPaginado = new TResult()
        {
            QuantidadeDeRegistros = quantidadeTotal,
            Anterior = urlPaginaAnterior is null ? null : new Uri(urlPaginaAnterior),
            Proximo = urlProximaPagina is null ? null : new Uri(urlProximaPagina),
            Mensagem = null,
            PaginaAtual = filtroDePesquisa.NumeroDaPagina,
            QuantidadeDePaginas = totalDePaginas,
            Sucesso = true
        };

        var resultados = await queryable
            .Skip((filtroDePesquisa.NumeroDaPagina - 1) * filtroDePesquisa.QuantidadePorPagina)
            .Take(filtroDePesquisa.QuantidadePorPagina)
            .ToListAsync(cancellationToken);

        resultados.ForEach(resultadoPaginado.Resultados.Add);

        return resultadoPaginado;
    }
}
