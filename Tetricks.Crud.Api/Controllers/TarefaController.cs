using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tetricks.Crud.Entities;
using Tetricks.Crud.Entities.Abstractions.DTOs;
using Tetricks.Crud.Services.Abstractions;

namespace Tetricks.Crud.Api.Controllers;

[Authorize]
[ApiController]
[Route("[controller]")]
public class TarefaController(ILogger<TarefaController> logger, ITarefaService tarefaService) : ControllerBase
{
    private readonly ILogger<TarefaController> _logger = logger;
    private readonly ITarefaService _tarefaService = tarefaService;

    [HttpGet(Name = "ObterTarefas")]
    public async Task<ActionResult<IResultadoPaginado<Tarefa>>> Get(
        [FromQuery] FiltroDePesquisa filtroDePesquisa,
        CancellationToken cancellationToken
    )
    {
        _logger.LogInformation($"Acessando método {nameof(Get)} de obtenção de {nameof(TarefaController)}");
        var resultadoPaginado = await _tarefaService.ObterTodasAsTarefasAsync(filtroDePesquisa, cancellationToken);
        return Ok(resultadoPaginado);
    }
}
