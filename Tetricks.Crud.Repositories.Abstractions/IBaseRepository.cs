namespace Tetricks.Crud.Repositories.Abstractions;

public interface IBaseRepository<TModel>
{
    IQueryable<TModel> GetQueryable(CancellationToken cancellationToken);
}
