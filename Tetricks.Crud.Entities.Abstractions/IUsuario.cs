using Tetricks.Crud.Entities.Abstractions.Tenants;

namespace Tetricks.Crud.Entities.Abstractions;

public interface IUsuario : IEntidadeDeTenant
{
    Guid Id { get; set; }
    string Descricao { get; set; }
}
