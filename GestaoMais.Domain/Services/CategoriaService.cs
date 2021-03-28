using GestaoMais.Domain.Interfaces;
using GestaoMais.Domain.Interfaces.Services;
using GestaoMais.Entities.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestaoMais.Domain.Services
{
    public class CategoriaService : IServiceCategoria
    {
        private readonly ICategoria _ICategoria;
        public CategoriaService(ICategoria ICategoria)
        {
            _ICategoria = ICategoria;
        }
        public async Task<List<Categoria>> ListActive()
        {
            IEnumerable<Categoria> list = await _ICategoria.List();
            return list.Where(filter => filter.Ativo == true).ToList();
        }


    }
}
