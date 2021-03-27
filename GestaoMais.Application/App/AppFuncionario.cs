using GestaoMais.Application.Interfaces;
using GestaoMais.Entities.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GestaoMais.Application.App
{
    public class AppFuncionario : IFuncionario
    {

        Domain.Interfaces.IFuncionario _DomainInterface;

        public AppFuncionario(Domain.Interfaces.IFuncionario DomainInterface)
        {
            _DomainInterface = DomainInterface;
        }
        public async Task Add(Funcionario obj)
        {
            await _DomainInterface.Add(obj);
        }

        public async Task Delete(Funcionario obj)
        {
            await _DomainInterface.Delete(obj);
        }

        public async Task<Funcionario> GetById(int id)
        {
            return await _DomainInterface.GetById(id);
        }

        public async Task<List<Funcionario>> List()
        {
            return await _DomainInterface.List();
        }

        public async Task Update(Funcionario obj)
        {
            await _DomainInterface.Update(obj);
        }
    }
}
