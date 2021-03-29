using GestaoMais.Domain.Interfaces.Pessoa;
using GestaoMais.Entities.Entities.Pessoa;
using GestaoMais.Infrastructure.Configuration;
using GestaoMais.Infrastructure.Repository.Generics;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestaoMais.Infrastructure.Repository.Repositories.Pessoa
{
    public class RepositoryPessoaEmail : RepositoryGeneric<PessoaEmail>, IPessoaEmail {
        private readonly DbContextOptions<ContextBase> _optionsBuilder;

        public RepositoryPessoaEmail()
        {
            _optionsBuilder = new DbContextOptions<ContextBase>();
        }

        public async Task<List<PessoaEmail>> List(int id)
        {
            using (var data = new ContextBase(_optionsBuilder))
            {
                return await data.Set<PessoaEmail>().Include(obj => obj.Pessoa).Where(filter => filter.Pessoa.Id == id).AsNoTracking().ToListAsync();
            }
        }

        public new async Task<List<PessoaEmail>> List()
        {
            using (var data = new ContextBase(_optionsBuilder))
            {
                return await data.Set<PessoaEmail>().Include(obj => obj.Pessoa).AsNoTracking().ToListAsync();
            }
        }

        public new async Task<PessoaEmail> GetById(int id)
        {
            using (var data = new ContextBase(_optionsBuilder))
            {
                return await data.Set<PessoaEmail>().Include(obj => obj.Pessoa).FirstOrDefaultAsync(filter => filter.Id == id);
            }
        }
    }
}
