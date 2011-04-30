using System.ComponentModel;

namespace TrilhaAuditoria.Enums
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