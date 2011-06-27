using Core.Objetos;

namespace Web.ViewModels.Documento
{
    public class DetalhesVersaoViewModel
    {
        public Core.Objetos.Documento Documento { get; set; }
        public Core.Objetos.VersaoDocumento Versao { get; set; }

        public DetalhesVersaoViewModel(Core.Objetos.Documento doc, VersaoDocumento versao)
        {
            Documento = doc;
            Versao = versao;
        }
    }
}