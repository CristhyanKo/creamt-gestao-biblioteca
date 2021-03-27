using GestaoMais.Entities.Entities.Sistema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GestaoMais.Infrastructure.Mappings.Sistema
{
    public class TipoPessoaMap : IEntityTypeConfiguration<TipoPessoa>
    {
        public void Configure(EntityTypeBuilder<TipoPessoa> builder)
        {
            builder.ToTable("TipoPessoa");
            builder.HasKey(col => col.Id);
            builder.Property(col => col.Descricao).IsRequired();
        }
    }
}
