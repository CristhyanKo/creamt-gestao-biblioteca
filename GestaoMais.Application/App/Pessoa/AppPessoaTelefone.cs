using GestaoMais.Application.Interfaces.Pessoa;
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

        public async Task Add(Entities.Entities.Pessoa.PessoaTelefone obj)
        {
            await _DomainInterface.Add(obj);
        }

        public async Task Delete(Entities.Entities.Pessoa.PessoaTelefone obj)
        {
            await _DomainInterface.Delete(obj);
        }

        public async Task<Entities.Entities.Pessoa.PessoaTelefone> GetById(int id)
        {
            return await _DomainInterface.GetById(id);
        }

        public async Task<List<Entities.Entities.Pessoa.PessoaTelefone>> List()
        {
            return await _DomainInterface.List();
        }

        public async Task Update(Entities.Entities.Pessoa.PessoaTelefone obj)
        {
            await _DomainInterface.Update(obj);
        }
    }
}
