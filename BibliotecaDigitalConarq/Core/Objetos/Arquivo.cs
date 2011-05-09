using System;
using System.ComponentModel.DataAnnotations;

namespace Core.Objetos
{
    /// <summary>
    /// Representa um arquivo digital no contexto de um SIGAD definido pela CONARQ.
    /// </summary>
    [Table("Arquivos")]
    public class Arquivo
    {
        /// <summary>
        /// Identificador único do Arquivo. É gerado automaticamente.
        /// </summary>
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public long ArquivoId { get; set; }

        /// <summary>
        /// Nome original do arquivo digital no momento em que foi inserido
        /// no repositório.
        /// </summary>
        [Display(Name = "Nome")]
        public String Nome { get; set; }

        /// <summary>
        /// Propriedades técnicas de um arquivo digital, aplicáveis à 
        /// maioria dos formatos, tais como: nível de composição, tamanho, 
        /// software de criação e inibidores.
        /// </summary>
        [Display(Name = "Características")]
        public String Caracteristicas { get; set; }

        /// <summary>
        /// Identificação do formato de arquivo do arquivo digital.
        /// </summary>
        [Required(ErrorMessage = "É necessário informar o formato do arquivo."), Display(Name = "Formato do Arquivo")]
        public String Formato { get; set; }

        /// <summary>
        /// Informações sobre a localização e o suporte do arquivo,
        /// bem como os recursos necessários para armazenamento permanente.
        /// </summary>
        [Required]
        public String Armazenamento { get; set; }

        /// <summary>
        /// Informações sobre o ambiente de software necessário para apresentar
        /// e/ou usar os arquivos, incluindo a aplicação e o sistema operacional.
        /// </summary>
        [Required(ErrorMessage = "Necessário informar os requisitos de software necessários."), Display(Name = "Ambiente de Software")]
        public String AmbienteSoftware { get; set; }


        /// <summary>
        /// Informações sobre os componentes de hardware necessários para 
        /// operar o software necessário para acesso ao arquivo, incluindo
        /// periféricos.
        /// </summary>
        [Required(ErrorMessage = "Necessário informar os requisitos de hardware ncessários"), Display(Name = "Ambiente de Hardware")]
        public String AmbienteHardware { get; set; }

        /// <summary>
        /// Informações sobre outras dependências, que não sejam as de software
        /// e hardware, necessárias para apresentar ou usar os documentos (por 
        /// exemplo, DTD, XML Schema, fontes, folha de estilo).
        /// </summary>
        [Display(Name = "Outras Dependências")]
        public String Dependencias { get; set; }

        /// <summary>
        /// Caminho para o arquivo em disco.
        /// </summary>
        public String CaminhoDoArquivo { get; set; }

        // NOTE Verificar se entra no contexto do projeto
        /// <summary>
        /// Registro das relações de um arquivo com outros 
        /// arquivos ou com documentos.
        /// </summary>
        //public String Relacao { get; set; }
    }
}