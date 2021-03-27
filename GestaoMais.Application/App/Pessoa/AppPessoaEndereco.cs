using GestaoMais.Application.Interfaces.Pessoa;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GestaoMais.Application.App.Pessoa
{
    public class AppPessoaEndereco : IPessoaEndereco
    {
        Domain.Interfaces.Pessoa.IPessoaEndereco _DomainInterface;

        public AppPessoaEndereco(Domain.Interfaces.Pessoa.IPessoaEndereco DomainInterface)
        {
            _DomainInterface = DomainInterface;
        }

        public async Task Add(Entities.Entities.Pessoa.PessoaEndereco obj)
        {
            await _DomainInterface.Add(obj);
        }

        public async Task Delete(Entities.Entities.Pessoa.PessoaEndereco obj)
        {
            await _DomainInterface.Delete(obj);
        }

        public async Task<Entities.Entities.Pessoa.PessoaEndereco> GetById(int id)
        {
            return await _DomainInterface.GetById(id);
        }

        public async Task<List<Entities.Entities.Pessoa.PessoaEndereco>> List()
        {
            return await _DomainInterface.List();
        }

        public async Task Update(Entities.Entities.Pessoa.PessoaEndereco obj)
        {
            await _DomainInterface.Update(obj);
        }
    }
}
