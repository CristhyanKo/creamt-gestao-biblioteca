using GestaoMais.Application.App;
using GestaoMais.Application.App.Livro;
using GestaoMais.Application.App.LivroSituacao;
using GestaoMais.Application.App.Movimentacao;
using GestaoMais.Application.App.MovimentacaoSituacao;
using GestaoMais.Application.App.Pessoa;
using GestaoMais.Application.App.Sistema;
using GestaoMais.Domain.Interfaces;
using GestaoMais.Domain.Interfaces.Generics;
using GestaoMais.Domain.Interfaces.Livro;
using GestaoMais.Domain.Interfaces.Movimentacao;
using GestaoMais.Domain.Interfaces.Pessoa;
using GestaoMais.Domain.Interfaces.Sistema;
using GestaoMais.Infrastructure.Repository.Generics;
using GestaoMais.Infrastructure.Repository.Repositories;
using GestaoMais.Infrastructure.Repository.Repositories.Livro;
using GestaoMais.Infrastructure.Repository.Repositories.Movimentacao;
using GestaoMais.Infrastructure.Repository.Repositories.Pessoa;
using GestaoMais.Infrastructure.Repository.Repositories.Sistema;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace GestaoMais.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton(typeof(IGeneric<>), typeof(RepositoryGeneric<>));

            services.AddSingleton<ILivro, RepositoryLivro>();
            services.AddSingleton<ILivroSituacao, RepositoryLivroSituacao>();
            services.AddSingleton<IMovimentacao, RepositoryMovimentacao>();
            services.AddSingleton<IMovimentacaoSituacao, RepositoryMovimentacaoSituacao>();
            services.AddSingleton<IPessoa, RepositoryPessoa>();
            services.AddSingleton<IPessoaEmail, RepositoryPessoaEmail>();
            services.AddSingleton<IPessoaEndereco, RepositoryPessoaEndereco>();
            services.AddSingleton<IPessoaTelefone, RepositoryPessoaTelefone>();
            services.AddSingleton<INacionalidade, RepositoryNacionalidade>();
            services.AddSingleton<ISexo, RepositorySexo>();
            services.AddSingleton<ITipoPessoa, RepositoryTipoPessoa>();
            services.AddSingleton<ITipoTelefone, RepositoryTipoTelefone>();
            services.AddSingleton<IAluno, RepositoryAluno>();
            services.AddSingleton<IAutor, RepositoryAutor>();
            services.AddSingleton<ICategoria, RepositoryCategoria>();
            services.AddSingleton<IEndereco, RepositoryEndereco>();
            services.AddSingleton<IFuncionario, RepositoryFuncionario>();

            services.AddSingleton<Application.Interfaces.Livro.ILivro, AppLivro>();
            services.AddSingleton<Application.Interfaces.Livro.ILivroSituacao, AppLivroSituacao>();
            services.AddSingleton<Application.Interfaces.Movimentacao.IMovimentacao, AppMovimentacao>();
            services.AddSingleton<Application.Interfaces.Movimentacao.IMovimentacaoSituacao, AppMovimentacaoSituacao>();
            services.AddSingleton<Application.Interfaces.Pessoa.IPessoa, AppPessoa>();
            services.AddSingleton<Application.Interfaces.Pessoa.IPessoaEmail, AppPessoaEmail>();
            services.AddSingleton<Application.Interfaces.Pessoa.IPessoaEndereco, AppPessoaEndereco>();
            services.AddSingleton<Application.Interfaces.Pessoa.IPessoaTelefone, AppPessoaTelefone>();
            services.AddSingleton<Application.Interfaces.Sistema.INacionalidade, AppNacionalidade>();
            services.AddSingleton<Application.Interfaces.Sistema.ISexo, AppSexo>();
            services.AddSingleton<Application.Interfaces.Sistema.ITipoPessoa, AppTipoPessoa>();
            services.AddSingleton<Application.Interfaces.Sistema.ITipoTelefone, AppTipoTelefone>();
            services.AddSingleton<Application.Interfaces.IAluno, AppAluno>();
            services.AddSingleton<Application.Interfaces.IAutor, AppAutor>();
            services.AddSingleton<Application.Interfaces.ICategoria, AppCategoria>();
            services.AddSingleton<Application.Interfaces.IEndereco, AppEndereco>();
            services.AddSingleton<Application.Interfaces.IFuncionario, AppFuncionario>();

            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
