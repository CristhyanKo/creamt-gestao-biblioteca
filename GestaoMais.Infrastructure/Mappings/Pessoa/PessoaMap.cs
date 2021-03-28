using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GestaoMais.Infrastructure.Mappings.Pessoa
{
    public class PessoaMap : IEntityTypeConfiguration<Entities.Entities.Pessoa.Pessoa>
    {
        public void Configure(EntityTypeBuilder<Entities.Entities.Pessoa.Pessoa> builder)
        {
            builder.ToTable("Pessoa");
            builder.HasKey(col => col.Id);
            builder.Property(col => col.Nome).IsRequired();
            builder.Property(col => col.CpfCnpj).IsRequired();
            builder.Property(col => col.Rg).IsRequired();
            builder.Property(col => col.DataNascimento).IsRequired();
            builder.Property(col => col.Ativo).IsRequired();

            builder.HasOne(col => col.Nacionalidade).WithMany().OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(col => col.Sexo).WithMany().OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(col => col.TipoPessoa).WithMany().OnDelete(DeleteBehavior.Restrict);
        }
    }
}
