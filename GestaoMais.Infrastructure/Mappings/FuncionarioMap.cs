using GestaoMais.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GestaoMais.Infrastructure.Mappings
{
    public class FuncionarioMap : IEntityTypeConfiguration<Funcionario>
    {
        public void Configure(EntityTypeBuilder<Funcionario> builder)
        {
            builder.ToTable("Funcionario");
            builder.HasKey(col => col.Id);
            builder.Property(col => col.Matricula).HasDefaultValueSql("NEXT VALUE FOR shared.MySequence");
            builder.HasOne(col => col.Pessoa).WithMany().OnDelete(DeleteBehavior.Restrict);
        }
    }
}
