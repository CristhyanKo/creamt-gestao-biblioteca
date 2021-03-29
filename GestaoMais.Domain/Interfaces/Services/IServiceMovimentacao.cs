using System.Threading.Tasks;

namespace GestaoMais.Domain.Interfaces.Services
{
    public interface IServiceMovimentacao
    {
        Task AddMovimentacao(Entities.Entities.Movimentacao.Movimentacao obj);
    }
}
