using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GestaoMais.Infrastructure.Mappings.Livro
{
    public class LivroMap : IEntityTypeConfiguration<Entities.Entities.Livro.Livro>
    {
        public void Configure(EntityTypeBuilder<Entities.Entities.Livro.Livro> builder)
        {
            builder.ToTable("Livro");
            builder.HasKey(col => col.Id);
            builder.HasIndex(col => col.ISBN).IsUnique();
            builder.Property(col => col.Titulo).IsRequired();
            builder.Property(col => col.Edicao).IsRequired();
            builder.Property(col => col.Editora).IsRequired();
            builder.Property(col => col.ISBN).IsRequired();
            builder.Property(col => col.Ano).IsRequired();

            builder.HasOne(col => col.Categoria).WithMany().OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(col => col.LivroSituacao).WithMany().OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(col => col.Autor).WithMany().OnDelete(DeleteBehavior.Restrict);
        }
    }
}
