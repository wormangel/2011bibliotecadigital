using System.Linq;
using Core.Objetos;
using Core.Repositorios;

namespace Core.Gerenciadores
{
    public class GerenciadorDocumentos
    {
        private readonly RepositorioDocumento _repositorio;

        public GerenciadorDocumentos(RepositorioDocumento repositorio)
        {
            _repositorio = repositorio;
        }

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

        public void Adicionar(Volume volume, Documento documento)
        {
            documento.Volume = volume;
            _repositorio.Adicionar(documento);
        }

        public void Remover(long id)
        {
            _repositorio.Remover(id);
        }
    }
}