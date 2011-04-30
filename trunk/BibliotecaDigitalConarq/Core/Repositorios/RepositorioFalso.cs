using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Core.Interfaces;
using Core.Objetos;

namespace Core.Gerenciadores
{
    public class RepositorioFalso<T> : IDisposable, IRepositorio<T> where T : class
    {
        protected readonly IList<T> itens;

        public RepositorioFalso(IList<T> itens)
        {
            this.itens = itens;
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
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
