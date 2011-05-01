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

        public void Remover(long id)
        {
            throw new NotImplementedException();
        }

        public void Salvar(T item)
        {
            throw new NotImplementedException();
        }

        public T RecuperarPorId(long id)
        {
            throw new NotImplementedException();
        }

        public IList<T> RecuperarTodos()
        {
            return itens;
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
