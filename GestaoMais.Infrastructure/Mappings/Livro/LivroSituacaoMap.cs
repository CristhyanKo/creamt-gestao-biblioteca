using GestaoMais.Entities.Entities.Livro;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GestaoMais.Infrastructure.Mappings.Livro
{
    public class LivroSituacaoMap : IEntityTypeConfiguration<LivroSituacao>
    {
        public void Configure(EntityTypeBuilder<LivroSituacao> builder)
        {
            builder.ToTable("LivroSituacao");
            builder.HasKey(col => col.Id);
            builder.Property(col => col.Nome).IsRequired();
        }
    }
}
