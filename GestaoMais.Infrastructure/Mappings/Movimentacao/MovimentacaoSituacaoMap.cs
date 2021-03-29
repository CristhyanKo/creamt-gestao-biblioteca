using GestaoMais.Entities.Entities.Movimentacao;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GestaoMais.Infrastructure.Mappings.Movimentacao
{
    public class MovimentacaoSituacaoMap : IEntityTypeConfiguration<MovimentacaoSituacao>
    {
        public void Configure(EntityTypeBuilder<MovimentacaoSituacao> builder)
        {
            builder.ToTable("MovimentacaoSituacao");
            builder.HasKey(col => col.Id);
            builder.Property(col => col.Nome).IsRequired();
        }
    }
}
