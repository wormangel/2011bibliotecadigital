using System.Linq;
using Core.Gerenciadores;
using Core.Interfaces;
using Core.Objetos;

namespace EntityAcessoADados.Gerenciadores
{
    public class GerenciadorDocumentosArquivisticos : IGerenciadorDocumentosArquivisticos
    {
        private readonly IRepositorio<DocumentoArquivistico> _repositorio;
        private readonly ILogger _trilhaAuditoria;

        public GerenciadorDocumentosArquivisticos(IRepositorio<DocumentoArquivistico> repositorio)
        {
            _repositorio = repositorio;
        }

        public GerenciadorDocumentosArquivisticos(IRepositorio<DocumentoArquivistico> repositorio, ILogger trilhaAuditoria)
        {
            _repositorio = repositorio;
            _trilhaAuditoria = trilhaAuditoria;
        }

        public void Adicionar(DocumentoArquivistico documentoArquivistico)
        {
            // Verifica com o gerenciador de segurança..
            // Indexa com o gerenciador de indexação.. (inclusive arquivos se houver)
            // Loga com o gerenciador de logging..

            _repositorio.Adicionar(documentoArquivistico);
            _trilhaAuditoria.LogaAcaoDocumentoArquivistico(documentoArquivistico.Id, -1, "Adicionado processo/dossiê: " + documentoArquivistico);
        }

        public IQueryable<DocumentoArquivistico> RecuperarDocumentos()
        {
            _trilhaAuditoria.LogaAcaoDocumentoArquivistico("Recuperado todos os processo/dossiês");
            return _repositorio.RecuperarTodos();
        }

        public DocumentoArquivistico RecuperarPorId(long id)
        {
            var documentoArquivistico = _repositorio.RecuperarPorId(id);
            _trilhaAuditoria.LogaAcaoDocumentoArquivistico(id, -1, "Recuperado processo/dossiê: " + documentoArquivistico);
            return documentoArquivistico;
            
        }

        public void Salvar(DocumentoArquivistico documentoArquivistico)
        {
            _repositorio.Salvar(documentoArquivistico);
            _trilhaAuditoria.LogaAcaoDocumentoArquivistico(documentoArquivistico.Id, -1, "Salvo processo/dossiê: " + documentoArquivistico);
        }

        public void Remover(long id)
        {
            var documentoArquivistico = RecuperarPorId(id);
            _repositorio.Remover(id);
            _trilhaAuditoria.LogaAcaoDocumentoArquivistico(id, -1, "Removido processo/dossiê: " + documentoArquivistico);
        }
    }
}