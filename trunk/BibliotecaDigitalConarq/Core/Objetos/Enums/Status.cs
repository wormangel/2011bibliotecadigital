using System.ComponentModel;

namespace Core.Objetos.Enums
{
    public enum Status
    {
        [Description("Minuta/Rascunho (pré-original)")]
        PreOriginal,

        [Description("Original")]
        Original,

        [Description("Cópia")]
        Copia
    }
}
