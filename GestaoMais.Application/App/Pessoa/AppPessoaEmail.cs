using GestaoMais.Application.Interfaces.Pessoa;
using GestaoMais.Entities.Entities.Pessoa;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GestaoMais.Application.App.Pessoa
{
    public class AppPessoaEmail : IPessoaEmail
    {
        Domain.Interfaces.Pessoa.IPessoaEmail _DomainInterface;

        public AppPessoaEmail(Domain.Interfaces.Pessoa.IPessoaEmail DomainInterface)
        {
            _DomainInterface = DomainInterface;
        }

        public async Task Add(PessoaEmail obj)
        {
            await _DomainInterface.Add(obj);
        }

        public async Task Delete(PessoaEmail obj)
        {
            await _DomainInterface.Delete(obj);
        }

        public async Task<PessoaEmail> GetById(int id)
        {
            return await _DomainInterface.GetById(id);
        }

        public async Task<List<PessoaEmail>> List()
        {
            return await _DomainInterface.List();
        }

        public async Task<List<PessoaEmail>> List(int id)
        {
            return await _DomainInterface.List(id);

        }

        public async Task Update(PessoaEmail obj)
        {
            await _DomainInterface.Update(obj);
        }
    }
}
