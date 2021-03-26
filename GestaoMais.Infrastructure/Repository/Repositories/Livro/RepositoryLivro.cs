using GestaoMais.Domain.Interfaces.Livro;
using GestaoMais.Infrastructure.Repository.Generics;

namespace GestaoMais.Infrastructure.Repository.Repositories.Livro
{
    public class RepositoryLivro : RepositoryGeneric<Entities.Entities.Livro.Livro>, ILivro { }
}
