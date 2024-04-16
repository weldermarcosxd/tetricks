using Tetricks.Crud.Entities.Abstractions;

namespace Tetricks.Crud.Entities;

public class Usuario : IUsuario
{
    public required Guid Id { get; set; }
    public required long TenantId { get; set; }
    public required string Descricao { get; set; }
}
