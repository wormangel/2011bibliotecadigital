using System.Linq;
using Core.Objetos;

namespace Core.Gerenciadores
{
    public interface IFachadaGerenciadores
    {
        DocumentoArquivistico RecuperarDocumentoArquivisticoPorId(long id);
        IQueryable<DocumentoArquivistico> RecuperarDocumentosArquivisticos();
        void SalvarDocumentoArquivistico(DocumentoArquivistico documentoArquivistico);
        void AdicionarDocumentoArquivistico(DocumentoArquivistico documentoArquivistico);
        void RemoverDocumentoArquivistico(long id);

        IQueryable<Volume> RecuperarVolumes();
        Volume RecuperarVolumePorId(long id);
        void AdicionarVolume(long idDocumentoArquivistico, Volume volume);
        void SalvarVolume(Volume volume);
        void RemoverVolume(long id);
        
        IQueryable<Documento> RecuperarDocumentos();
        Documento RecuperarDocumentoPorId(long id);
        void AdicionarDocumento(long idDocumentoArquivistico, long idVolume, Documento documento);
        void SalvarDocumento(Documento documento);
        void RemoverDocumento(long id);
    }
}