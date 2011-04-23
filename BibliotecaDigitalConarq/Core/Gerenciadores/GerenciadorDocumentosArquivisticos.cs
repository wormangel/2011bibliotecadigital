using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.Objetos;

namespace Core.Gerenciadores
{
    class GerenciadorDocumentosArquivisticos
    {
        private GerenciadorAcessoADados AcessoADados = new GerenciadorAcessoADados(); 

        public void CriaDocumento(Documento doc)
        {
            // Verifica com o gerenciador de segurança..
            // Indexa com o gerenciador de indexação.. (inclusive arquivos se houver)
            // Loga com o gerenciador de logging..


            AcessoADados.SalvaVersaoDeDocumentoArquivistico(doc);
        }
    }
}
