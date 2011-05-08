using System.Collections.Generic;
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

        public IList<Documento> RecuperarDocumentos()
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

        public void Adicionar(Documento documento)
        {
            _repositorio.Adicionar(documento);
        }

        public void Remover(long id)
        {
            _repositorio.Remover(id);
        }
    }
}