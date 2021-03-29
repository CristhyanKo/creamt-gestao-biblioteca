using GestaoMais.Application.Interfaces.Pessoa;
using GestaoMais.Entities.Entities.Pessoa;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GestaoMais.Application.App.Pessoa
{
    public class AppPessoaTelefone : IPessoaTelefone
    {
        Domain.Interfaces.Pessoa.IPessoaTelefone _DomainInterface;
        Domain.Interfaces.Services.IServicePessoaTelefone _ServicePessoaTelefone;

        public AppPessoaTelefone(Domain.Interfaces.Pessoa.IPessoaTelefone DomainInterface, Domain.Interfaces.Services.IServicePessoaTelefone ServicePessoaTelefone)
        {
            _DomainInterface = DomainInterface;
            _ServicePessoaTelefone = ServicePessoaTelefone;
        }

        public async Task Add(PessoaTelefone obj)
        {
            await _DomainInterface.Add(obj);
        }

        public async Task AddTelefone(PessoaTelefone obj)
        {
            await _ServicePessoaTelefone.AddTelefone(obj);
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

        public async Task UpdateTelefone(PessoaTelefone obj)
        {
            await _ServicePessoaTelefone.UpdateTelefone(obj);
        }
    }
}
