using GestaoMais.Entities.Entities;
using GestaoMais.Entities.Entities.Livro;
using GestaoMais.Entities.Entities.Movimentacao;
using GestaoMais.Entities.Entities.Pessoa;
using GestaoMais.Entities.Entities.Sistema;
using GestaoMais.Infrastructure.Mappings;
using GestaoMais.Infrastructure.Mappings.Livro;
using GestaoMais.Infrastructure.Mappings.Movimentacao;
using GestaoMais.Infrastructure.Mappings.Pessoa;
using GestaoMais.Infrastructure.Mappings.Sistema;
using Microsoft.EntityFrameworkCore;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;

namespace GestaoMais.Infrastructure.Configuration
{
    public class ContextBase : DbContext
    {
        public ContextBase()
        {

        }

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
        public DbSet<Endereco> Endereco { get; set; }
        public DbSet<Funcionario> Funcionario { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseSqlServer(GetStrConn());
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new LivroMap());
            modelBuilder.ApplyConfiguration(new LivroSituacaoMap());
            modelBuilder.ApplyConfiguration(new MovimentacaoMap());
            modelBuilder.ApplyConfiguration(new MovimentacaoSituacaoMap());
            modelBuilder.ApplyConfiguration(new PessoaMap());
            modelBuilder.ApplyConfiguration(new PessoaEmailMap());
            modelBuilder.ApplyConfiguration(new PessoaEnderecoMap());
            modelBuilder.ApplyConfiguration(new PessoaTelefoneMap());
            modelBuilder.ApplyConfiguration(new NacionalidadeMap());
            modelBuilder.ApplyConfiguration(new SexoMap());
            modelBuilder.ApplyConfiguration(new TipoPessoaMap());
            modelBuilder.ApplyConfiguration(new TipoTelefoneMap());
            modelBuilder.ApplyConfiguration(new AlunoMap());
            modelBuilder.ApplyConfiguration(new AutorMap());
            modelBuilder.ApplyConfiguration(new CategoriaMap());
            modelBuilder.ApplyConfiguration(new EnderecoMap());
            modelBuilder.ApplyConfiguration(new FuncionarioMap());

            base.OnModelCreating(modelBuilder);
        }

        private string GetStrConn()
        {
            var dataSource = "DESKTOP-MPN10IM\\SQL";
            var database = "creamt-gestao-biblioteca";
            var user = "sa";
            var password = "123456";

            return $"Data Source={dataSource};Initial Catalog={database};Integrated Security=False;User ID={user};Password={password};Connect Timeout=15;Encrypt=False;TrustServerCertificate=False";
        }
    }
}
