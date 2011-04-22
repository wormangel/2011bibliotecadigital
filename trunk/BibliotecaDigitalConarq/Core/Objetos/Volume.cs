using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Objetos
{
    public class Volume
    {
        // Metadados 1.6 - Identificador do volume
        public long Id { get; set; }

        // Referência
        // Metadados 1.4 - Identificador do processo/dossiê
        public long IdProcessoDossie
        {
            get { return DocumentoArquivistico.Id; }
        }

        // Referência
        // Metadados 1.5 - Identificador do processo/dossiê
        public string NumeroDoProcessoOuDossie
        {
            get { return DocumentoArquivistico.NumeroDoProcessoOuDossie; }
        }

        // Metadados 1.7 - Número do volume
        public string NumeroDoVolume { get; set; }




        // Referências

        // O processo/dossiê a que este volume pertence
        public DocumentoArquivistico DocumentoArquivistico { get; set; }

        // Os documentos que este volume contém
        public IEnumerable<Documento> Documentos { get; set; }

    }
}
