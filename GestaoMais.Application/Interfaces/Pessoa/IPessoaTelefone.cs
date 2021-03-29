using GestaoMais.Application.Interfaces.Generics;
using GestaoMais.Entities.Entities.Pessoa;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GestaoMais.Application.Interfaces.Pessoa
{
    public interface IPessoaTelefone : IGenreicApp<PessoaTelefone> {
        Task<List<PessoaTelefone>> List(int id);
        Task AddTelefone(PessoaTelefone obj);
        Task UpdateTelefone(PessoaTelefone obj);
    }
}
