using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tetricks.Crud.Entities;

namespace Tetricks.Crud.Repositories;

public class TarefaConfiguration : BaseCrudConfigurationModel<Tarefa>
{
    public override void Configure(EntityTypeBuilder<Tarefa> builder)
    {
        base.Configure(builder);
        builder.ToTable(nameof(Tarefa));
        builder.HasIndex(x => new { x.Descricao, x.TenantId });
    }
}
