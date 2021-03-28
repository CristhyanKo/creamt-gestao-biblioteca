using GestaoMais.Application.Interfaces.Generics;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GestaoMais.Application.Interfaces.Pessoa
{
    public interface IPessoa : IGenreicApp<Entities.Entities.Pessoa.Pessoa> {
        Task<List<Entities.Entities.Pessoa.Pessoa>> ListActive();
    }
}
