using GestaoMais.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GestaoMais.Infrastructure.Mappings
{
    public class EnderecoMap : IEntityTypeConfiguration<Endereco>
    {
        public void Configure(EntityTypeBuilder<Endereco> builder)
        {
            builder.ToTable("Endereco");
            builder.HasKey(col => col.Id);
            builder.Property(col => col.Logradouro).IsRequired();
            builder.Property(col => col.Bairro).IsRequired();
            builder.Property(col => col.Municipio).IsRequired();
            builder.Property(col => col.Cep).IsRequired();
            builder.Property(col => col.Numero).IsRequired();
        }
    }
}
