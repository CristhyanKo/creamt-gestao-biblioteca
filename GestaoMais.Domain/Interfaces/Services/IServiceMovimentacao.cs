using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GestaoMais.Domain.Interfaces.Services
{
    public interface IServiceMovimentacao
    {
        Task Add(Entities.Entities.Movimentacao.Movimentacao obj);
    }
}
