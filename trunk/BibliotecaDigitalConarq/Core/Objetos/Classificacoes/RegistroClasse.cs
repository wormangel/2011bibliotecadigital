using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Core.Objetos.Classificacoes
{
    public class RegistroClasse
    {

        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Display(Name = "Subclasse que contém este grupo")]
        public virtual Classificacoes.Classificacao Subclasse { get; set; }

        public TipoRegistroClasse TipoRegistro { get; set;}

        public String Responsavel { get; set; }
    }

    public enum TipoRegistroClasse
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
