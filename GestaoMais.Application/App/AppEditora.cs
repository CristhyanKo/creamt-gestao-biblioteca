using GestaoMais.Application.Interfaces;
using GestaoMais.Entities.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GestaoMais.Application.App
{
    public class AppEditora : IEditora
    {

        Domain.Interfaces.IEditora _DomainInterface;

        public AppEditora(Domain.Interfaces.IEditora DomainInterface)
        {
            _DomainInterface = DomainInterface;
        }
        public async Task Add(Editora obj)
        {
            await _DomainInterface.Add(obj);
        }

        public async Task Delete(Editora obj)
        {
            await _DomainInterface.Delete(obj);
        }

        public async Task<Editora> GetById(int id)
        {
            return await _DomainInterface.GetById(id);
        }

        public async Task<List<Editora>> List()
        {
            return await _DomainInterface.List();
        }

        public async Task Update(Editora obj)
        {
            await _DomainInterface.Update(obj);
        }
    }
}
