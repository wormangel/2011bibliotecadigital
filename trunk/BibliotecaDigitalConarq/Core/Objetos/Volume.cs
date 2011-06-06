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
        /// <summary>
        /// Identificador único atribuído ao volume do processo ou
        /// dossiê no ato de sua captura para o SIGAD.
        /// </summary>
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Display(Name = "Versões do volume")]
        public virtual ICollection<VersaoVolume> Versoes { get; set; }

        private VersaoVolume versaoAtual;
        public virtual VersaoVolume VersaoAtual
        {
            get
            {
                if (versaoAtual == null)
                    versaoAtual = Versoes.AsQueryable().OrderByDescending(w => w.NumeroDaVersao).FirstOrDefault();
                return versaoAtual;
            }
    }

        // Referências

        // Referência
        // Metadados 1.4 - Identificador do processo/dossiê (OA)
        /// <summary>
        /// Identificador único atribuído ao processo ou dossiê no ato de
        /// sua captura para o SIGAD.
        /// </summary>
        public long IdProcessoDossie
        {
            get { return (DocumentoArquivistico != null) ? DocumentoArquivistico.Id : -1; }
        }

        // Referência
        // Metadados 1.5 - Número do processo/dossiê (F)
        /// <summary>
        /// Número ou código alfanumérico de registro do processo ou
        /// dossiê.
        /// </summary>
        public String NumeroDoProcessoOuDossie
        {
            get { return (DocumentoArquivistico != null) ? DocumentoArquivistico.VersaoAtual.NumeroDoProcessoOuDossie : null; }
        }

        // O processo/dossiê a que este volume pertence
        public virtual DocumentoArquivistico DocumentoArquivistico { get; set; }

        // Os documentos que este volume contém
        public virtual ICollection<Documento> Documentos { get; set; }    
    }

    public class VersaoVolume
    {
        [Display(Name = "Número da versão"), Key]
        public long NumeroDaVersao { get; set; }

        // Metadados 1.7 - Número do volume (O)
        /// <summary>
        /// Número de registro do volume do processo ou dossiê.
        /// </summary>
        [Required(ErrorMessage = "O número do volume deve ser informado"), Display(Name = "Número do volume")]
        public String NumeroDoVolume { get; set; }

        // Metadados 1.8 - Tipo de meio (O)
        /// <summary>
        /// Identificação do meio do documento/volume/processo/dossiê:
        /// digital, não digital ou híbrido.
        /// </summary>
        [Required(ErrorMessage = "Um volume deve ser classificado quanto ao meio"), Display(Name = "Tipo do meio")]
        public TipoDoMeio TipoDoMeio { get; set; }

        // Metadados 1.25 - Quantidade de folhas/páginas (O)
        /// <summary>
        /// Indicação da quantidade de folhas/páginas de um documento.
        /// </summary>
        [Required(ErrorMessage = "A quantidade de folhas/páginas deve ser informada"), Display(Name = "Quantidade de folhas/páginas")]
        public int QuantidadeDeFolhas { get; set; }

        // Metadados 1.34 - Localização (F)
        /// <summary>
        /// Local de armazenamento atual do documento.
        /// Pode ser um lugar (depósito, estante, repositório digital) uma
        /// notação física.
        /// </summary>
        [Display(Name = "Localização")]
        public String Localizacao { get; set; }
    }
}
