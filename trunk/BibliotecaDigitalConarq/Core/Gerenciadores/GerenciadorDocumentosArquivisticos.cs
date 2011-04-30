using Core.Objetos;

namespace Core.Gerenciadores
{
    public class GerenciadorDocumentosArquivisticos
    {
        private readonly Repositorio<Documento> AcessoADados = new Repositorio<Documento>(); 

        public void CriaDocumento(Documento doc)
        {
            // Verifica com o gerenciador de segurança..
            // Indexa com o gerenciador de indexação.. (inclusive arquivos se houver)
            // Loga com o gerenciador de logging..


            AcessoADados.Adicionar(doc);
        }

        public void AtualizaDocumento(Documento doc)
        {
            AcessoADados.Editar(doc);
        }
    }
}
