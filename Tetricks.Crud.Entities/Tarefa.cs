using Tetricks.Crud.Entities.Abstractions;

namespace Tetricks.Crud.Entities;

public class Tarefa : ITarefa
{
    public Guid Id { get; set; }
    public long Sequencial { get; set; }
    public DateTime CriadoEm { get; set; }
    public required Guid CriadoPorId { get; set; }
    public required Usuario CriadoPor { get; set; }
    public DateTime? AtualizadoEm { get; set; } = DateTime.Now;
    public Guid? AtualizadoPorId { get; set; }
    public Usuario? AtualizadoPor { get; set; }
    public long TenantId { get; set; }
    public required string Descricao { get; set; }
    public bool Completa { get; set; }
}
