using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Core.Objetos.Classificacoes
{
    public class Classificacao
    {
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Required(ErrorMessage = "O nome da classificação deve ser informado"), Display(Name = "Nome da classificação")]
        public String Nome { get; set; }

        [Required(ErrorMessage = "O código da classificação deve ser informado"), Display(Name = "Código da classificação")]
        public String Codigo { get; set; }

        public Boolean Ativa { get; set; }

        [Display(Name = "Registros a respeito da classe")]
        public virtual ICollection<RegistroClasse> RegistrosClasse { get; set; }

        public virtual ICollection<DocumentoArquivistico> DocumentosArquivisticos { get; set; }
    }
}
