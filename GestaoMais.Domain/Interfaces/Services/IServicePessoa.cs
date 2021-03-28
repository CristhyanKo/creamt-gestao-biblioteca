using System.Collections.Generic;
using System.Threading.Tasks;

namespace GestaoMais.Domain.Interfaces.Services
{
    public interface IServicePessoa
    {
        Task<List<Entities.Entities.Pessoa.Pessoa>> ListActive();
    }
}
