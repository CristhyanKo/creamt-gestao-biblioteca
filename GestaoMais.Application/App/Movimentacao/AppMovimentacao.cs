using GestaoMais.Application.Interfaces.Movimentacao;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GestaoMais.Application.App.Movimentacao
{
    public class AppMovimentacao : IMovimentacao
    {
        Domain.Interfaces.Movimentacao.IMovimentacao _DomainInterface;
        Domain.Interfaces.Services.IServiceMovimentacao _ServiceInterface;

        public AppMovimentacao(Domain.Interfaces.Movimentacao.IMovimentacao DomainInterface, Domain.Interfaces.Services.IServiceMovimentacao ServiceInterface)
        {
            _DomainInterface = DomainInterface;
            _ServiceInterface = ServiceInterface;
        }

        public async Task Add(Entities.Entities.Movimentacao.Movimentacao obj)
        {
            await _DomainInterface.Add(obj);
        }

        public async Task AddMovimentacao(Entities.Entities.Movimentacao.Movimentacao obj)
        {
            await _ServiceInterface.AddMovimentacao(obj);
        }

        public async Task Delete(Entities.Entities.Movimentacao.Movimentacao obj)
        {
            await _DomainInterface.Delete(obj);
        }

        public async Task<Entities.Entities.Movimentacao.Movimentacao> GetById(int id)
        {
            return await _DomainInterface.GetById(id);
        }

        public async Task<List<Entities.Entities.Movimentacao.Movimentacao>> List()
        {
            return await _DomainInterface.List();
        }

        public async Task Update(Entities.Entities.Movimentacao.Movimentacao obj)
        {
            await _DomainInterface.Update(obj);
        }
    }
}
