using GestaoMais.Domain.Interfaces.Pessoa;
using GestaoMais.Infrastructure.Configuration;
using GestaoMais.Infrastructure.Repository.Generics;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GestaoMais.Infrastructure.Repository.Repositories.Pessoa
{
    public class RepositoryPessoa : RepositoryGeneric<Entities.Entities.Pessoa.Pessoa>, IPessoa {
        private readonly DbContextOptions<ContextBase> _optionsBuilder;

        public RepositoryPessoa()
        {
            _optionsBuilder = new DbContextOptions<ContextBase>();
        }
        public new async Task<List<Entities.Entities.Pessoa.Pessoa>> List()
        {
            using (var data = new ContextBase(_optionsBuilder))
            {
                return await data.Set<Entities.Entities.Pessoa.Pessoa>().Include(obj => obj.Nacionalidade).Include(obj => obj.Sexo).Include(obj => obj.TipoPessoa).AsNoTracking().ToListAsync();
            }
        }

        public new async Task<Entities.Entities.Pessoa.Pessoa> GetById(int id)
        {
            using (var data = new ContextBase(_optionsBuilder))
            {
                return await data.Set<Entities.Entities.Pessoa.Pessoa>().Include(obj => obj.Nacionalidade).Include(obj => obj.Sexo).Include(obj => obj.TipoPessoa).FirstOrDefaultAsync(filter => filter.Id == id);
            }
        }
    }
}

