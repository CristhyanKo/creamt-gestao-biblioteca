using GestaoMais.Application.Interfaces.Generics;
using GestaoMais.Entities.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GestaoMais.Application.Interfaces
{
    public interface ICategoria : IGenreicApp<Categoria> {
        Task<List<Categoria>> ListActive();

    }
}
