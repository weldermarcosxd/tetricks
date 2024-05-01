using Tetricks.Crud.Entities.Abstractions;

namespace Tetricks.Crud.Entities;

public class Produto : IProduto
{
    public Guid Id { get; set; }
    public DateTime CriadoEm { get; set; }
    public DateTime? AtualizadoEm { get; set; } = DateTime.Now;
    public long TenantId { get; set; }
    public required string Descricao { get; set; }
    public decimal ValorUnitario { get; set; }
}
