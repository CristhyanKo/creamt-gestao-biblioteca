using GestaoMais.Entities.Entities.Pessoa;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GestaoMais.Infrastructure.Mappings.Pessoa
{
    public class PessoaEnderecoMap : IEntityTypeConfiguration<PessoaEndereco>
    {
        public void Configure(EntityTypeBuilder<PessoaEndereco> builder)
        {
            builder.ToTable("PessoaEndereco");
            builder.HasKey(col => col.Id);
            builder.Property(col => col.Principal).IsRequired();

            builder.HasOne(col => col.Pessoa).WithMany().OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(col => col.Endereco).WithMany().OnDelete(DeleteBehavior.Restrict);
        }
    }
}
