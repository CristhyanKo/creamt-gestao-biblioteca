using GestaoMais.Domain.Interfaces.Movimentacao;
using GestaoMais.Infrastructure.Configuration;
using GestaoMais.Infrastructure.Repository.Generics;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GestaoMais.Infrastructure.Repository.Repositories.Movimentacao
{
    public class RepositoryMovimentacao : RepositoryGeneric<Entities.Entities.Movimentacao.Movimentacao>, IMovimentacao {
        private readonly DbContextOptions<ContextBase> _optionsBuilder;

        public RepositoryMovimentacao()
        {
            _optionsBuilder = new DbContextOptions<ContextBase>();
        }
        public new async Task<List<Entities.Entities.Movimentacao.Movimentacao>> List()
        {
            using (var data = new ContextBase(_optionsBuilder))
            {
                return await data.Set<Entities.Entities.Movimentacao.Movimentacao>().Include(obj => obj.Funcionario).ThenInclude(obj => obj.Pessoa).Include(obj => obj.Pessoa).Include(obj => obj.Livro).Include(obj => obj.MovimentacaoSituacao).AsNoTracking().ToListAsync();
            }
        }

        public new async Task<Entities.Entities.Movimentacao.Movimentacao> GetById(int id)
        {
            using (var data = new ContextBase(_optionsBuilder))
            {
                return await data.Set<Entities.Entities.Movimentacao.Movimentacao>().Include(obj => obj.Funcionario).ThenInclude(obj => obj.Pessoa).Include(obj => obj.Pessoa).Include(obj => obj.Livro).Include(obj => obj.MovimentacaoSituacao).FirstOrDefaultAsync(filter => filter.Id == id);
            }
        }
    }
}
