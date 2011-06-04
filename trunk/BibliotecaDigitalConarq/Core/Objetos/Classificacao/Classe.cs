using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Core.Objetos.Classificacao
{
    class Classe : Classificacao
    {
        [Display(Name = "Subclasses contidos nesta classe")]
        public virtual ICollection<Subclasse> Subclasses { get; set; }
    }
}
