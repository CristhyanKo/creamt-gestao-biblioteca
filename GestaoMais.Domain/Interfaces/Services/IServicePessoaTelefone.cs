using GestaoMais.Entities.Entities.Pessoa;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GestaoMais.Domain.Interfaces.Services
{
    interface IServicePessoaTelefone
    {
        Task AddTelefone(PessoaTelefone obj);
        Task UpdateTelefone(T obj);
    }
}
