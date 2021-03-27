using GestaoMais.Application.Interfaces.Pessoa;
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

        public async Task Add(Entities.Entities.Pessoa.PessoaEmail obj)
        {
            await _DomainInterface.Add(obj);
        }

        public async Task Delete(Entities.Entities.Pessoa.PessoaEmail obj)
        {
            await _DomainInterface.Delete(obj);
        }

        public async Task<Entities.Entities.Pessoa.PessoaEmail> GetById(int id)
        {
            return await _DomainInterface.GetById(id);
        }

        public async Task<List<Entities.Entities.Pessoa.PessoaEmail>> List()
        {
            return await _DomainInterface.List();
        }

        public async Task Update(Entities.Entities.Pessoa.PessoaEmail obj)
        {
            await _DomainInterface.Update(obj);
        }
    }
}
