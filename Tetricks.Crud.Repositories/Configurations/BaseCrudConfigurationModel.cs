using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.ValueGeneration;
using Tetricks.Crud.Entities.Abstractions.Repositorios;

namespace Tetricks.Crud.Repositories;

public abstract class BaseCrudConfigurationModel<TModel> : IEntityTypeConfiguration<TModel>
    where TModel : class, IEntidadeDeCrud
{
    public virtual void Configure(EntityTypeBuilder<TModel> builder)
    {
        builder.HasKey(x => x.Id);
        builder.HasIndex(x => x.Sequencial).IsUnique();
        builder.Property(b => b.Id).IsRequired().HasValueGenerator<GuidValueGenerator>();
        builder.Property(b => b.Sequencial).UseIdentityColumn().HasIdentityOptions(startValue: 1, incrementBy: 1);
        builder.Property(e => e.CriadoEm).ValueGeneratedOnAdd();
        builder.Property(x => x.AtualizadoEm).ValueGeneratedOnUpdate();
    }
}
