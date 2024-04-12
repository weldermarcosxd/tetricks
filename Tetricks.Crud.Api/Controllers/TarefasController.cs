using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tetricks.Crud.Entities;
using Tetricks.Crud.Entities.Abstractions.DTOs;
using Tetricks.Crud.Entities.DTOs;

namespace Tetricks.Crud.Api.Controllers;

[Authorize]
[ApiController]
[Route("[controller]")]
public class TarefasController(ILogger<TarefasController> logger) : ControllerBase
{
    private readonly ILogger<TarefasController> _logger = logger;

    [HttpGet(Name = "ObterTarefas")]
    public ActionResult<IResultadoPaginado<Tarefa>> Get()
    {
        var user = User?.FindFirst("Name")?.Value ?? "Anonymous";

        _logger.LogInformation(HttpContext.GetEndpoint()!.ToString() + " " + user);
        var resultadoPaginado = new ResultadoPaginado<Tarefa>();

        var criador = new Usuario
        {
            Descricao = "Criador",
            TenantId = 12546752642,
            Id = Guid.NewGuid()
        };
        resultadoPaginado.Sucesso = true;
        resultadoPaginado.PaginaAtual = 1;
        resultadoPaginado.QuantidadeDePaginas = 1;
        resultadoPaginado.Resultados.Add(
            new Tarefa
            {
                Id = Guid.NewGuid(),
                CriadoEm = DateTime.Today,
                TenantId = 12546752642,
                CriadoPor = criador,
                Descricao = "Alimentar o gato"
            }
        );
        resultadoPaginado.Resultados.Add(
            new Tarefa
            {
                Id = Guid.NewGuid(),
                CriadoEm = DateTime.Today,
                TenantId = 12546752642,
                CriadoPor = criador,
                Descricao = "Colher morangos"
            }
        );
        resultadoPaginado.Resultados.Add(
            new Tarefa
            {
                Id = Guid.NewGuid(),
                CriadoEm = DateTime.Today,
                TenantId = 12546752642,
                CriadoPor = criador,
                Descricao = "Esquiar no parque"
            }
        );
        resultadoPaginado.Resultados.Add(
            new Tarefa
            {
                Id = Guid.NewGuid(),
                CriadoEm = DateTime.Today,
                TenantId = 12546752642,
                CriadoPor = criador,
                Descricao = "Golear o Palmeiras"
            }
        );
        resultadoPaginado.Resultados.Add(
            new Tarefa
            {
                Id = Guid.NewGuid(),
                CriadoEm = DateTime.Today,
                TenantId = 12546752642,
                CriadoPor = criador,
                Descricao = "Justificar o voto"
            }
        );
        resultadoPaginado.QuantidadeDeRegistros = resultadoPaginado.Resultados.Count;

        return Ok(resultadoPaginado);
    }
}
