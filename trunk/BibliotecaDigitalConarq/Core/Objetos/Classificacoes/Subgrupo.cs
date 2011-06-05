using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Core.Objetos.Classificacoes
{
    public class Subgrupo : Classificacao
    {
        public long IdSubclasse { get { return (Grupo != null) ? Grupo.Id : -1; } }

        [Display(Name = "Grupo que contém este subgrupo")]
        public virtual Grupo Grupo { get; set; }
    }
}
