using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.Objetos.Enums;

namespace Core.Objetos
{
    public class Documento
    {
        // Metadados 1.1 - Identificador do documento
        public long Id { get; set; }

        // Metadados 1.2 - Número do documento
        public string NumeroDoDocumento { get; set; }

        // Metadados 1.3 - Número do protocolo
        public string NumeroDoProtocolo { get; set; }

        // Referência
        // Metadados 1.4 - Identificador do processo/dossiê
        public long IdProcessoDossie
        {
            get { return Volume.DocumentoArquivistico.Id; }
        }

        // Referência
        // Metadados 1.6 - Identificador do volume
        public long IdVolume
        {
            get { return Volume.Id; }
        }

        // Metadados 1.9 - Status
        public Status Status { get; set; }

        // Referências

        // O volume a que este documento pertence
        public Volume Volume { get; set; }

    }
}
