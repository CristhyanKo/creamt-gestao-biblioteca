using GestaoMais.Entities.Entities.Sistema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GestaoMais.Infrastructure.Mappings.Sistema
{
    public class NacionalidadeMap : IEntityTypeConfiguration<Nacionalidade>
    {
        public void Configure(EntityTypeBuilder<Nacionalidade> builder)
        {
            builder.ToTable("Nacionalidade");
            builder.HasKey(col => col.Id);
            builder.Property(col => col.Descricao).IsRequired();
        }
    }
}
