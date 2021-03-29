﻿using GestaoMais.Entities.Entities.Pessoa;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GestaoMais.Domain.Interfaces.Services
{
    public interface IServicePessoaTelefone
    {
        Task AddTelefone(PessoaTelefone obj);
        Task UpdateTelefone(PessoaTelefone obj);
    }
}
