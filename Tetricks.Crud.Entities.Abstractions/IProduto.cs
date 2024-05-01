using Tetricks.Crud.Entities.Abstractions.Repositorios;
using Tetricks.Crud.Entities.Abstractions.Tenants;

namespace Tetricks.Crud.Entities.Abstractions;

public interface IProduto : IEntidadeDeTenant, IEntidadeDeCrud
{
    string Descricao { get; set; }
    decimal ValorUnitario { get; set; }
}
