using System.Linq;
using Core.Gerenciadores;
using Core.Interfaces;
using Core.Objetos;
using EntityAcessoADados.Repositorios;

namespace EntityAcessoADados.Gerenciadores
{
    public class GerenciadorDocumentos : IGerenciadorDocumentos
    {
        private readonly IRepositorio<Documento> _repositorio;
        private readonly ILogger _trilhaAuditoria;

        public GerenciadorDocumentos(IRepositorio<Documento> repositorio)
        {
            _repositorio = repositorio;
        }

        public GerenciadorDocumentos(IRepositorio<Documento> repositorio, ILogger trilhaAuditoria)
        {
            _repositorio = repositorio;
            _trilhaAuditoria = trilhaAuditoria;
        }

        public IQueryable<Documento> RecuperarDocumentos()
        {
            _trilhaAuditoria.LogaAcaoDocumento("Recuperado todos os documentos");
            return _repositorio.RecuperarTodos();
        }

        public Documento RecuperarPorId(long id)
        {
            var documento = _repositorio.RecuperarPorId(id);
            _trilhaAuditoria.LogaAcaoDocumento(id, -1, "Recuperado documento: " + documento);
            return documento;
        }

        public void Salvar(Documento documento)
        {
            _repositorio.Salvar(documento);
            _trilhaAuditoria.LogaAcaoDocumento(documento.Id, -1, "Salvo documento: " + documento);
        }

        public void Adicionar(Volume volume, Documento documento)
        {
            documento.Volume = volume;
            _repositorio.Adicionar(documento);
            _trilhaAuditoria.LogaAcaoDocumento(documento.Id, -1, "Adicionado documento: " + documento);
        }

        public void Remover(long id)
        {
            var documento = RecuperarPorId(id);
            _repositorio.Remover(id);
            _trilhaAuditoria.LogaAcaoDocumento(id, -1, "Removido documento: " + documento);
        }
    }
}