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
        }

        public void AtualizaDocumento(DocumentoArquivistico doc)
        {
            AcessoADados.Editar(doc);
        }
    }
}
