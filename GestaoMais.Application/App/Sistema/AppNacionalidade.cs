using GestaoMais.Application.Interfaces.Sistema;
using GestaoMais.Entities.Entities.Sistema;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GestaoMais.Application.App.Sistema
{
    public class AppNacionalidade : INacionalidade
    {
        Domain.Interfaces.Sistema.INacionalidade _DomainInterface;

        public AppNacionalidade(Domain.Interfaces.Sistema.INacionalidade DomainInterface)
        {
            _DomainInterface = DomainInterface;
        }

        public async Task Add(Nacionalidade obj)
        {
            await _DomainInterface.Add(obj);
        }

        public async Task Delete(Nacionalidade obj)
        {
            await _DomainInterface.Delete(obj);
        }

        public async Task<Nacionalidade> GetById(int id)
        {
            return await _DomainInterface.GetById(id);
        }

        public async Task<List<Nacionalidade>> List()
        {
            return await _DomainInterface.List();
        }

        public async Task Update(Nacionalidade obj)
        {
            await _DomainInterface.Update(obj);
        }
    }
}
