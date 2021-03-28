using GestaoMais.Application.Interfaces;
using GestaoMais.Entities.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GestaoMais.Application.App
{
    public class AppCategoria : ICategoria
    {

        Domain.Interfaces.ICategoria _DomainInterface;
        Domain.Interfaces.Services.IServiceCategoria _ServiceInterface;

        public AppCategoria(Domain.Interfaces.ICategoria DomainInterface, Domain.Interfaces.Services.IServiceCategoria ServiceInterface)
        {
            _DomainInterface = DomainInterface;
            _ServiceInterface = ServiceInterface;
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

        public async Task<List<Categoria>> ListActive()
        {
            return await _ServiceInterface.ListActive();
        }

        public async Task Update(Categoria obj)
        {
            await _DomainInterface.Update(obj);
        }
    }
}
