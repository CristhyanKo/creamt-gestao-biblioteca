using GestaoMais.Application.Interfaces.Generics;
using GestaoMais.Entities.Entities.Pessoa;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GestaoMais.Application.Interfaces.Pessoa
{
    public interface IPessoaEmail : IGenreicApp<PessoaEmail> { 
        Task<List<PessoaEmail>> List(int id);
        Task AddEmail(PessoaEmail obj);
        Task UpdateEmail(PessoaEmail obj);
    }
}
