namespace Tetricks.Crud.Repositories.Abstractions;

public interface IBaseRepository<TModel>
{
    Task<IQueryable<TModel>> GetQueryableAsync(CancellationToken cancellationToken);
}
