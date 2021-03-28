using GestaoMais.Domain.Interfaces;
using GestaoMais.Entities.Entities;
using GestaoMais.Infrastructure.Configuration;
using GestaoMais.Infrastructure.Repository.Generics;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GestaoMais.Infrastructure.Repository.Repositories
{
    public class RepositoryAutor : RepositoryGeneric<Autor>, IAutor {
        private readonly DbContextOptions<ContextBase> _optionsBuilder;

        public RepositoryAutor()
        {
            _optionsBuilder = new DbContextOptions<ContextBase>();
        }

        public new async Task<List<Autor>> List()
        {
            using (var data = new ContextBase(_optionsBuilder))
            {
                return await data.Set<Autor>().Include(obj => obj.Pessoa).AsNoTracking().ToListAsync();
            }
        }

        public new async Task<Autor> GetById(int id)
        {
            using (var data = new ContextBase(_optionsBuilder))
            {
                return await data.Set<Autor>().Include(obj => obj.Pessoa).FirstOrDefaultAsync(filter => filter.Id == id);
            }
        }
    }
}
