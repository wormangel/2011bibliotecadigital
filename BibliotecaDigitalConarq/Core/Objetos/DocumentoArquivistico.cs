using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Core.Objetos.Classificacoes;
using Core.Objetos.Enums;

namespace Core.Objetos
{
    public class DocumentoArquivistico
    {
        // Metadados 1.4 - Identificador do processo/dossiê (O)
        /// <summary>
        /// Identificador único atribuído ao processo ou dossiê no ato de
        /// sua captura para o SIGAD.
        /// </summary>
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Display(Name = "Versões do documento arquívistico")]
        public virtual ICollection<VersaoDocumentoArquivistico> Versoes { get; set; }

        private VersaoDocumentoArquivistico versaoAtual;
        public virtual VersaoDocumentoArquivistico VersaoAtual
        {
            get
            {
                if (versaoAtual == null)
                    versaoAtual = Versoes.AsQueryable().OrderByDescending(w => w.NumeroDaVersao).FirstOrDefault();
                return versaoAtual;
            }
        }

        // Referências

        // Os volumes que este processo/dossiê contém
        [Display(Name = "Volumes contidos neste documento arquivístico")]
        public virtual ICollection<Volume> Volumes { get; set; }
    }

    // Referente ao 'Processo/Dossiê' citado na documentação da CONARQ
    public class VersaoDocumentoArquivistico
    {

        [Display(Name = "Número da versão"), Key]
        public long NumeroDaVersao { get; set; }

        // Metadados 1.5 - Número do processo/dossiê (O)
        /// <summary>
        /// Número ou código alfanumérico de registro do processo ou
        /// dossiê.
        /// </summary>
        [Required(ErrorMessage = "Um documento arquivístico deve ter um número de processo/dossiê"), Display(Name = "Número do processo/dossiê")]
        public String NumeroDoProcessoOuDossie { get; set; }

        // Metadados 1.8 - Tipo de meio (O)
        /// <summary>
        /// Identificação do meio do documento/volume/processo/dossiê:
        /// digital, não digital ou híbrido.
        /// </summary>
        [Required(ErrorMessage = "Um documento arquivístico deve ser classificado quanto ao meio"), Display(Name = "Tipo do meio")]
        public TipoDoMeio TipoDoMeio { get; set; }

        // Metadados 1.11 - Título (F)
        /// <summary>
        /// Elemento de descrição que nomeia o documento ou Processo |
        /// Dossiê. Pode ser formal ou atribuído:
        /// - formal - designação registrada no documento;
        /// - atribuído - designação providenciada para identificação de
        ///   um documento formalmente desprovido de titulo.
        /// </summary>
        [Display(Name = "Título do documento")]
        public String Titulo { get; set; }

        // Metadados 1.11 - Tipo do Título (F)
        /// <summary>
        /// Identifica o tipo do título, formal ou atribuído.
        /// </summary>
        [Display(Name = "Tipo do título")]
        public TipoDoTitulo TipoDoTitulo { get; set; }

        // Metadados 1.12 - Descrição (F)
        /// <summary>
        /// Exposição concisa do conteúdo do documento, processo ou
        /// dossiê.
        /// </summary>
        [Display(Name = "Descrição")]
        public String Descricao { get; set; }

        // Metadados 1.13 - Assunto (F)
        /// <summary>
        /// Palavras-chave que representam o conteúdo do documento.
        /// Pode ser de preenchimento livre ou com o uso de vocabulário
        /// controlado ou tesauro.
        /// Diferente do já estabelecido no código de classificação.
        /// </summary>
        [Display(Name = "Assunto")]
        public String Assunto { get; set; }

        // Metadados 1.14 - Autor (O)
        /// <summary>
        /// Pessoa física ou jurídica com autoridade para emitir o
        /// documento e em cujo nome ou sob cuja ordem ou
        /// responsabilidade o documento é emitido.
        /// </summary>
        [Required(ErrorMessage = "O autor deve ser informado"), Display(Name = "Autor")]
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
        [Display(Name = "Destinatário")]
        public String Destinatario { get; set; }

        // Metadados 1.15 - Tipo do Destinatário (F)
        /// <summary>
        /// Identifica o tipo do destinatário, nominal ou geral.
        /// </summary>
        [Display(Name = "Tipo do Destinatário")]
        public TipoDoDestinatario TipoDoDestinatario { get; set; }

        // Metadados 1.18 - Interessado (O)
        /// <summary>
        /// Nome e/ou identificação da pessoa física ou jurídica que tem
        /// envolvimento ou a quem interessa o assunto do documento.
        /// </summary>
        [Required(ErrorMessage = "O interessado deve ser informado"), Display(Name = "Interessado")]
        public String Interessado { get; set; }

        // Metadados 1.19 - Procedência (O)
        /// <summary>
        /// Origem do registro do documento, isto é, instituição
        /// legitimamente responsável pela autuação e/ou registro do
        /// Processo | Dossiê.
        /// </summary>
        [Required(ErrorMessage = "A procedência deve ser informada"), Display(Name = "Procedencia")]
        public String Procedencia { get; set; }

        // Metadados 1.25 - Quantidade de folhas/páginas (O)
        /// <summary>
        /// Indicação da quantidade de folhas/páginas de um documento.
        /// </summary>
        [Required(ErrorMessage = "A quantidade de folhas/páginas deve ser informada"), Display(Name = "Quantidade de folhas/páginas")]
        public String QuantidadeDeFolhas { get; set; }

        //TODO como fazer isso? deixar na mão mesmo?
        // Metadados 1.26 - Numeração sequencial dos documentos (O)
        /// <summary>
        /// Numeração sequencial dos documentos inseridos em um
        /// processo.
        /// </summary>
        [Required(ErrorMessage = "A numeração deve ser informada"), Display(Name = "Numeração sequencial")]
        public String NumeracaoSequencialDosDocumentos { get; set; }

        ///TODO 1.28 e 1.29 deixados de fora por enquanto (RELAÇÕES e NIVEIS DE ACESSO)

        // Metadados 1.30 - Data de produção (O)
        /// <summary>
        /// Registro cronológico (data e hora) e tópico (local) da
        /// produção do documento.
        /// </summary>
        [Required(ErrorMessage = "A data de produção deve ser informada"), Display(Name = "Data de produção")]
        public String DataDeProducao { get; set; }

        // Metadados 1.31 - Classe (O)
        /// <summary>
        /// Identificação da classe do documento com base em um
        /// plano de classificação.
        /// </summary>
        [Required(ErrorMessage = "A classe deve ser informada"), Display(Name = "Classe")]
        public String Classe { get; set; }

        //TODO Temporalidade - próximas iterações
        // Metadados 1.32 - Destinação prevista (O)
        /// <summary>
        /// Indicação da próxima ação de destinação (transferência,
        /// eliminação ou recolhimento) prevista para o documento, em
        /// cumprimento à tabela de temporalidade.
        /// </summary>
        [Required(ErrorMessage = "A destinação deve ser informada"), Display(Name = "Destinação prevista")]
        public TipoDeDestinacao DestinacaoPrevista { get; set; }

        //TODO Temporalidade - próximas iterações
        // Metadados 1.33 - Prazo de guarda (O)
        /// <summary>
        /// Indicação do prazo estabelecido em tabela de temporalidade
        /// para o cumprimento da destinação.
        /// </summary>
        [Required(ErrorMessage = "O prazo de guarda deve ser informado"), Display(Name = "Prazo de guarda")]
        public String PrazoDeGuarda{ get; set; }

        // Metadados 1.34 - Localização (OA)
        /// <summary>
        /// Local de armazenamento atual do documento.
        /// Pode ser um lugar (depósito, estante, repositório digital) uma
        /// notação física.
        /// </summary>
        [Required(ErrorMessage = "A localização deve ser informada"), Display(Name = "Localização")]
        public String Localizacao { get; set; }

        
    }

}
