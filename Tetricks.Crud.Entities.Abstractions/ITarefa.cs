using Tetricks.Crud.Entities.Abstractions.Repositorios;
using Tetricks.Crud.Entities.Abstractions.Tenants;

namespace Tetricks.Crud.Entities.Abstractions;

public interface ITarefa : IEntidadeDeTenant, IEntidadeDeCrud
{
    string Descricao { get; set; }
    bool Completa { get; set; }
    IUsuario CriadoPor { get; set; }
    IUsuario? AtualizadoPor { get; set; }
}
