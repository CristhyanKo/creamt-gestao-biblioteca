using GestaoMais.Domain.Interfaces.Pessoa;
using GestaoMais.Domain.Interfaces.Services;
using GestaoMais.Entities.Entities.Pessoa;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestaoMais.Domain.Services
{
    public class PessoaService : IServicePessoa
    {
        private readonly IPessoa _IPessoa;
        public PessoaService(IPessoa IPessoa)
        {
            _IPessoa = IPessoa;
        }
        public async Task<List<Pessoa>> ListActive()
        {
            IEnumerable<Pessoa> list = await _IPessoa.List();
            return list.Where(filter => filter.Ativo == true).ToList();
        }
    }
}
