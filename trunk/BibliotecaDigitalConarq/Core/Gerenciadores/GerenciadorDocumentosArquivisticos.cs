using System;
using System.Collections.Generic;
using Core.Interfaces;
using Core.Objetos;

namespace Core.Gerenciadores
{
    public class GerenciadorDocumentosArquivisticos
    {
        private readonly IRepositorio<DocumentoArquivistico> AcessoADados;

        public GerenciadorDocumentosArquivisticos(IRepositorio<DocumentoArquivistico> repositorio)
        {
             AcessoADados = repositorio; 
        }
        
        public void CriaDocumento(DocumentoArquivistico doc)
        {
            // Verifica com o gerenciador de segurança..
            // Indexa com o gerenciador de indexação.. (inclusive arquivos se houver)
            // Loga com o gerenciador de logging..

            AcessoADados.Adicionar(doc);
            //logger.LogaAcaoDocumentoArquivistico(doc.Id, usuario, "Criado processo/dossiê");
        }

        public void AtualizaDocumento(DocumentoArquivistico doc)
        {
            AcessoADados.Editar(doc);
        }

        public List<DocumentoArquivistico> RecuperarDocumentos()
        {
            var a = AcessoADados.PegarTodos();
            return a as List<DocumentoArquivistico>;
            throw new NotImplementedException();
        }

        public DocumentoArquivistico RecuperarPorId(long id)
        {
            throw new NotImplementedException();
        }

        public void Salvar(DocumentoArquivistico documento)
        {
            throw new NotImplementedException();
        }

        public void Salvar(Documento documento)
        {
            throw new NotImplementedException();
        }

        public void Remover(long id)
        {
            throw new NotImplementedException();
        }
    }
}
