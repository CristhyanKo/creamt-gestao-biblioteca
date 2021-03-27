using GestaoMais.Entities.Entities.Sistema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GestaoMais.Infrastructure.Mappings.Sistema
{
    public class TipoTelefoneMap : IEntityTypeConfiguration<TipoTelefone>
    {
        public void Configure(EntityTypeBuilder<TipoTelefone> builder)
        {
            builder.ToTable("TipoTelefone");
            builder.HasKey(col => col.Id);
            builder.Property(col => col.Descricao).IsRequired();
        }
    }
}
