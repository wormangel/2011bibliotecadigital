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
        /// <summary>
        /// Identificador único atribuído ao processo ou dossiê no ato de
        /// sua captura para o SIGAD.
        /// </summary>
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        // Metadados 1.5 - Número do processo/dossiê (O)
        /// <summary>
        /// Número ou código alfanumérico de registro do processo ou
        /// dossiê.
        /// </summary>
        [Required]
        public String NumeroDoProcessoOuDossie { get; set; }

        // Metadados 1.8 - Tipo de meio (O)
        /// <summary>
        /// Identificação do meio do documento/volume/processo/dossiê:
        /// digital, não digital ou híbrido.
        /// </summary>
        [Required]
        public TipoDoMeio TipoDoMeio { get; set; }

        // Metadados 1.11 - Título (F)
        /// <summary>
        /// Elemento de descrição que nomeia o documento ou Processo |
        /// Dossiê. Pode ser formal ou atribuído:
        /// - formal - designação registrada no documento;
        /// - atribuído - designação providenciada para identificação de
        ///   um documento formalmente desprovido de titulo.
        /// </summary>
        public String Titulo { get; set; }

        // Metadados 1.11 - Tipo do Título (F)
        /// <summary>
        /// Identifica o tipo do título, formal ou atribuído.
        /// </summary>
        public TipoDoTitulo TipoDoTitulo { get; set; }

        // Metadados 1.12 - Descrição (F)
        /// <summary>
        /// Exposição concisa do conteúdo do documento, processo ou
        /// dossiê.
        /// </summary>
        public String Descricao { get; set; }

        // Metadados 1.13 - Assunto (F)
        /// <summary>
        /// Palavras-chave que representam o conteúdo do documento.
        /// Pode ser de preenchimento livre ou com o uso de vocabulário
        /// controlado ou tesauro.
        /// Diferente do já estabelecido no código de classificação.
        /// </summary>
        public String Assunto { get; set; }

        // Metadados 1.14 - Autor (O)
        /// <summary>
        /// Pessoa física ou jurídica com autoridade para emitir o
        /// documento e em cujo nome ou sob cuja ordem ou
        /// responsabilidade o documento é emitido.
        /// </summary>
        [Required]
        public String Autor { get; set; }

        // Metadados 1.15 - Destinatário (F)
        /// <summary>
        /// Pessoa física e/ou jurídica a quem foi dirigida a informação
        /// contida no documento.
        /// Pode ser nominal ou geral:
        /// - nominal – pessoas específicas;
        /// - geral – refere-se a uma entidade maior, indeterminada.
        /// Ex.: cidadãos, povo, estudantes, a quem possa interessar, a
        /// todos os envolvidos.
        /// </summary>
        public String Destinatario { get; set; }

        // Metadados 1.15 - Tipo do Destinatário (F)
        /// <summary>
        /// Identifica o tipo do destinatário, nominal ou geral.
        /// </summary>
        public TipoDoDestinatario TipoDoDestinatario { get; set; }

        // Metadados 1.18 - Interessado (O)
        /// <summary>
        /// Nome e/ou identificação da pessoa física ou jurídica que tem
        /// envolvimento ou a quem interessa o assunto do documento.
        /// </summary>
        [Required]
        public String Interessado { get; set; }

        // Metadados 1.19 - Procedência (O)
        /// <summary>
        /// Origem do registro do documento, isto é, instituição
        /// legitimamente responsável pela autuação e/ou registro do
        /// Processo | Dossiê.
        /// </summary>
        [Required]
        public String Procedencia { get; set; }

        // Metadados 1.25 - Quantidade de folhas/páginas (O)
        /// <summary>
        /// Indicação da quantidade de folhas/páginas de um documento.
        /// </summary>
        [Required]
        public String QuantidadeDeFolhas { get; set; }

        //TODO como fazer isso? deixar na mão mesmo?
        // Metadados 1.26 - Numeração sequencial dos documentos (O)
        /// <summary>
        /// Numeração sequencial dos documentos inseridos em um
        /// processo.
        /// </summary>
        [Required]
        public String NumeracaoSequencialDosDocumentos { get; set; }

        ///TODO 1.28 e 1.29 deixados de fora por enquanto (RELAÇÕES e NIVEIS DE ACESSO)

        // Metadados 1.30 - Data de produção (O)
        /// <summary>
        /// Registro cronológico (data e hora) e tópico (local) da
        /// produção do documento.
        /// </summary>
        [Required]
        public DateTime DataDeProducao { get; set; }

        // Metadados 1.31 - Classe (O)
        /// <summary>
        /// Identificação da classe do documento com base em um
        /// plano de classificação.
        /// </summary>
        [Required]
        public String Classe { get; set; }

        //TODO Temporalidade - próximas iterações
        // Metadados 1.32 - Destinação prevista (O)
        /// <summary>
        /// Indicação da próxima ação de destinação (transferência,
        /// eliminação ou recolhimento) prevista para o documento, em
        /// cumprimento à tabela de temporalidade.
        /// </summary>
        [Required]
        public TipoDeDestinacao DestinacaoPrevista { get; set; }

        //TODO Temporalidade - próximas iterações
        // Metadados 1.33 - Prazo de guarda (O)
        /// <summary>
        /// Indicação do prazo estabelecido em tabela de temporalidade
        /// para o cumprimento da destinação.
        /// </summary>
        [Required]
        public TimeSpan PrazoDeGuarda{ get; set; }

        // Metadados 1.34 - Localização (OA)
        /// <summary>
        /// Local de armazenamento atual do documento.
        /// Pode ser um lugar (depósito, estante, repositório digital) uma
        /// notação física.
        /// </summary>
        [Required]
        public String Localizacao { get; set; }

        // Referências

        // Os volumes que este processo/dossiê contém
        public List<Volume> Volumes { get; set; }
    }

}
