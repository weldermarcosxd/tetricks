using Tetricks.Crud.Entities.Abstractions.Repositorios;
using Tetricks.Crud.Entities.Abstractions.Tenants;

namespace Tetricks.Crud.Entities;

public class Tarefa : IEntidadeDeTenant, IEntidadeDeCrud
{
    public Guid Id { get; set; }
    public DateTime CriadoEm { get; set; }
    public required Usuario CriadoPor { get; set; }
    public DateTime? AtualizadoEm { get; set; } = DateTime.Now;
    public Usuario? AtualizadoPor { get; set; }
    public long TenantId { get; set; }
    public required string Descricao { get; set; }
    public bool Completa { get; set; }
}
