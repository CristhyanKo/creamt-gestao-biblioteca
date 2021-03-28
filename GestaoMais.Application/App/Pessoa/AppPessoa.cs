using GestaoMais.Application.Interfaces.Pessoa;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GestaoMais.Application.App.Pessoa
{
    public class AppPessoa : IPessoa
    {
        Domain.Interfaces.Pessoa.IPessoa _DomainInterface;
        Domain.Interfaces.Services.IServicePessoa _ServicePessoa;

        public AppPessoa(Domain.Interfaces.Pessoa.IPessoa DomainInterface, Domain.Interfaces.Services.IServicePessoa ServicePessoa)
        {
            _DomainInterface = DomainInterface;
            _ServicePessoa = ServicePessoa;
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

        public async Task<List<Entities.Entities.Pessoa.Pessoa>> ListActive()
        {
            return await _ServicePessoa.ListActive();
        }

        public async Task Update(Entities.Entities.Pessoa.Pessoa obj)
        {
            await _DomainInterface.Update(obj);
        }
    }
}
