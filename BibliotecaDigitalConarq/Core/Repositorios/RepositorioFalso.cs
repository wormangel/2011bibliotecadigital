using System;
using System.Collections.Generic;
using System.Linq;
using Core.Interfaces;

namespace Core.Repositorios
{
    public class RepositorioFalso<T> : IDisposable, IRepositorio<T> where T : class
    {
        protected readonly IList<T> itens;

        public RepositorioFalso()
        {
            itens = new List<T>();
        }

        public void Adicionar(T item)
        {
            itens.Add(item);
        }

        public void Remover(T item)
        {
            itens.Remove(item);
        }

        public void Remover(object id)
        {
            throw new NotImplementedException();
        }

        public void Editar(T item)
        {
            throw new NotImplementedException();
        }

        public T PegarPorId(object id)
        {
            throw new NotImplementedException();
        }

        public IQueryable PegarTodos()
        {
            return itens as IQueryable;
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
