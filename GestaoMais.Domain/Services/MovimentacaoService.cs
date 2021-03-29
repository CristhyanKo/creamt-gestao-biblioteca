using GestaoMais.Domain.Interfaces.Movimentacao;
using GestaoMais.Domain.Interfaces.Services;
using GestaoMais.Entities.Entities.Movimentacao;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GestaoMais.Domain.Services
{
    public class MovimentacaoService : IServiceMovimentacao
    {

        private readonly IMovimentacao _IMovimentacao;
        public MovimentacaoService(IMovimentacao IMovimentacao)
        {
            _IMovimentacao = IMovimentacao;
        }
        public async Task AddMovimentacao(Movimentacao obj)
        {
            obj.DataLimiteDevolucao = obj.DataEmprestimo.AddDays(obj.EmprestimoLocal ? 15 : 10);
            await _IMovimentacao.Add(obj);
        }
    }
}
