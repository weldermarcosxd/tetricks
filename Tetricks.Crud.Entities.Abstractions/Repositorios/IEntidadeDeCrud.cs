namespace Tetricks.Crud.Entities.Abstractions.Repositorios;

public interface IEntidadeDeCrud
{
    Guid Id { get; set; }
    DateTime CriadoEm { get; set; }
    DateTime? AtualizadoEm { get; set; }
}
