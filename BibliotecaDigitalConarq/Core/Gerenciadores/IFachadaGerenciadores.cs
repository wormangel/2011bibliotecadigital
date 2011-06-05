using System.Linq;
using Core.Objetos;
using Core.Objetos.Classificacoes;

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
        
        IQueryable<Classe> RecuperarClasses();
        Classe RecuperarClassePorId(long id);
        void AdicionarClasse(Classe classe);
        void SalvarClasse(Classe classe);
        void RemoverClasse(long id);

        IQueryable<Subclasse> RecuperarSubclasses();
        Subclasse RecuperarSubclassePorId(long id);
        void AdicionarSubclasse(Subclasse subclasse);
        void SalvarSubclasse(Subclasse subclasse);
        void RemoverSubclasse(long id);

        void AdicionarGrupo(Grupo grupo);
        IQueryable<Grupo> RecuperarGrupos();
        Grupo RecuperarGrupoPorId(long id);
        void SalvarGrupo(Grupo grupo);
        void RemoverGrupo(long id);

        void AdicionarSubgrupo(Subgrupo subgrupo);
        IQueryable<Subgrupo> RecuperarSubgrupos();
        Subgrupo RecuperarSubgrupoPorId(long id);
        void SalvarSubgrupo(Subgrupo subgrupo);
        void RemoverSubgrupo(long id);
    }
}