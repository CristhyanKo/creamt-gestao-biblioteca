using GestaoMais.Application.Interfaces.Livro;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GestaoMais.Application.App.LivroSituacao
{
    public class AppLivroSituacao : ILivroSituacao
    {
        Domain.Interfaces.Livro.ILivroSituacao _DomainInterface;

        public AppLivroSituacao(Domain.Interfaces.Livro.ILivroSituacao DomainInterface)
        {
            _DomainInterface = DomainInterface;
        }

        public async Task Add(Entities.Entities.Livro.LivroSituacao obj)
        {
            await _DomainInterface.Add(obj);
        }

        public async Task Delete(Entities.Entities.Livro.LivroSituacao obj)
        {
            await _DomainInterface.Delete(obj);
        }

        public async Task<Entities.Entities.Livro.LivroSituacao> GetById(int id)
        {
            return await _DomainInterface.GetById(id);
        }

        public async Task<List<Entities.Entities.Livro.LivroSituacao>> List()
        {
            return await _DomainInterface.List();
        }

        public async Task Update(Entities.Entities.Livro.LivroSituacao obj)
        {
            await _DomainInterface.Delete(obj);
        }
    }
}
