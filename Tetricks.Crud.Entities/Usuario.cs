using Tetricks.Crud.Entities.Abstractions.Tenants;

namespace Tetricks.Crud.Entities;

public class Usuario : IEntidadeDeTenant
{
    public required Guid Id { get; set; }
    public required long TenantId { get; set; }
    public required string Descricao { get; set; }
}
