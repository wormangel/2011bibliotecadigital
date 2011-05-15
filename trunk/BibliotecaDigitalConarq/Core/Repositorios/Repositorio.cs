using System;
using System.Linq;
using Core.ContextoBD;
using EntityAcessoADados.Interfaces;

namespace Core.Repositorios
{
    public class Repositorio<T> : IDisposable, IRepositorio<T> where T : class
    {
        protected ContextoAcessoADados contexto;

        public Repositorio(ContextoAcessoADados contexto)
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