namespace Tetricks.Crud.Entities.Abstractions.DTOs;

public interface IResultado<T>
    where T : class
{
    bool Sucesso { get; set; }
    string? Mensagem { get; set; }
    IEnumerable<T> Resultados { get; set; }
}
