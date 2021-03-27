using GestaoMais.Application.Interfaces.Sistema;
using GestaoMais.Entities.Entities.Sistema;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GestaoMais.Application.App.Sistema
{
    public class AppTipoPessoa : ITipoPessoa
    {
        Domain.Interfaces.Sistema.ITipoPessoa _DomainInterface;

        public AppTipoPessoa(Domain.Interfaces.Sistema.ITipoPessoa DomainInterface)
        {
            _DomainInterface = DomainInterface;
        }

        public async Task Add(TipoPessoa obj)
        {
            await _DomainInterface.Add(obj);
        }

        public async Task Delete(TipoPessoa obj)
        {
            await _DomainInterface.Delete(obj);
        }

        public async Task<TipoPessoa> GetById(int id)
        {
            return await _DomainInterface.GetById(id);
        }

        public async Task<List<TipoPessoa>> List()
        {
            return await _DomainInterface.List();
        }

        public async Task Update(TipoPessoa obj)
        {
            await _DomainInterface.Update(obj);
        }
    }
}
