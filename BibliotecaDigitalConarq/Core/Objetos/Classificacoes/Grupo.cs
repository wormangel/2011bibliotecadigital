using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Core.Objetos.Classificacoes
{
    public class Grupo : Classificacao
    {
        public long IdSubclasse { get { return (Subclasse != null) ? Subclasse.Id : -1; }  }

        [Display(Name = "Subclasse que contém este grupo")]
        public virtual Subclasse Subclasse { get; set; }

        [Display(Name = "Subgrupos contidos neste grupo")]
        public virtual ICollection<Subgrupo> Subgrupos { get; set; }
    }
}
