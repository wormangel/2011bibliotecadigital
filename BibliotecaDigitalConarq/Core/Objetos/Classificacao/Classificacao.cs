using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Core.Objetos.Classificacao
{
    public class Classificacao
    {
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        public String Nome { get; set; }

        public String Codigo { get; set; }

        public Boolean Ativa { get; set; }

        [Display(Name = "Registros a respeito da classe")]
        public virtual ICollection<RegistroClasse> RegistrosClasse { get; set; }

        public virtual ICollection<DocumentoArquivistico> DocumentosArquivisticos { get; set; }
}
