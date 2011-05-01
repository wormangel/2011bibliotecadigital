using System;
using System.Collections.Generic;
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
            this.contexto.Set<T>().Add(item);
            this.contexto.SaveChanges();
        }

        public void Remover(T item)
        {
            this.contexto.Set<T>().Remove(item);
            this.contexto.SaveChanges();
        }

        public void Remover(long id)
        {
            this.contexto.Set<T>().Remove(this.RecuperarPorId(id));
            this.contexto.SaveChanges();
        }

        public void Salvar(T item)
        {
            this.contexto.Set<T>().Attach(item);
            this.contexto.SaveChanges();
        }

        public T RecuperarPorId(long id)
        {
            return this.contexto.Set<T>().Find(id);
        }

        public IList<T> RecuperarTodos()
        {
            return this.contexto.Set<T>().ToList(); 
        }

        public void Dispose()
        {
            contexto.Dispose();
        }
    }
}
