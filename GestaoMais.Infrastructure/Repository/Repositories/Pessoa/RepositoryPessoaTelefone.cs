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
    public class RepositoryPessoaTelefone : RepositoryGeneric<PessoaTelefone>, IPessoaTelefone {
        private readonly DbContextOptions<ContextBase> _optionsBuilder;

        public RepositoryPessoaTelefone()
        {
            _optionsBuilder = new DbContextOptions<ContextBase>();
        }

        public async Task<List<PessoaTelefone>> List(int id)
        {
            using (var data = new ContextBase(_optionsBuilder))
            {
                return await data.Set<PessoaTelefone>().Include(obj => obj.Pessoa).Include(obj => obj.TipoTelefone).Where(filter => filter.Pessoa.Id == id).AsNoTracking().ToListAsync();
            }
        }

        public new async Task<List<PessoaTelefone>> List()
        {
            using (var data = new ContextBase(_optionsBuilder))
            {
                return await data.Set<PessoaTelefone>().Include(obj => obj.Pessoa).Include(obj => obj.TipoTelefone).AsNoTracking().ToListAsync();
            }
        }

        public new async Task<PessoaTelefone> GetById(int id)
        {
            using (var data = new ContextBase(_optionsBuilder))
            {
                return await data.Set<PessoaTelefone>().Include(obj => obj.Pessoa).Include(obj => obj.TipoTelefone).FirstOrDefaultAsync(filter => filter.Id == id);
            }
        }
    }
}

