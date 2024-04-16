using Tetricks.Crud.Repositories.Abstractions;

namespace Tetricks.Crud.Repositories;

public abstract class BaseRepository<TModel> : IBaseRepository<TModel>
{
    public virtual Task<IQueryable<TModel>> GetQueryableAsync(CancellationToken cancellationToken)
    {
        return Task.FromResult(Enumerable.Empty<TModel>().AsQueryable());
    }
}
