using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Core.Objetos.Classificacoes
{
    public class Subclasse : Classificacao
    {
        public long IdClasse { get { return (Classe != null) ? Classe.Id : -1; } }

        [Display(Name = "Classe que contém esta subclasse")]
        public virtual Classe Classe { get; set; }

        [Display(Name = "Grupos contidos nesta subclasse")]
        public virtual ICollection<Grupo> Grupos { get; set; }
    }
}
