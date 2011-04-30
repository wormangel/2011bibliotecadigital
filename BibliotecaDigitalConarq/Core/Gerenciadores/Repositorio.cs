using System;
using System.Data.Entity;
using System.Linq;
using Core.Interfaces;
using Core.Objetos;

namespace Core.Gerenciadores
{
    public class Repositorio<T> : IDisposable, IRepositorio<T> where T : class
    {
        private readonly DateTime DataValidadeVersaoMaisAtual = DateTime.MaxValue;
        protected readonly DbContext contexto;
 
        public Repositorio(DbContext contexto)
        {
            this.contexto = contexto;
        }
 
        public void Adicionar(T item)
        {
            contexto.Set<T>().Add(item);
            contexto.SaveChanges();
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
            // TODO Esse eh o jeito mais OO, mas tem que estudar direito sobre
            // TODO Add/Attach, estado do modelo, etc.
            // TODO Outra alternativa é usar queries LINQ to Entities, usando
            // TODO até aqueles 'select from Contexto.Documentos where...'

            // Modifica a data de validade da versão atualmente no banco
            Documento versaoAnterior = contexto.Set<T>().Find(item.Id);
            versaoAnterior.VersaoValidaAte = DateTime.Now;
            contexto.Set<T>().Add(versaoAnterior); //TODO Isso vai updatear mesmo?

            // Atribui a data de validade da nova versão para a data infinita
            contexto.Set<T>().Attach(item);
            item.VersaoValidaDesde = DateTime.Now;
            item.VersaoValidaAte = DataValidadeVersaoMaisAtual;

            contexto.SaveChanges();
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
