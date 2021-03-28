using GestaoMais.Domain.Interfaces;
using GestaoMais.Entities.Entities;
using GestaoMais.Infrastructure.Configuration;
using GestaoMais.Infrastructure.Repository.Generics;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GestaoMais.Infrastructure.Repository.Repositories
{
    public class RepositoryAluno : RepositoryGeneric<Aluno>, IAluno {

        private readonly DbContextOptions<ContextBase> _optionsBuilder;

        public RepositoryAluno()
        {
            _optionsBuilder = new DbContextOptions<ContextBase>();
        }
        public new async Task<List<Aluno>> List()
        {
            using (var data = new ContextBase(_optionsBuilder))
            {
                return await data.Set<Aluno>().Include(obj => obj.Pessoa).AsNoTracking().ToListAsync();
            }
        }

        public new async Task<Aluno> GetById(int id)
        {
            using (var data = new ContextBase(_optionsBuilder))
            {
                return await data.Set<Aluno>().Include(obj => obj.Pessoa).FirstOrDefaultAsync(filter => filter.Id == id);
            }
        }
    }
}
