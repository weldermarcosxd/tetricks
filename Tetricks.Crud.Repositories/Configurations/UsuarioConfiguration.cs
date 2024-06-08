using Bogus;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tetricks.Crud.Entities;

namespace Tetricks.Crud.Repositories.Configurations;

public class UsuarioConfiguration : IEntityTypeConfiguration<Usuario>
{
    public void Configure(EntityTypeBuilder<Usuario> builder)
    {
        builder.ToTable(nameof(Usuario));
        builder.HasIndex(x => new { x.Id });
        builder.HasIndex(x => new { x.Descricao });
    }
}
