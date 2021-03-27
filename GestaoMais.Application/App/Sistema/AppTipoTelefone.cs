using GestaoMais.Application.Interfaces.Sistema;
using GestaoMais.Entities.Entities.Sistema;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GestaoMais.Application.App.Sistema
{
    public class AppTipoTelefone : ITipoTelefone
    {
        Domain.Interfaces.Sistema.ITipoTelefone _DomainInterface;

        public AppTipoTelefone(Domain.Interfaces.Sistema.ITipoTelefone DomainInterface)
        {
            _DomainInterface = DomainInterface;
        }

        public async Task Add(TipoTelefone obj)
        {
            await _DomainInterface.Add(obj);
        }

        public async Task Delete(TipoTelefone obj)
        {
            await _DomainInterface.Delete(obj);
        }

        public async Task<TipoTelefone> GetById(int id)
        {
            return await _DomainInterface.GetById(id);
        }

        public async Task<List<TipoTelefone>> List()
        {
            return await _DomainInterface.List();
        }

        public async Task Update(TipoTelefone obj)
        {
            await _DomainInterface.Update(obj);
        }
    }
}
