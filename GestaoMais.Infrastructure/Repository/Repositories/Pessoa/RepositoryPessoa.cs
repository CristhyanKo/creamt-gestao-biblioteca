using GestaoMais.Domain.Interfaces.Pessoa;
using GestaoMais.Infrastructure.Repository.Generics;

namespace GestaoMais.Infrastructure.Repository.Repositories.Pessoa
{
    public class RepositoryPessoa : RepositoryGeneric<Entities.Entities.Pessoa.Pessoa>, IPessoa { }
}
