using Tetricks.Crud.Entities.Abstractions.DTOs;

namespace Tetricks.Crud.Entities;

public class FiltroDePesquisa : IFiltroDePesquisa
{
    public int NumeroDaPagina { get; set; } = 1;
    public int QuantidadePorPagina { get; set; } = 10;
}
