using GestaoMais.Domain.Interfaces.Livro;
using GestaoMais.Infrastructure.Configuration;
using GestaoMais.Infrastructure.Repository.Generics;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GestaoMais.Infrastructure.Repository.Repositories.Livro
{
    public class RepositoryLivro : RepositoryGeneric<Entities.Entities.Livro.Livro>, ILivro {
        private readonly DbContextOptions<ContextBase> _optionsBuilder;

        public RepositoryLivro()
        {
            _optionsBuilder = new DbContextOptions<ContextBase>();
        }
        public new async Task<List<Entities.Entities.Livro.Livro>> List()
        {
            using (var data = new ContextBase(_optionsBuilder))
            {
                return await data.Set<Entities.Entities.Livro.Livro>().Include(obj => obj.Autor).ThenInclude(obj => obj.Pessoa).Include(obj => obj.Categoria).Include(obj => obj.LivroSituacao).AsNoTracking().ToListAsync();
            }
        }

        public new async Task<Entities.Entities.Livro.Livro> GetById(int id)
        {
            using (var data = new ContextBase(_optionsBuilder))
            {
                return await data.Set<Entities.Entities.Livro.Livro>().Include(obj => obj.Autor).ThenInclude(obj => obj.Pessoa).Include(obj => obj.Categoria).Include(obj => obj.LivroSituacao).FirstOrDefaultAsync(filter => filter.Id == id);
            }
        }
    }
}
