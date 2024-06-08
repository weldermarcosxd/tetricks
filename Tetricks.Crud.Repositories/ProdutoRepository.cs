using Tetricks.Crud.Entities.Abstractions;
using Tetricks.Crud.Repositories.Abstractions;
using Tetricks.Crud.Repositories.Contexts;

namespace Tetricks.Crud.Repositories;

public class ProdutoRepository : IProdutoRepository
{
    private readonly TetricksDbContext _tetricksDbContext;

    public ProdutoRepository(TetricksDbContext tetricksDbContext)
    {
        _tetricksDbContext = tetricksDbContext;
    }

    public IQueryable<IProduto> GetQueryable(CancellationToken cancellationToken)
    {
        return _tetricksDbContext.Produtos.OrderBy(x => x.Sequencial).AsQueryable();
    }
}
