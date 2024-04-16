using Tetricks.Crud.Entities.Abstractions.DTOs;

namespace Tetricks.Crud.Entities.DTOs;

public record ResultadoPaginado<T> : IResultadoPaginado<T>
    where T : class
{
    public bool Sucesso { get; set; }
    public string? Mensagem { get; set; }
    public Uri? Proximo { get; set; }
    public Uri? Anterior { get; set; }
    public int PaginaAtual { get; set; }
    public int QuantidadeDePaginas { get; set; }
    public int QuantidadeDeRegistros { get; set; }
    public ICollection<T> Resultados { get; private set; } = [];
}
