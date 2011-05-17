using System.Linq;
using Core.Gerenciadores;
using Core.Objetos;
using EntityAcessoADados.Repositorios;

namespace EntityAcessoADados.Gerenciadores
{
    public class GerenciadorDocumentos : IGerenciadorDocumentos
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