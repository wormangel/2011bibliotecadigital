using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using Core.Objetos.Classificacoes;
using Core.Objetos.Enums;

namespace Core.Objetos
{
    public class Temporalidade
    {
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Required(ErrorMessage = "O prazo de guarda deve ser informado")]
        [DisplayName("Prazo de guarda (fase corrente)")]
        public int PrazoDeGuardaFaseCorrente { get; set; }

        [Required(ErrorMessage = "O prazo de guarda deve ser informado")]
        [DisplayName("Prazo de guarda (fase intermediária)")]
        public int PrazoDeGuardaFaseIntermediaria { get; set; }

        [Required(ErrorMessage = "A destinação final deve ser informada")]
        [DisplayName("Destinação final")]
        public DestinacaoFinal DestinacaoFinal { get; set; }

        [DisplayName("Obervações para aplicação")]
        public String Observacoes { get; set; }
    }
}
