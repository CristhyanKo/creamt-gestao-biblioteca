using GestaoMais.Domain.Interfaces.Generics;
using GestaoMais.Entities.Entities.Pessoa;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GestaoMais.Domain.Interfaces.Pessoa
{
    public interface IPessoaTelefone : IGeneric<PessoaTelefone> { 
        Task<List<PessoaTelefone>> List(int id);
    }
}
