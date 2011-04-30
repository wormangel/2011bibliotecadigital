using System.Linq;

namespace Core.Interfaces
{
    public interface IRepositorio<T> where T : class
    {
        void Adicionar(T item);
        void Remover(T item);
        void Remover(object id);
        void Editar(T item);
        T PegarPorId(object id);
        IQueryable PegarTodos();
    }
}
