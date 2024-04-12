namespace Tetricks.Crud.Entities.Abstractions.DTOs;

public interface IFiltroDePesquisa
{
    int NumeroDaPagina { get; set; }
    int QuantidadePorPagina { get; set; }
}
