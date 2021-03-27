using GestaoMais.Entities.Entities.Pessoa;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GestaoMais.Infrastructure.Mappings.Pessoa
{
    public class PessoaEmailMap : IEntityTypeConfiguration<PessoaEmail>
    {
        public void Configure(EntityTypeBuilder<PessoaEmail> builder)
        {
            builder.ToTable("PessoaEmail");
            builder.HasKey(col => col.Id);
            builder.Property(col => col.Email).IsRequired();
            builder.Property(col => col.Principal).IsRequired();

            builder.HasOne(col => col.Pessoa).WithMany().OnDelete(DeleteBehavior.Restrict);
        }
    }
}
