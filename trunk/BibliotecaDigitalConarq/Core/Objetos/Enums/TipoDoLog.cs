using System.ComponentModel;

namespace Core.Objetos.Enums
{
    public enum TipoDoLog
    {
        [Description("Normal")]
        Normal,

        [Description("DocumentoArquivistico")]
        DocumentoArquivistico,

        [Description("Volume")]
        Volume,

        [Description("Documento")]
        Documento

    }
}