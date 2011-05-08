﻿using System;
using System.Collections.Generic;
using Core.Interfaces;
using Core.Objetos;

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
            this._repositorio = repositorio; 
        }
        
        public void Criar(DocumentoArquivistico doc)
        {
            // Verifica com o gerenciador de segurança..
            // Indexa com o gerenciador de indexação.. (inclusive arquivos se houver)
            // Loga com o gerenciador de logging..

            this._repositorio.Adicionar(doc);
            //logger.LogaAcaoDocumentoArquivistico(doc.Id, usuario, "Processo/Dossiê criado");
        }

        public void Atualizar(DocumentoArquivistico doc)
        {
            this._repositorio.Salvar(doc);
            //logger.LogaAcaoDocumentoArquivistico(doc.Id, usuario, "Processo/Dossiê atualizado");
        }

        public IList<DocumentoArquivistico> RecuperarDocumentos()
        {
            return this._repositorio.RecuperarTodos();
            //logger.LogaAcaoDocumentoArquivistico(doc.Id, usuario, "Recuperados todos os processo/dossiês");
        }

        public DocumentoArquivistico RecuperarPorId(long id)
        {
            return this._repositorio.RecuperarPorId(id);
            //logger.LogaAcaoDocumentoArquivistico(doc.Id, usuario, "Processo/Dossiê recuperado");
        }

        public void Salvar(DocumentoArquivistico documento)
        {
            this._repositorio.Salvar(documento);
            //logger.LogaAcaoDocumentoArquivistico(doc.Id, usuario, "Processo/Dossiê salvo");
        }

        public void Remover(long id)
        {
            this._repositorio.Remover(id);
            //logger.LogaAcaoDocumentoArquivistico(doc.Id, usuario, "Processo/Dossiê removido");
        }
    }
}