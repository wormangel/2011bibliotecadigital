using System.Linq;
using Core.Objetos;

namespace Core.Interfaces
{
    public interface IRepositorioArquivo : IRepositorio<Arquivo>
    {
        IQueryable<Arquivo> BuscaTextual(string query, bool exactSearch);
    }
}
