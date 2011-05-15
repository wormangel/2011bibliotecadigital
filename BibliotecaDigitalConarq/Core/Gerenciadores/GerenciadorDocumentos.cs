using System.Collections.Generic;
using System.Linq;
using Core.Interfaces;
using Core.Objetos;

namespace Core.Gerenciadores
{
    public class GerenciadorDocumentos
    {
        private readonly IRepositorio<Documento> _repositorio;

        public GerenciadorDocumentos(IRepositorio<Documento> repositorio)
        {
            _repositorio = repositorio;
        }

        //public void SalvarArquivo(long id, HttpPostedFileBase arquivo)
        //{
        //    throw new NotImplementedException();
        //}

        public IQueryable<Documento> RecuperarDocumentos()
        {
            return _repositorio.RecuperarTodos();
        }

        public Documento RecuperarPorId(long id)
        {
            return _repositorio.RecuperarPorId(id);
        }

        public void Salvar(Documento documento)
        {
            _repositorio.Salvar(documento);
        }

        public void Adicionar(Documento documento, DocumentoArquivistico documentoArquivistico)
        {
            _repositorio.Adicionar(documento);
        }

        public void Remover(long id)
        {
            _repositorio.Remover(id);
        }
    }
}