using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tetricks.Crud.Entities;
using Tetricks.Crud.Entities.Abstractions.DTOs;
using Tetricks.Crud.Services.Abstractions;

namespace Tetricks.Crud.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class ProdutosController(ILogger<ProdutosController> logger, IProdutoService produtoService) : ControllerBase
{
    private readonly ILogger<ProdutosController> _logger = logger;
    private readonly IProdutoService _produtoService = produtoService;

    [HttpGet(Name = "ObterProdutos")]
    public async Task<ActionResult<IResultadoPaginado<Produto>>> Get(
        [FromQuery] FiltroDePesquisa filtroDePesquisa,
        CancellationToken cancellationToken
    )
    {
        _logger.LogInformation("Acessando método Get de obtenção de ProdutosController");
        var resultadoPaginado = await _produtoService.ObterTodasAsTarefasAsync(filtroDePesquisa, cancellationToken);
        return Ok(resultadoPaginado);
    }
}
