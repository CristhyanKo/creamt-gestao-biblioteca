using GestaoMais.Domain.Interfaces.Pessoa;
using GestaoMais.Entities.Entities.Pessoa;
using GestaoMais.Infrastructure.Repository.Generics;

namespace GestaoMais.Infrastructure.Repository.Repositories.Pessoa
{
    public class RepositoryPessoaEndereco : RepositoryGeneric<PessoaEndereco>, IPessoaEndereco { }
}
