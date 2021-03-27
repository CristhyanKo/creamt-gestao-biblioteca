using GestaoMais.Application.Interfaces.Pessoa;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GestaoMais.Application.App.Pessoa
{
    public class AppPessoa : IPessoa
    {
        Domain.Interfaces.Pessoa.IPessoa _DomainInterface;

        public AppPessoa(Domain.Interfaces.Pessoa.IPessoa DomainInterface)
        {
            _DomainInterface = DomainInterface;
        }

        public async Task Add(Entities.Entities.Pessoa.Pessoa obj)
        {
            await _DomainInterface.Add(obj);
        }

        public async Task Delete(Entities.Entities.Pessoa.Pessoa obj)
        {
            await _DomainInterface.Delete(obj);
        }

        public async Task<Entities.Entities.Pessoa.Pessoa> GetById(int id)
        {
            return await _DomainInterface.GetById(id);
        }

        public async Task<List<Entities.Entities.Pessoa.Pessoa>> List()
        {
            return await _DomainInterface.List();
        }

        public async Task Update(Entities.Entities.Pessoa.Pessoa obj)
        {
            await _DomainInterface.Update(obj);
        }
    }
}
