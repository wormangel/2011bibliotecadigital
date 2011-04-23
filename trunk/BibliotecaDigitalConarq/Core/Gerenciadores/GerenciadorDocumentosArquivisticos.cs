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
            AcessoADados.SalvaVersaoDeDocumentoArquivistico(doc);
        }
    }
}
