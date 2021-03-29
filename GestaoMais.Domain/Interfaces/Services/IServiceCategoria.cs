using GestaoMais.Entities.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GestaoMais.Domain.Interfaces.Services
{
    public interface IServiceCategoria
    {
        Task<List<Categoria>> ListActive();
    }
}
