using System;
using System.Linq;
using Core.Gerenciadores;
using Core.Interfaces;
using Core.Objetos;
using Core.Objetos.Classificacoes;
using EntityAcessoADados.Repositorios;

namespace EntityAcessoADados.Gerenciadores
{
    public class FachadaGerenciadores : IFachadaGerenciadores
    {
        private readonly IGerenciadorDocumentos _documentos;
        private readonly IGerenciadorDocumentosArquivisticos _documentosArquivisticos;
        private readonly IGerenciadorVolumes _volumes;
        private readonly IGerenciadorClasses _classes;
        private readonly IGerenciadorSubclasses _subclasses;

        public FachadaGerenciadores(IGerenciadorDocumentos documentos,
                                    IGerenciadorDocumentosArquivisticos documentosArquivisticos,
                                    IGerenciadorVolumes volumes,
                                    IGerenciadorClasses classes,
                                    IGerenciadorSubclasses subclasses)
        {
            _documentosArquivisticos = documentosArquivisticos;
            _volumes = volumes;
            _documentos = documentos;
            _classes = classes;
            _subclasses = subclasses;
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

        public IQueryable<Volume> RecuperarVolumes()
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

        public IQueryable<Classe> RecuperarClasses()
        {
            return _classes.RecuperarClasses();
        }

        public Classe RecuperarClassePorId(long id)
        {
            return _classes.RecuperarPorId(id);
        }

        public void AdicionarClasse(Classe classe)
        {
            _classes.Adicionar(classe);
        }

        public void SalvarClasse(Classe classe)
        {
            _classes.Salvar(classe);
        }

        public void RemoverClasse(long id)
        {
            _classes.Remover(id);
        }

        public IQueryable<Subclasse> RecuperarSubclasses()
        {
            return _subclasses.RecuperarSubclasses();
        }

        public Subclasse RecuperarSubclassePorId(long id)
        {
            return _subclasses.RecuperarPorId(id);
        }

        public void AdicionarSubclasse(Subclasse subclasse)
        {
            _subclasses.Adicionar(subclasse);
        }

        public void SalvarSubclasse(Subclasse subclasse)
        {
            _subclasses.Salvar(subclasse);
        }

        public void RemoverSubclasse(long id)
        {
            _subclasses.Remover(id);
        }
    }

}