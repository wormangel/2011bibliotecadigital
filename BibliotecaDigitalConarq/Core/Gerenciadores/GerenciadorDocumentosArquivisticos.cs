using System.Linq;
using Core.Objetos;
using EntityAcessoADados.Interfaces;

namespace Core.Gerenciadores
{
    public class GerenciadorDocumentosArquivisticos
    {
        private readonly IRepositorio<DocumentoArquivistico> _repositorio;

        // problema porque se eu adicionar referência no core da trilha causaria dependência circular
        // a trilha usa IRepositorio, talvez seja interessante separar o repositorio em um package diferente
        // private readonly Logger logger;

        public GerenciadorDocumentosArquivisticos(IRepositorio<DocumentoArquivistico> repositorio)
        {
            _repositorio = repositorio;
        }

        public void Adicionar(DocumentoArquivistico doc)
        {
            // Verifica com o gerenciador de segurança..
            // Indexa com o gerenciador de indexação.. (inclusive arquivos se houver)
            // Loga com o gerenciador de logging..

            _repositorio.Adicionar(doc);
            //logger.LogaAcaoDocumentoArquivistico(doc.Id, usuario, "Processo/Dossiê criado");
        }

        public IQueryable<DocumentoArquivistico> RecuperarDocumentos()
        {
            return _repositorio.RecuperarTodos();
            //logger.LogaAcaoDocumentoArquivistico(doc.Id, usuario, "Recuperados todos os processo/dossiês");
        }

        public DocumentoArquivistico RecuperarPorId(long id)
        {
            return _repositorio.RecuperarPorId(id);
            //logger.LogaAcaoDocumentoArquivistico(doc.Id, usuario, "Processo/Dossiê recuperado");
        }

        public void Salvar(DocumentoArquivistico documento)
        {
            _repositorio.Salvar(documento);
            //logger.LogaAcaoDocumentoArquivistico(doc.Id, usuario, "Processo/Dossiê salvo");
        }

        public void Remover(long id)
        {
            _repositorio.Remover(id);
            //logger.LogaAcaoDocumentoArquivistico(doc.Id, usuario, "Processo/Dossiê removido");
        }
    }
}