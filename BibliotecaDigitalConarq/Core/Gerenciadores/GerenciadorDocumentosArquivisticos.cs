using Core.Interfaces;
using Core.Objetos;
using Ninject;

namespace Core.Gerenciadores
{
    public class GerenciadorDocumentosArquivisticos
    {
        private readonly Repositorio<DocumentoArquivistico> AcessoADados = new Repositorio<DocumentoArquivistico>(); 
        
        [Inject]
        private readonly ILogger logger;
        
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
    }
}
