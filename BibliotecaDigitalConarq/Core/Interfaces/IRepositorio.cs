using System.Collections.Generic;
using System.Linq;

namespace Core.Interfaces
{
    public interface IRepositorio<T> where T : class
    {
        void Adicionar(T item);
        void Remover(T item);
        void Remover(long id);
        void Salvar(T item);
        T RecuperarPorId(long id);
        IQueryable<T> RecuperarTodos();
    }
}