using GestaoMais.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GestaoMais.Domain.Interfaces.Services
{
    public interface IServiceCategoria
    {
        Task<List<Categoria>> ListActive();
    }
}
