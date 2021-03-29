using GestaoMais.Entities.Entities.Pessoa;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GestaoMais.Domain.Interfaces.Services
{
    public interface IServicePessoaEmail
    {
        Task AddEmail(PessoaEmail obj);
        Task UpdateEmail(PessoaEmail obj);
    }
}
