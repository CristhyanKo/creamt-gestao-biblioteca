using GestaoMais.Application.Interfaces.Movimentacao;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GestaoMais.Application.App.MovimentacaoSituacao
{
    public class AppMovimentacaoSituacao : IMovimentacaoSituacao
    {
        Domain.Interfaces.Movimentacao.IMovimentacaoSituacao _DomainInterface;

        public AppMovimentacaoSituacao(Domain.Interfaces.Movimentacao.IMovimentacaoSituacao DomainInterface)
        {
            _DomainInterface = DomainInterface;
        }

        public async Task Add(Entities.Entities.Movimentacao.MovimentacaoSituacao obj)
        {
            await _DomainInterface.Add(obj);
        }

        public async Task Delete(Entities.Entities.Movimentacao.MovimentacaoSituacao obj)
        {
            await _DomainInterface.Delete(obj);
        }

        public async Task<Entities.Entities.Movimentacao.MovimentacaoSituacao> GetById(int id)
        {
            return await _DomainInterface.GetById(id);
        }

        public async Task<List<Entities.Entities.Movimentacao.MovimentacaoSituacao>> List()
        {
            return await _DomainInterface.List();
        }

        public async Task Update(Entities.Entities.Movimentacao.MovimentacaoSituacao obj)
        {
            await _DomainInterface.Update(obj);
        }
    }
}
