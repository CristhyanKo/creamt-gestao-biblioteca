using GestaoMais.Domain.Interfaces.Generics;
using GestaoMais.Entities.Entities.Pessoa;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GestaoMais.Domain.Interfaces.Pessoa
{
    public interface IPessoaEmail : IGeneric<PessoaEmail> {
        Task<List<PessoaEmail>> List(int id);

    }
}
