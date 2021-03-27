using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestaoMais.Infrastructure.Mappings.Movimentacao
{
    public class MovimentacaoMap : IEntityTypeConfiguration<Entities.Entities.Movimentacao.Movimentacao>
    {
        public void Configure(EntityTypeBuilder<Entities.Entities.Movimentacao.Movimentacao> builder)
        {
            builder.ToTable("Movimentacao");
            builder.HasKey(col => col.Id);
            builder.HasOne(col => col.Livro).WithMany().OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(col => col.Pessoa).WithMany().OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(col => col.Funcionario).WithMany().OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(col => col.MovimentacaoSituacao).WithMany().OnDelete(DeleteBehavior.Restrict);

            builder.Property(col => col.DataEmprestimo).IsRequired();
            builder.Property(col => col.DataLimiteDevolucao).IsRequired();
        }
    }
}
