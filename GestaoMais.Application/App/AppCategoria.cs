using GestaoMais.Application.Interfaces;
using GestaoMais.Entities.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GestaoMais.Application.App
{
    public class AppCategoria : ICategoria
    {

        Domain.Interfaces.ICategoria _DomainInterface;

        public AppCategoria(Domain.Interfaces.ICategoria DomainInterface)
        {
            _DomainInterface = DomainInterface;
        }
        public async Task Add(Categoria obj)
        {
            await _DomainInterface.Add(obj);
        }

        public async Task Delete(Categoria obj)
        {
            await _DomainInterface.Delete(obj);
        }

        public async Task<Categoria> GetById(int id)
        {
            return await _DomainInterface.GetById(id);
        }

        public async Task<List<Categoria>> List()
        {
            return await _DomainInterface.List();
        }

        public async Task Update(Categoria obj)
        {
            await _DomainInterface.Update(obj);
        }
    }
}
