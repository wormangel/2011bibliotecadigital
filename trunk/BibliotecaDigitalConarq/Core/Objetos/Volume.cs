using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using Core.Objetos.Enums;

namespace Core.Objetos
{
    public class Volume
    {
        // Metadados 1.6 - Identificador do volume (O)
        public long Id { get; set; }

        // Referência
        // Metadados 1.4 - Identificador do processo/dossiê (OA)
        public long IdProcessoDossie
        {
            get { return DocumentoArquivistico.Id; }
        }

        // Referência
        // Metadados 1.5 - Número do processo/dossiê (F)
        public String NumeroDoProcessoOuDossie
        {
            get { return DocumentoArquivistico.NumeroDoProcessoOuDossie; }
        }

        // Metadados 1.7 - Número do volume (O)
        [Required]
        public String NumeroDoVolume { get; set; }

        // Metadados 1.8 - Tipo de meio (O)
        [Required]
        public TipoDoMeio TipoDoMeio { get; set; }


        // Referências

        // O processo/dossiê a que este volume pertence
        [Required]
        public DocumentoArquivistico DocumentoArquivistico { get; set; }

        // Os documentos que este volume contém
        public IEnumerable<Documento> Documentos { get; set; }

    }
}
