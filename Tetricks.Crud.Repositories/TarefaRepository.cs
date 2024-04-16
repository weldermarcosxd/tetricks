using Tetricks.Crud.Entities;
using Tetricks.Crud.Entities.Abstractions;
using Tetricks.Crud.Repositories.Abstractions;

namespace Tetricks.Crud.Repositories;

public class TarefaRepository : BaseRepository<ITarefa>, ITarefaRepository
{
    public override Task<IQueryable<ITarefa>> GetQueryableAsync(CancellationToken cancellationToken)
    {
        var criador = new Usuario
        {
            Descricao = "Criador",
            TenantId = 12546752642,
            Id = Guid.NewGuid()
        };

        var tarefas = Enumerable.Empty<ITarefa>().AsQueryable();
        tarefas = tarefas.Append(
            new Tarefa
            {
                Id = Guid.NewGuid(),
                CriadoEm = DateTime.Today,
                TenantId = 12546752642,
                CriadoPor = criador,
                Descricao = "Golear o Palmeiras"
            }
        );
        tarefas = tarefas.Append(
            new Tarefa
            {
                Id = Guid.NewGuid(),
                CriadoEm = DateTime.Today,
                TenantId = 12546752642,
                CriadoPor = criador,
                Descricao = "Esquiar no parque"
            }
        );
        tarefas = tarefas.Append(
            new Tarefa
            {
                Id = Guid.NewGuid(),
                CriadoEm = DateTime.Today,
                TenantId = 12546752642,
                CriadoPor = criador,
                Descricao = "Alimentar o gato"
            }
        );
        tarefas = tarefas.Append(
            new Tarefa
            {
                Id = Guid.NewGuid(),
                CriadoEm = DateTime.Today,
                TenantId = 12546752642,
                CriadoPor = criador,
                Descricao = "Alimentar o gato denovo"
            }
        );
        tarefas = tarefas.Append(
            new Tarefa
            {
                Id = Guid.NewGuid(),
                CriadoEm = DateTime.Today,
                TenantId = 12546752642,
                CriadoPor = criador,
                Descricao = "Alimentar o gato denovo 2"
            }
        );
        tarefas = tarefas.Append(
            new Tarefa
            {
                Id = Guid.NewGuid(),
                CriadoEm = DateTime.Today,
                TenantId = 12546752642,
                CriadoPor = criador,
                Descricao = "Alimentar o gato denovo 3"
            }
        );
        tarefas = tarefas.Append(
            new Tarefa
            {
                Id = Guid.NewGuid(),
                CriadoEm = DateTime.Today,
                TenantId = 12546752642,
                CriadoPor = criador,
                Descricao = "Alimentar o gato denovo 4"
            }
        );

        return Task.FromResult(tarefas);
    }
}
