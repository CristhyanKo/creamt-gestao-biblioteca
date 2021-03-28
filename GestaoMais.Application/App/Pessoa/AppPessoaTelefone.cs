using GestaoMais.Application.Interfaces.Pessoa;
using GestaoMais.Entities.Entities.Pessoa;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GestaoMais.Application.App.Pessoa
{
    public class AppPessoaTelefone : IPessoaTelefone
    {
        Domain.Interfaces.Pessoa.IPessoaTelefone _DomainInterface;

        public AppPessoaTelefone(Domain.Interfaces.Pessoa.IPessoaTelefone DomainInterface)
        {
            _DomainInterface = DomainInterface;
        }

        public async Task Add(PessoaTelefone obj)
        {
            await _DomainInterface.Add(obj);
        }

        public async Task Delete(PessoaTelefone obj)
        {
            await _DomainInterface.Delete(obj);
        }

        public async Task<PessoaTelefone> GetById(int id)
        {
            return await _DomainInterface.GetById(id);
        }

        public async Task<List<PessoaTelefone>> List()
        {
            return await _DomainInterface.List();
        }

        public async Task<List<PessoaTelefone>> List(int id)
        {
            return await _DomainInterface.List(id);
        }

        public async Task Update(PessoaTelefone obj)
        {
            await _DomainInterface.Update(obj);
        }
    }
}
