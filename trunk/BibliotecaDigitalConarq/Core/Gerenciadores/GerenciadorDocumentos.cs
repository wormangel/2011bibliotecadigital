using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.Interfaces;
using Core.Objetos;

namespace Core.Gerenciadores
{
    public class GerenciadorDocumentos
    {
        private readonly IRepositorio<Documento> repositorio;

        public GerenciadorDocumentos(IRepositorio<Documento> repositorio)
        {
            this.repositorio = repositorio;
        }

        //public void salvarArquivo(long id, HttpPostedFileBase arquivo)
        //{
        //    throw new NotImplementedException();
        //}

        public IList<Documento> RecuperarDocumentos()
        {
            throw new NotImplementedException();
        }

        public Documento RecuperarPorId(long id)
        {
            throw new NotImplementedException();
        }

        public void Salvar(Documento documento)
        {
            throw new NotImplementedException();
        }

        public void Adicionar(Documento documento)
        {
            throw new NotImplementedException();
        }

        public void Remover(long id)
        {
            throw new NotImplementedException();
        }
    }
}
