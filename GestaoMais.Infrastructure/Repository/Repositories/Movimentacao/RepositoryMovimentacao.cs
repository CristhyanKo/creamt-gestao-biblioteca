using GestaoMais.Domain.Interfaces.Movimentacao;
using GestaoMais.Infrastructure.Repository.Generics;

namespace GestaoMais.Infrastructure.Repository.Repositories.Movimentacao
{
    public class RepositoryMovimentacao : RepositoryGeneric<Entities.Entities.Movimentacao.Movimentacao>, IMovimentacao { }
}
