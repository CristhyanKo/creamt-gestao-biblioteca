using GestaoMais.Application.Interfaces.Livro;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GestaoMais.Application.App.Livro
{
    public class AppLivro : ILivro
    {
        Domain.Interfaces.Livro.ILivro _DomainInterface;

        public AppLivro(Domain.Interfaces.Livro.ILivro DomainInterface)
        {
            _DomainInterface = DomainInterface;
        }

        public async Task Add(Entities.Entities.Livro.Livro obj)
        {
            await _DomainInterface.Add(obj);
        }

        public async Task Delete(Entities.Entities.Livro.Livro obj)
        {
            await _DomainInterface.Delete(obj);
        }

        public async Task<Entities.Entities.Livro.Livro> GetById(int id)
        {
            return await _DomainInterface.GetById(id);
        }

        public async Task<List<Entities.Entities.Livro.Livro>> List()
        {
            return await _DomainInterface.List();
        }

        public async Task Update(Entities.Entities.Livro.Livro obj)
        {
            await _DomainInterface.Delete(obj);
        }
    }
}
