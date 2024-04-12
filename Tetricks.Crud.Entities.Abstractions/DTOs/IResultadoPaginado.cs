namespace Tetricks.Crud.Entities.Abstractions.DTOs;

public interface IResultadoPaginado<T>
    where T : class
{
    bool Sucesso { get; set; }
    string? Mensagem { get; set; }
    Uri? Proximo { get; set; }
    Uri? Anterior { get; set; }
    int PaginaAtual { get; set; }
    int QuantidadeDePaginas { get; set; }
    int QuantidadeDeRegistros { get; set; }
    ICollection<T> Resultados { get; }
}
