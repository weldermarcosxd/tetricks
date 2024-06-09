using Tetricks.Crud.Entities.Abstractions;
using Tetricks.Crud.Repositories.Abstractions;
using Tetricks.Crud.Repositories.Contexts;

namespace Tetricks.Crud.Repositories;

public class TarefaRepository(TetricksDbContext tetricksDbContext) : ITarefaRepository
{
    public IQueryable<ITarefa> GetQueryable(CancellationToken cancellationToken)
    {
        return tetricksDbContext..OrderBy(x => x.Sequencial);
    }
}
