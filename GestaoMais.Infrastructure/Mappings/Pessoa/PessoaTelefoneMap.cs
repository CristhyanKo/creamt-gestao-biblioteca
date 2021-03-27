using GestaoMais.Entities.Entities.Pessoa;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GestaoMais.Infrastructure.Mappings.Pessoa
{
    public class PessoaTelefoneMap : IEntityTypeConfiguration<PessoaTelefone>
    {
        public void Configure(EntityTypeBuilder<PessoaTelefone> builder)
        {
            builder.ToTable("PessoaTelefone");
            builder.HasKey(col => col.Id);
            builder.Property(col => col.Ddd).IsRequired();
            builder.Property(col => col.Numero).IsRequired();
            builder.Property(col => col.Principal).IsRequired();

            builder.HasOne(col => col.Pessoa).WithMany().OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(col => col.TipoTelefone).WithMany().OnDelete(DeleteBehavior.Restrict);
        }
    }
}
