using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.Gerenciadores;
using Core.Objetos;
using Core.Objetos.Enums;

namespace CodingSandbox
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Documento doc = new Documento("NumeroDoDocumento1", "NumeroDoProtocolo1", TipoDoMeio.Digital,
                                          Status.Original, 1, "Titulo1", TipoDoTitulo.Formal,
                                          "Descricao1", "Assunto1", "Autor1", "Destinatario1",
                                          TipoDoDestinatario.Nominal, "Originador1", "Redator1", "Procedencia1",
                                          "Genero1",
                                          "Especie1", "Tipo1", "Idioma1", "QtdFolhas1", false,
                                          new DateTime(1999, 12, 27), "Classe1", TipoDeDestinacao.Transferencia,
                                          new TimeSpan(10, 10, 10),
                                          "Localizacao1", DateTime.Now, new DateTime(2099, 11, 11), new List<Arquivo>(),
                                          new Volume());
                GerenciadorDocumentosArquivisticos ger = new GerenciadorDocumentosArquivisticos();
                ger.CriaDocumento(doc);
                Console.Write("Documento gerado com sucesso :D");
                Console.ReadKey();
            } catch (Exception exc)
            {
                Console.WriteLine("Erro, vc se lascou :( Pia:" + exc.Message);
                Console.ReadKey();
            }
            
            
        }
    }
}
