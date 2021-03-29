using GestaoMais.Entities.Entities.Pessoa;
using System.Threading.Tasks;

namespace GestaoMais.Domain.Interfaces.Services
{
    public interface IServicePessoaEmail
    {
        Task AddEmail(PessoaEmail obj);
        Task UpdateEmail(PessoaEmail obj);
    }
}
