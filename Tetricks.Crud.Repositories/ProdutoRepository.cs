using Tetricks.Crud.Entities.Abstractions;
using Tetricks.Crud.Repositories.Abstractions;
using Tetricks.Crud.Repositories.Contexts;

namespace Tetricks.Crud.Repositories;

public class ProdutoRepository(TetricksDbContext tetricksDbContext) : IProdutoRepository
{
    public IQueryable<IProduto> GetQueryable(CancellationToken cancellationToken)
    {
        return tetricksDbContext.Produtos.OrderBy(x => x.Sequencial);
    }
}
