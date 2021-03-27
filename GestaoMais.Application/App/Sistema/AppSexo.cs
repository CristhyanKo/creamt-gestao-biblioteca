using GestaoMais.Application.Interfaces.Sistema;
using GestaoMais.Entities.Entities.Sistema;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GestaoMais.Application.App.Sistema
{
    public class AppSexo : ISexo
    {
        Domain.Interfaces.Sistema.ISexo _DomainInterface;

        public AppSexo(Domain.Interfaces.Sistema.ISexo DomainInterface)
        {
            _DomainInterface = DomainInterface;
        }

        public async Task Add(Sexo obj)
        {
            await _DomainInterface.Add(obj);
        }

        public async Task Delete(Sexo obj)
        {
            await _DomainInterface.Delete(obj);
        }

        public async Task<Sexo> GetById(int id)
        {
            return await _DomainInterface.GetById(id);
        }

        public async Task<List<Sexo>> List()
        {
            return await _DomainInterface.List();
        }

        public async Task Update(Sexo obj)
        {
            await _DomainInterface.Update(obj);
        }
    }
}
