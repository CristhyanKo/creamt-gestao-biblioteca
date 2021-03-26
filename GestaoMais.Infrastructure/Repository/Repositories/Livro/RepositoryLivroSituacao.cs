using GestaoMais.Domain.Interfaces.Livro;
using GestaoMais.Entities.Entities.Livro;
using GestaoMais.Infrastructure.Repository.Generics;

namespace GestaoMais.Infrastructure.Repository.Repositories.Livro
{
    public class RepositoryLivroSituacao : RepositoryGeneric<LivroSituacao>, ILivroSituacao { }
}
