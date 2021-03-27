using GestaoMais.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GestaoMais.Infrastructure.Mappings
{
    public class AlunoMap : IEntityTypeConfiguration<Aluno>
    {
        public void Configure(EntityTypeBuilder<Aluno> builder)
        {
            builder.ToTable("Aluno");
            builder.HasKey(col => col.Id);
            builder.Property(col => col.Matricula).IsRequired();
            builder.HasOne(col => col.Pessoa).WithMany().OnDelete(DeleteBehavior.Restrict);
        }
    }
}
