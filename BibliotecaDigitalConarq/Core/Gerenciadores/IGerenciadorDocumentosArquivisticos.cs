using System.Linq;
using Core.Objetos;
using Core.Objetos.Classificacoes;

namespace Core.Gerenciadores
{
    public interface IGerenciadorDocumentosArquivisticos
    {
        void Adicionar(Classificacao classificacao, DocumentoArquivistico doc);
        IQueryable<DocumentoArquivistico> RecuperarDocumentos();
        DocumentoArquivistico RecuperarPorId(long id);
        void Salvar(DocumentoArquivistico documento);
        void Remover(long id);
    }
}