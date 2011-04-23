using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.Objetos;

namespace Core.Gerenciadores
{
    public class GerenciadorAcessoADados
    {
        private ContextoAcessoADados Contexto = new ContextoAcessoADados();

        public void SalvaVersaoDeDocumentoArquivistico(Documento doc)
        {
            Contexto.Documentos.Add(doc);
            Contexto.SaveChanges();  //TODO Talvez não seja ideal deixar o SaveChanges() aqui
        }
    }
}
