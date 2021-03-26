using GestaoMais.Domain.Interfaces.Movimentacao;
using GestaoMais.Entities.Entities.Movimentacao;
using GestaoMais.Infrastructure.Repository.Generics;

namespace GestaoMais.Infrastructure.Repository.Repositories.Movimentacao
{
    public class RepositoryMovimentacaoSituacao : RepositoryGeneric<MovimentacaoSituacao>, IMovimentacaoSituacao { }
}
