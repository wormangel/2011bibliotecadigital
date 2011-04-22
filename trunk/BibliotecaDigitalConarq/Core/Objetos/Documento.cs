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

        // Metadados 1.17 - Redator (O)
        [Required]
        public String Redator { get; set; }

        // Metadados 1.19 - Procedência (OA)
        [Required]
        public String Procedencia { get; set; }

        // Referência
        // Metadados 1.20 - Identificador do componente digital (O)
        // TODO Deveria retornar a lista dos IDs?
        public long IdComponenteDigital
        {
            get { return Arquivos[0].ArquivoId; }
        }

        // Metadados 1.21 - Gênero (F)
        public String Genero { get; set; }

        // Metadados 1.22 - Espécie (F)
        public String Especie { get; set; }

        // Metadados 1.23 - Tipo (F)
        public String Tipo { get; set; }

        // Metadados 1.24 - Idioma (F)
        public String Idioma { get; set; }

        // Metadados 1.25 - Quantidade de folhas/páginas (F)
        public String QuantidadeDeFolhas { get; set; }

        // Metadados 1.27 - Indicação de anexos (O)
        public Boolean TemAnexos { get; set; }

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
        public TimeSpan PrazoDeGuarda { get; set; }

        // Metadados 1.34 - Localização (OA)
        [Required]
        public String Localizacao { get; set; }

        // Referências

        // Os arquivos que compõem este documento
        public List<Arquivo> Arquivos { get; set; }

        // O volume a que este documento pertence
        [Required]
        public Volume Volume { get; set; }

    }
}
