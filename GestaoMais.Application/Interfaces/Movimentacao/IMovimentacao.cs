using GestaoMais.Application.Interfaces.Generics;
using System.Threading.Tasks;

namespace GestaoMais.Application.Interfaces.Movimentacao
{
    public interface IMovimentacao : IGenreicApp<Entities.Entities.Movimentacao.Movimentacao> { 
        Task AddMovimentacao(Entities.Entities.Movimentacao.Movimentacao obj);
    }
}
