using GestaoMais.Application.Interfaces;
using GestaoMais.Entities.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GestaoMais.Application.App
{
    public class AppEndereco : IEndereco
    {

        Domain.Interfaces.IEndereco _DomainInterface;

        public AppEndereco(Domain.Interfaces.IEndereco DomainInterface)
        {
            _DomainInterface = DomainInterface;
        }
        public async Task Add(Endereco obj)
        {
            await _DomainInterface.Add(obj);
        }

        public async Task Delete(Endereco obj)
        {
            await _DomainInterface.Delete(obj);
        }

        public async Task<Endereco> GetById(int id)
        {
            return await _DomainInterface.GetById(id);
        }

        public async Task<List<Endereco>> List()
        {
            return await _DomainInterface.List();
        }

        public async Task Update(Endereco obj)
        {
            await _DomainInterface.Update(obj);
        }
    }
}
