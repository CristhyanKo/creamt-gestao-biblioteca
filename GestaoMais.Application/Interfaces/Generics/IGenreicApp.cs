using System.Collections.Generic;
using System.Threading.Tasks;

namespace GestaoMais.Application.Interfaces.Generics
{
    public interface IGenreicApp<T> where T : class
    {
        Task Add(T obj);
        Task Update(T obj);
        Task Delete(T obj);
        Task<T> GetById(int id);
        Task<List<T>> List();
    }
}
