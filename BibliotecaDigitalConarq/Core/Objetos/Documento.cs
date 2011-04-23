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
        /// <summary>
        /// Identificador único atribuído ao documento no ato de sua
        /// captura para o SIGAD.
        /// </summary>
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        // Metadados 1.2 - Número do documento (OA)
        /// <summary>
        /// Número ou código alfanumérico atribuído ao documento no
        /// ato da sua produção.
        /// </summary>
        [Required]
        public String NumeroDoDocumento { get; set; }

        // Metadados 1.3 - Número do protocolo (OA)
        /// <summary>
        /// Número ou código alfanumérico atribuído ao documento no
        /// ato do protocolo.
        /// </summary>
        [Required]
        public String NumeroDoProtocolo { get; set; }

        // Referência
        // Metadados 1.4 - Identificador do processo/dossiê (OA)
        /// <summary>
        /// Identificador único atribuído ao processo ou dossiê no ato de
        /// sua captura para o SIGAD.
        /// </summary>
        public long IdProcessoDossie
        {
            get { return Volume.DocumentoArquivistico.Id; }
        }

        // Referência
        // Metadados 1.6 - Identificador do volume (O)
        /// <summary>
        /// Identificador único atribuído ao volume do processo ou
        /// dossiê no ato de sua captura para o SIGAD.
        /// </summary>
        public long IdVolume
        {
            get { return Volume.Id; }
        }

        // Metadados 1.8 - Tipo de meio (O)
        /// <summary>
        /// Identificação do meio do documento/volume/processo/dossiê:
        /// digital, não digital ou híbrido.
        /// </summary>
        [Required]
        public TipoDoMeio TipoDoMeio { get; set; }

        // Metadados 1.9 - Status (O)
        /// <summary>
        /// Indicação do grau de formalização do documento:
        /// - minuta/rascunho (pré-original) - versão preliminar
        ///   do documento;
        /// - original – primeiro documento completo e efetivo;
        /// - cópia – resultado da reprodução do documento.
        /// </summary>
        [Required]
        public Status Status { get; set; }

        // Metadados 1.10 - Identificador de versão (OA)
        /// <summary>
        /// Identificar a versão do documento e estabelecer a relação
        /// entre as versões anteriores e posteriores.
        /// </summary>
        public String IdVersao { get; set; }

        // Metadados 1.11 - Título (O)
        /// <summary>
        /// Elemento de descrição que nomeia o documento ou Processo |
        /// Dossiê. Pode ser formal ou atribuído:
        /// - formal - designação registrada no documento;
        /// - atribuído - designação providenciada para identificação de
        ///   um documento formalmente desprovido de titulo.
        /// </summary>
        [Required]
        public Status Titulo { get; set; }

        // Metadados 1.11 - Tipo do Título (O)
        /// <summary>
        /// Identifica o tipo do título, formal ou atribuído.
        /// </summary>
        [Required]
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

        // Metadados 1.15 - Destinatário (O)
        /// <summary>
        /// Pessoa física e/ou jurídica a quem foi dirigida a informação
        /// contida no documento.
        /// Pode ser nominal ou geral:
        /// - nominal – pessoas específicas;
        /// - geral – refere-se a uma entidade maior, indeterminada.
        /// Ex.: cidadãos, povo, estudantes, a quem possa interessar, a
        /// todos os envolvidos.
        /// </summary>
        [Required]
        public String Destinatario { get; set; }

        // Metadados 1.15 - Tipo do Destinatário (O)
        /// <summary>
        /// Identifica o tipo do destinatário, nominal ou geral.
        /// </summary>
        [Required]
        public TipoDoDestinatario TipoDoDestinatario { get; set; }

        // Metadados 1.16 - Originador (O)
        /// <summary>
        /// Pessoa física ou jurídica designada no endereço eletrônico ou
        /// log in em que o documento é gerado e/ou enviado.
        /// </summary>
        [Required]
        public String Originador { get; set; }

        // Metadados 1.17 - Redator (O)
        /// <summary>
        /// Responsável pela elaboração do conteúdo do documento.
        /// </summary>
        [Required]
        public String Redator { get; set; }

        // Metadados 1.19 - Procedência (OA)
        /// <summary>
        /// Origem do registro do documento, isto é, instituição
        /// legitimamente responsável pela autuação e/ou registro do
        /// Processo | Dossiê.
        /// </summary>
        [Required]
        public String Procedencia { get; set; }

        // TODO Deveria retornar a lista dos IDs?
        // Referência
        // Metadados 1.20 - Identificador do componente digital (O)
        /// <summary>
        /// Identificador dos componentes digitais que integram o
        /// documento.
        /// </summary>
        public long IdComponenteDigital
        {
            get { return Arquivos[0].ArquivoId; }
        }

        // Metadados 1.21 - Gênero (F)
        /// <summary>
        /// Indica o gênero documental, ou seja, a configuração da
        /// informação no documento de acordo com o sistema de signos
        /// utilizado na comunicação do documento.
        /// Exemplos: Audiovisual; textual; cartográfico; iconográfico; multimídia.
        /// </summary>
        public String Genero { get; set; }

        // Metadados 1.22 - Espécie (F)
        /// <summary>
        /// Indica a espécie documental, ou seja, a configuração da
        /// informação no documento de acordo com a disposição e a
        /// natureza das informações nele contidas.
        /// Exemplos: Processo; oficio; ata; relatório; projeto; prontuário.
        /// </summary>
        public String Especie { get; set; }

        // Metadados 1.23 - Tipo (F)
        /// <summary>
        /// Indica o tipo documental, ou seja, a configuração da espécie
        /// documental de acordo com a atividade que a gerou.
        /// Exemplos: Relatório de pesquisa; carta precatória; ofício-circular;
        /// prontuário médico; prontuário de funcionário.
        /// </summary>
        public String Tipo { get; set; }

        // Metadados 1.24 - Idioma (F)
        /// <summary>
        /// Idioma(s) em que é expresso o conteúdo do documento.
        /// </summary>
        public String Idioma { get; set; }

        // Metadados 1.25 - Quantidade de folhas/páginas (F)
        /// <summary>
        /// Indicação da quantidade de folhas/páginas de um documento.
        /// </summary>
        public String QuantidadeDeFolhas { get; set; }

        // Metadados 1.27 - Indicação de anexos (O)
        /// <summary>
        /// Indica se o documento tem anexos.
        /// </summary>
        public Boolean TemAnexos { get; set; }

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
        /// Identificação da classe52 do documento com base em um
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
        public TimeSpan PrazoDeGuarda { get; set; }

        // Metadados 1.34 - Localização (OA)
        /// <summary>
        /// Local de armazenamento atual do documento.
        /// Pode ser um lugar (depósito, estante, repositório digital) uma
        /// notação física.
        /// </summary>
        [Required]
        public String Localizacao { get; set; }

        public DateTime VersaoValidaDesde { get; set; }

        public DateTime VersaoValidaAte { get; set; }

        // Referências

        // Os arquivos que compõem este documento
        public List<Arquivo> Arquivos { get; set; }

        // O volume a que este documento pertence
        [Required]
        public Volume Volume { get; set; }

    }
}
