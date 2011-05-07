using Core.Gerenciadores;
using Core.Interfaces;
using Core.Objetos;

namespace Core.Gerenciadores
{
    public class FachadaGerenciadores
    {
        private readonly GerenciadorDocumentosArquivisticos _documentosArquivisticos; 
        private readonly GerenciadorVolumes _volumes;
        private readonly GerenciadorDocumentos _documentos;

        public FachadaGerenciadores(IRepositorio<DocumentoArquivistico> repositorioDocumentosArquivisticos, IRepositorio<Volume> repositorioVolumes, IRepositorio<Documento> repositorioDocumentos)
        {
            this._documentosArquivisticos = new GerenciadorDocumentosArquivisticos(repositorioDocumentosArquivisticos);
            this._volumes = new GerenciadorVolumes(repositorioVolumes);
            this._documentos = new GerenciadorDocumentos(repositorioDocumentos);
        }

        // TODO: implementar métodos que serão chamados pelos controllers.
    }
}
