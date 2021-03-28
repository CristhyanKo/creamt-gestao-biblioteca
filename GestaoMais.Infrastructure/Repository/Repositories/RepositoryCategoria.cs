using GestaoMais.Domain.Interfaces;
using GestaoMais.Entities.Entities;
using GestaoMais.Infrastructure.Configuration;
using GestaoMais.Infrastructure.Repository.Generics;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestaoMais.Infrastructure.Repository.Repositories
{
    public class RepositoryCategoria : RepositoryGeneric<Categoria>, ICategoria {
        private readonly DbContextOptions<ContextBase> _optionsBuilder;

        public RepositoryCategoria()
        {
            _optionsBuilder = new DbContextOptions<ContextBase>();
        }
    }
}
