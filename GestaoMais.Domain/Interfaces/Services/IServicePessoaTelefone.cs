using GestaoMais.Entities.Entities.Pessoa;
using System.Threading.Tasks;

namespace GestaoMais.Domain.Interfaces.Services
{
    public interface IServicePessoaTelefone
    {
        Task AddTelefone(PessoaTelefone obj);
        Task UpdateTelefone(PessoaTelefone obj);
    }
}
