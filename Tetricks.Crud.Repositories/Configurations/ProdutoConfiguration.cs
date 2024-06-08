using Bogus;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tetricks.Crud.Entities;

namespace Tetricks.Crud.Repositories;

public class ProdutoConfiguration : BaseCrudConfigurationModel<Produto>
{
    public override void Configure(EntityTypeBuilder<Produto> builder)
    {
        base.Configure(builder);
        builder.ToTable(nameof(Produto));
        builder.HasIndex(x => new { x.Descricao, x.TenantId });
        builder.HasOne(x => x.CriadoPor).WithMany(u => u.ProdutosCriados).IsRequired();
        builder.HasOne(x => x.AtualizadoPor).WithMany(u => u.ProdutosAtualizados);
    }
}
