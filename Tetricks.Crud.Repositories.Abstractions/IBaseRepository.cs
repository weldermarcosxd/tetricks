namespace Tetricks.Crud.Repositories.Abstractions;

public interface IBaseRepository<out TModel>
{
    IQueryable<TModel> GetQueryable(CancellationToken cancellationToken);
}
