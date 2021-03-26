using GestaoMais.Entities.Entities;
using GestaoMais.Entities.Entities.Livro;
using GestaoMais.Entities.Entities.Movimentacao;
using GestaoMais.Entities.Entities.Pessoa;
using GestaoMais.Entities.Entities.Sistema;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestaoMais.Infrastructure.Configuration
{
    public class ContextBase : DbContext
    {
        public ContextBase(DbContextOptions<ContextBase> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Livro> Livro { get; set; }
        public DbSet<LivroSituacao> LivroSituacao { get; set; }
        public DbSet<Movimentacao> Movimentacao { get; set; }
        public DbSet<MovimentacaoSituacao> MovimentacaoSituacao { get; set; }
        public DbSet<Pessoa> Pessoa { get; set; }
        public DbSet<PessoaEmail> PessoaEmail { get; set; }
        public DbSet<PessoaEndereco> PessoaEndereco { get; set; }
        public DbSet<PessoaTelefone> PessoaTelefone { get; set; }
        public DbSet<Nacionalidade> Nacionalidade { get; set; }
        public DbSet<Sexo> Sexo { get; set; }
        public DbSet<TipoPessoa> TipoPessoa { get; set; }
        public DbSet<TipoTelefone> TipoTelefone { get; set; }
        public DbSet<Aluno> Aluno { get; set; }
        public DbSet<Autor> Autor { get; set; }
        public DbSet<Categoria> Categoria { get; set; }
        public DbSet<Editora> Editora { get; set; }
        public DbSet<Endereco> Endereco { get; set; }
        public DbSet<Funcionario> Funcionario { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseSqlServer(GetStrConn());
            base.OnConfiguring(optionsBuilder);
        }

        private string GetStrConn()
        {
            var dataSource = "DESKTOP\\DESENVOLVIMENTO";
            var database = "creamt-gestao-biblioteca";
            var user = "sa";
            var password = "1234";

            return $"Data Source={dataSource};Initial Catalog={database};Integrated Security=False;User ID={user};Password={password};Connect Timeout=15;Encrypt=False;TrustServerCertificate=False";
        }
    }
}
