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

        // Metadados 1.18 - Interessado (O)
        [Required]
        public String Interessado { get; set; }

        // Metadados 1.19 - Procedência (O)
        [Required]
        public String Procedencia { get; set; }

        // Metadados 1.25 - Quantidade de folhas/páginas (O)
        [Required]
        public String QuantidadeDeFolhas { get; set; }

        // Metadados 1.26 - Numeração sequencial dos documentos (O)
        //TODO como fazer isso? deixar na mão mesmo?
        [Required]
        public String NumeracaoSequencialDosDocumentos { get; set; }

        // Metadados 1.29 - Níveis de acesso (O)
        //TODO Ver isso!
        public object NiveisDeAcesso { get; set; }

        // Metadados 1.30 - Data de produção (O)
        [Required]
        public DateTime DataDeProducao { get; set; }

        // Metadados 1.31 - Classe (O)
        [Required]
        public String Classe { get; set; }

        // Metadados 1.32 - Destinação prevista (O)
        [Required]
        public TipoDeDestinacao DestinacaoPrevista { get; set; }

        // Metadados 1.33 - Prazo de guarda (O)
        [Required]
        public TimeSpan PrazoDeGuarda{ get; set; }

        // Metadados 1.34 - Localização (OA)
        [Required]
        public String Localizacao { get; set; }

        // Referências

        // Os volumes que este processo/dossiê contém
        public List<Volume> Volumes { get; set; }
    }

}
