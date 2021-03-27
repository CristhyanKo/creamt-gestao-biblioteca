using GestaoMais.Application.Interfaces;
using GestaoMais.Entities.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GestaoMais.Application.App
{
    public class AppAluno : IAluno
    {

        Domain.Interfaces.IAluno _DomainInterface;

        public AppAluno(Domain.Interfaces.IAluno DomainInterface)
        {
            _DomainInterface = DomainInterface;
        }
        public async Task Add(Aluno obj)
        {
            await _DomainInterface.Add(obj);
        }

        public async Task Delete(Aluno obj)
        {
            await _DomainInterface.Delete(obj);
        }

        public async Task<Aluno> GetById(int id)
        {
            return await _DomainInterface.GetById(id);
        }

        public async Task<List<Aluno>> List()
        {
            return await _DomainInterface.List();
        }

        public async Task Update(Aluno obj)
        {
            await _DomainInterface.Update(obj);
        }
    }
}
