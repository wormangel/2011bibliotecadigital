using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Core.Interfaces;

namespace EntityAcessoADados.Repositorios
{
    public class Repositorio<T> : IDisposable, IRepositorio<T> where T : class
    {
        protected readonly DbContext contexto;

        public Repositorio(DbContext contexto)
        {
            this.contexto = contexto;
        }

        #region IDisposable Members

        public void Dispose()
        {
            contexto.Dispose();
        }

        #endregion

        #region IRepositorio<T> Members

        public void Adicionar(T item)
        {
            contexto.Set<T>().Add(item);
            contexto.SaveChanges();
        }

        public void Remover(T item)
        {
            contexto.Set<T>().Remove(item);
            contexto.SaveChanges();
        }

        public void Remover(long id)
        {
            contexto.Set<T>().Remove(RecuperarPorId(id));
            contexto.SaveChanges();
        }

        public void Salvar(T item)
        {
            contexto.Set<T>().Attach(item);
            contexto.SaveChanges();
        }

        public T RecuperarPorId(long id)
        {
            return contexto.Set<T>().Find(id);
        }

        public IQueryable<T> RecuperarTodos()
        {
            return contexto.Set<T>();
        }

        #endregion
    }
}