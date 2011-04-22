using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Core.Objetos.Enums;

namespace Core.Objetos
{
    // Referente ao 'Processo/Dossiê' citado na documentação da CONARQ
    public class DocumentoArquivistico
    {
        // Metadados 1.4 - Identificador do processo/dossiê (O)
        public long Id { get; set; }

        // Metadados 1.5 - Número do processo/dossiê (O)
        [Required]
        public String NumeroDoProcessoOuDossie { get; set; }

        // Metadados 1.8 - Tipo de meio (O)
        [Required]
        public TipoDoMeio TipoDoMeio { get; set; }

        // Metadados 1.11 - Título (F)
        public Status Titulo { get; set; }

        // Metadados 1.11 - Tipo do Título (F)
        public TipoDoTitulo TipoDoTitulo { get; set; }

        // Metadados 1.12 - Descrição (F)
        public String Descricao { get; set; }

        // Metadados 1.13 - Assunto (F)
        public String Assunto { get; set; }

        // Metadados 1.14 - Autor (O)
        [Required]
        public String Autor { get; set; }

        // Metadados 1.15 - Destinatário (F)
        public String Destinatario { get; set; }

        // Metadados 1.15 - Tipo do Destinatário (F)
        public TipoDoDestinatario TipoDoDestinatario { get; set; }

        // Referências

        // Os volumes que este processo/dossiê contém
        public IEnumerable<Volume> Volumes { get; set; }
    }

}
