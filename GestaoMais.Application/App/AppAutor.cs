using GestaoMais.Application.Interfaces;
using GestaoMais.Entities.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GestaoMais.Application.App
{
    public class AppAutor : IAutor
    {

        Domain.Interfaces.IAutor _DomainInterface;

        public AppAutor(Domain.Interfaces.IAutor DomainInterface)
        {
            _DomainInterface = DomainInterface;
        }
        public async Task Add(Autor obj)
        {
            await _DomainInterface.Add(obj);
        }

        public async Task Delete(Autor obj)
        {
            await _DomainInterface.Delete(obj);
        }

        public async Task<Autor> GetById(int id)
        {
            return await _DomainInterface.GetById(id);
        }

        public async Task<List<Autor>> List()
        {
            return await _DomainInterface.List();
        }

        public async Task Update(Autor obj)
        {
            await _DomainInterface.Update(obj);
        }
    }
}
