using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.Objetos;

namespace Core.Gerenciadores
{
    public class GerenciadorAcessoADados
    {
        private DateTime DataValidadeVersaoMaisAtual = DateTime.MaxValue;
        private ContextoAcessoADados Contexto = new ContextoAcessoADados();

        public void CriaDocumento(Documento doc)
        {
            Contexto.Documentos.Add(doc);
            Contexto.SaveChanges();  //TODO Talvez não seja ideal deixar o SaveChanges() aqui
        }

        public void AtualizaDocumento(Documento doc)
        {
            // Modifica a data de validade da versão atualmente no banco
            Documento versaoAnterior = Contexto.Documentos.Find(doc.Id);
            versaoAnterior.VersaoValidaAte = DateTime.Now;
            Contexto.Documentos.Add(versaoAnterior); //TODO Isso vai updatear mesmo?

            // Atribui a data de validade da nova versão para a data infinita
            doc.VersaoValidaDesde = DateTime.Now;
            doc.VersaoValidaAte = DataValidadeVersaoMaisAtual;
            Contexto.Documentos.Add(doc);

            Contexto.SaveChanges();
        }
    }
}
