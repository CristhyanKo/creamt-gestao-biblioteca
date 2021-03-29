using GestaoMais.Domain.Interfaces.Pessoa;
using GestaoMais.Domain.Interfaces.Services;
using GestaoMais.Entities.Entities.Pessoa;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GestaoMais.Domain.Services
{
    public class PessoaEmailService : IServicePessoaEmail
    {
        private readonly IPessoaEmail _IPessoaEmail;
        public PessoaEmailService(IPessoaEmail IPessoaTelefone)
        {
            _IPessoaEmail = IPessoaTelefone;
        }
        public async Task AddEmail(PessoaEmail obj)
        {
            if (obj.Principal)
            {
                List<PessoaEmail> telefones = await _IPessoaEmail.List();

                telefones.ForEach(async item => {
                    item.Principal = false;
                    await _IPessoaEmail.Update(item);
                });
            }

            await _IPessoaEmail.Add(obj);
        }

        public async Task UpdateEmail(PessoaEmail obj)
        {
            if (obj.Principal)
            {
                List<PessoaEmail> telefones = await _IPessoaEmail.List();

                telefones.ForEach(async item => {
                    item.Principal = false;
                    await _IPessoaEmail.Update(item);
                });
            }

            await _IPessoaEmail.Update(obj);
        }
    }
}
