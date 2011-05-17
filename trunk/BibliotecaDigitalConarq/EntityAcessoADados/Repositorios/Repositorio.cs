using System;
using System.Data;
using System.Data.Entity;
using System.Linq;
using Core.Interfaces;

namespace EntityAcessoADados.Repositorios
{
    public class Repositorio<T> : IDisposable, IRepositorio<T> where T : class
    {
        protected DbContext contexto;

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

        public virtual void Adicionar(T item)
        {
            contexto.Set<T>().Add(item);
            contexto.SaveChanges();
        }

        public virtual void Remover(T item)
        {
            contexto.Set<T>().Remove(item);
            contexto.SaveChanges();
        }

        public virtual void Remover(long id)
        {
            contexto.Set<T>().Remove(RecuperarPorId(id));
            contexto.SaveChanges();
        }

        public virtual void Salvar(T item)
        {
            contexto.Entry(item).State = EntityState.Modified;
            contexto.SaveChanges();
        }

        public virtual T RecuperarPorId(long id)
        {
            return contexto.Set<T>().Find(id);
        }

        public virtual IQueryable<T> RecuperarTodos()
        {
            return contexto.Set<T>();
        }

        #endregion
    }
}