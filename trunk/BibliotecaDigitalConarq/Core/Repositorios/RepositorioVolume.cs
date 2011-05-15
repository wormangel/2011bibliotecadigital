using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Core.ContextoBD;
using Core.Interfaces;
using Core.Objetos;

namespace Core.Repositorios
{
    public class RepositorioVolume : Repositorio<Volume>
    {
        protected new readonly ContextoAcessoADados contexto;

        #region IRepositorio<T> Members

        public RepositorioVolume(ContextoAcessoADados contexto) : base(contexto)
        {
            this.contexto = contexto;
        }

        public new void Adicionar(Volume item)
        {
            contexto.DocumentosArquivisticos.Attach(item.DocumentoArquivistico);
            contexto.Set<Volume>().Add(item);
            contexto.SaveChanges();
        }

        public new void Salvar(Volume item)
        {
            contexto.DocumentosArquivisticos.Attach(item.DocumentoArquivistico);
            contexto.Set<Volume>().Attach(item);
            contexto.SaveChanges();
        }

        #endregion
    }
}