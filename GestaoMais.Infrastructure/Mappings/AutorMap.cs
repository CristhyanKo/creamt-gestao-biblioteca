using GestaoMais.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GestaoMais.Infrastructure.Mappings
{
    public class AutorMap : IEntityTypeConfiguration<Autor>
    {
        public void Configure(EntityTypeBuilder<Autor> builder)
        {
            builder.ToTable("Autor");
            builder.HasKey(col => col.Id);
            builder.HasOne(col => col.Pessoa).WithMany().OnDelete(DeleteBehavior.Restrict);
        }
    }
}
