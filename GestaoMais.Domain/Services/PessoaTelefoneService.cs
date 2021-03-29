using GestaoMais.Domain.Interfaces.Pessoa;
using GestaoMais.Domain.Interfaces.Services;
using GestaoMais.Entities.Entities.Pessoa;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GestaoMais.Domain.Services
{
    public class PessoaTelefoneService : IServicePessoaTelefone
    {
        private readonly IPessoaTelefone _IPessoaTelefone;
        public PessoaTelefoneService(IPessoaTelefone IPessoaTelefone)
        {
            _IPessoaTelefone = IPessoaTelefone;
        }
        public async Task AddTelefone(PessoaTelefone obj)
        {
            if (obj.Principal)
            {
                List<PessoaTelefone> telefones = await _IPessoaTelefone.List();

                telefones.ForEach(async item => {
                    item.Principal = false;
                    await _IPessoaTelefone.Update(item);
                });
            }

            await _IPessoaTelefone.Add(obj);
        }

        public async Task UpdateTelefone(PessoaTelefone obj)
        {
            if (obj.Principal)
            {
                List<PessoaTelefone> telefones = await _IPessoaTelefone.List();

                telefones.ForEach(async item => {
                    item.Principal = false;
                    await _IPessoaTelefone.Update(item);
                });
            }

            await _IPessoaTelefone.Update(obj);
        }
    }
}
