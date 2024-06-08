﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Tetricks.Crud.Entities.Abstractions.DTOs;
using Tetricks.Crud.Entities.Abstractions.Repositorios;
using Tetricks.Crud.Entities.DTOs;
using Tetricks.Crud.Services.Extensions;

namespace Tetricks.Crud.Services;

public static class QueryableExtensions
{
    public static async Task<IResultadoPaginado<TModel>> CriarResultadosPaginadosAsync<TModel>(
        this IQueryable<TModel> queryable,
        IFiltroDePesquisa filtroDePesquisa,
        IConfiguration configuration,
        CancellationToken cancellationToken
    )
        where TModel : class, IEntidadeDeCrud
    {
        cancellationToken.ThrowIfCancellationRequested();

        var quantidade = await queryable.CountAsync(cancellationToken);

        if (quantidade <= decimal.Zero)
            return new ResultadoPaginado<TModel>() { Sucesso = true };

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

        var resultadoPaginado = new ResultadoPaginado<TModel>()
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
