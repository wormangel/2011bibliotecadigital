using Core.Interfaces;
using Core.Objetos;

namespace Core.Gerenciadores
{
    public class FachadaGerenciadores
    {
        private readonly GerenciadorDocumentos _documentos;
        private readonly GerenciadorDocumentosArquivisticos _documentosArquivisticos;
        private readonly GerenciadorVolumes _volumes;

        public FachadaGerenciadores(IRepositorio<DocumentoArquivistico> repositorioDocumentosArquivisticos,
                                    IRepositorio<Volume> repositorioVolumes,
                                    IRepositorio<Documento> repositorioDocumentos)
        {
            _documentosArquivisticos = new GerenciadorDocumentosArquivisticos(repositorioDocumentosArquivisticos);
            _volumes = new GerenciadorVolumes(repositorioVolumes);
            _documentos = new GerenciadorDocumentos(repositorioDocumentos);
        }

        // TODO: implementar métodos que serão chamados pelos controllers.
    }
}