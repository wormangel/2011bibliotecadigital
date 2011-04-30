using System;
using System.Data.Entity;
using System.Linq;
using Core.Interfaces;

namespace Core.Repositorios
{
    public class Repositorio<T> : IDisposable, IRepositorio<T> where T : class
    {
        protected readonly DbContext contexto;
 
        public Repositorio(DbContext contexto)
        {
            this.contexto = contexto;
        }
 
        public void Adicionar(T item)
        {
            throw new NotImplementedException();
        }

        public void Remover(T item)
        {
            throw new NotImplementedException();
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
            contexto.Dispose();
        }
    }
}
