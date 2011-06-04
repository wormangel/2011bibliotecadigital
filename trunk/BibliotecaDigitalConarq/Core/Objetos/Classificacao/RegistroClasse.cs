using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Core.Objetos.Classificacao
{
    public class RegistroClasse
    {

        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Display(Name = "Subclasse que contém este grupo")]
        public virtual Classificacao Subclasse { get; set; }

        public TipoRegistroClasse TipoRegistro { get; set;}

        public String Responsavel { get; set; }
    }

    public internal enum TipoRegistroClasse
    {
        [Description("Abertura")]
        Abertura,

        [Description("Desativação")]
        Desativacao,

        [Description("Reativação")]
        Reativacao,

        [Description("Mudança de nome")]
        MudancaNome,

        [Description("Deslocamento")]
        Deslocamento,

        [Description("Extinção")]
        Extincao
    }
}
