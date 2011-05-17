using System.Linq;
using Core.Gerenciadores;
using Core.Interfaces;
using Core.Objetos;
using EntityAcessoADados.Repositorios;

namespace EntityAcessoADados.Gerenciadores
{
    public class FachadaGerenciadores : IFachadaGerenciadores
    {
        private readonly IGerenciadorDocumentos _documentos;
        private readonly IGerenciadorDocumentosArquivisticos _documentosArquivisticos;
        private readonly IGerenciadorVolumes _volumes;

        public FachadaGerenciadores(IGerenciadorDocumentos documentos,
                                    IGerenciadorDocumentosArquivisticos documentosArquivisticos,
                                    IGerenciadorVolumes volumes)
        {
            _documentosArquivisticos = documentosArquivisticos;
            _volumes = volumes;
            _documentos = documentos;
        }

        public DocumentoArquivistico RecuperarDocumentoArquivisticoPorId(long id)
        {
            return _documentosArquivisticos.RecuperarPorId(id);
        }

        public IQueryable<DocumentoArquivistico> RecuperarDocumentosArquivisticos()
        {
            return _documentosArquivisticos.RecuperarDocumentos();
        }

        public void SalvarDocumentoArquivistico(DocumentoArquivistico documentoArquivistico)
        {
            _documentosArquivisticos.Salvar(documentoArquivistico);
        }

        public void AdicionarDocumentoArquivistico(DocumentoArquivistico documentoArquivistico)
        {
            _documentosArquivisticos.Adicionar(documentoArquivistico);
        }

        public void RemoverDocumentoArquivistico(long id)
        {
            _documentosArquivisticos.Remover(id);
        }

        public IQueryable<Volume> RecuperarVolumes(long idDocumentoArquivistico)
        {
            return _volumes.RecuperarVolumes();
        }

        public Volume RecuperarVolumePorId(long id)
        {
            return _volumes.RecuperarPorId(id);
        }

        public void AdicionarVolume(long idDocumentoArquivistico, Volume volume)
        {
            _volumes.Adicionar(_documentosArquivisticos.RecuperarPorId(idDocumentoArquivistico), volume);
        }

        public void SalvarVolume(Volume volume)
        {
            _volumes.Salvar(volume);
        }

        public void RemoverVolume(long id)
        {
            _volumes.Remover(id);
        }

        public IQueryable<Documento> RecuperarDocumentos()
        {
            return _documentos.RecuperarDocumentos();
        }

        public Documento RecuperarDocumentoPorId(long id)
        {
            return _documentos.RecuperarPorId(id);
        }

        public void AdicionarDocumento(long idDocumentoArquivistico, long idVolume, Documento documento)
        {
            _documentos.Adicionar(_volumes.RecuperarPorId(idVolume), documento);
        }

        public void SalvarDocumento(Documento documento)
        {
            _documentos.Salvar(documento);
        }

        public void RemoverDocumento(long id)
        {
            _documentos.Remover(id);
        }
    }
}