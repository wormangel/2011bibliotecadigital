using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Core.Interfaces;
using Core.Objetos;

namespace Core.Repositorios
{
    public class RepositorioDocumento : Repositorio<Documento>
    {
        #region IRepositorio<T> Members

        public RepositorioDocumento(ContextoAcessoADados contexto) : base(contexto)
        {
            this.contexto = contexto;
        }

        public new void Adicionar(Documento item)
        {
            contexto.Volumes.Attach(item.Volume);
            contexto.Set<Documento>().Add(item);
            contexto.SaveChanges();
        }

        public new void Salvar(Documento item)
        {
            contexto.Volumes.Attach(item.Volume);
            contexto.Set<Documento>().Attach(item);
            contexto.SaveChanges();
        }

        #endregion
    }
}