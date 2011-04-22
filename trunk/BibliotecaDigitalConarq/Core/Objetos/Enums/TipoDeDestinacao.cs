using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Core.Objetos.Enums
{
    public enum TipoDeDestinacao
    {
        [Description("Transferência,")]
        Transferencia,

        [Description("Eliminação")]
        Eliminacao,

        [Description("Recolhimento")]
        Recolhimento
    }
}
