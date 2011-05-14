using System;
using System.Collections.Generic;
using System.Linq;
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

        // DOCUMENTO ARQUIVISTICO
        public DocumentoArquivistico RecuperarDocumentoArquivisticoPorId(long id)
        {
            return _documentosArquivisticos.RecuperarPorId(id);
        }

        public IEnumerable<DocumentoArquivistico> RecuperarDocumentosArquivisticos()
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
        
        // VOLUMES
        public IEnumerable<Volume> RecuperarVolumes()
        {
            return _volumes.RecuperarVolumes();
        }

        public Volume RecuperarVolumePorId(long id)
        {
            return _volumes.RecuperarPorId(id);
        }

        public void AdicionarVolume(Volume volume)
        {
            _volumes.Adicionar(volume);
        }

        public void SalvarVolume(Volume volume)
        {
            _volumes.Salvar(volume);
        }

        public void RemoverVolume(long id)
        {
            _volumes.Remover(id);
        }

        // DOCUMENTOS
        public IQueryable<Documento> RecuperarDocumentos()
        {
            return _documentos.RecuperarDocumentos();
        }

        public Documento RecuperarDocumentoPorId(long id)
        {
            return _documentos.RecuperarPorId(id);
        }

        public void AdicionarDocumento(Documento documento)
        {
            _documentos.Adicionar(documento);
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