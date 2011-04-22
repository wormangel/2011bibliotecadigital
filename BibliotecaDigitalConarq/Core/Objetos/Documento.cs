using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using Core.Objetos.Enums;

namespace Core.Objetos
{
    public class Documento
    {
        // Metadados 1.1 - Identificador do documento (O)
        public long Id { get; set; }

        // Metadados 1.2 - Número do documento (OA)
        [Required]
        public String NumeroDoDocumento { get; set; }

        // Metadados 1.3 - Número do protocolo (OA)
        [Required]
        public String NumeroDoProtocolo { get; set; }

        // Referência
        // Metadados 1.4 - Identificador do processo/dossiê (OA)
        public long IdProcessoDossie
        {
            get { return Volume.DocumentoArquivistico.Id; }
        }

        // Referência
        // Metadados 1.6 - Identificador do volume (O)
        public long IdVolume
        {
            get { return Volume.Id; }
        }

        // Metadados 1.8 - Tipo de meio (O)
        [Required]
        public TipoDoMeio TipoDoMeio { get; set; }

        // Metadados 1.9 - Status (O)
        [Required]
        public Status Status { get; set; }

        // Metadados 1.10 - Identificador de versão (OA)
        // TODO mudar tipo? Required?
        public String IdVersao { get; set; }

        // Metadados 1.11 - Título (O)
        [Required]
        public Status Titulo { get; set; }

        // Metadados 1.11 - Tipo do Título (O)
        [Required]
        public TipoDoTitulo TipoDoTitulo { get; set; }

        // Metadados 1.12 - Descrição (F)
        public String Descricao { get; set; }

        // Metadados 1.13 - Assunto (F)
        public String Assunto { get; set; }

        // Metadados 1.14 - Autor (O)
        [Required]
        public String Autor { get; set; }

        // Metadados 1.15 - Destinatário (O)
        [Required]
        public String Destinatario { get; set; }

        // Metadados 1.15 - Tipo do Destinatário (O)
        [Required]
        public TipoDoDestinatario TipoDoDestinatario { get; set; }

        // Metadados 1.16 - Originador (O)
        [Required]
        public String Originador { get; set; }

        // Referências

        // O volume a que este documento pertence
        [Required]
        public Volume Volume { get; set; }

    }
}
