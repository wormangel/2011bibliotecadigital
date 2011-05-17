using System.Linq;
using Core.Objetos;

namespace Core.Gerenciadores
{
    public interface IGerenciadorDocumentosArquivisticos
    {
        void Adicionar(DocumentoArquivistico doc);
        IQueryable<DocumentoArquivistico> RecuperarDocumentos();
        DocumentoArquivistico RecuperarPorId(long id);
        void Salvar(DocumentoArquivistico documento);
        void Remover(long id);
    }
}