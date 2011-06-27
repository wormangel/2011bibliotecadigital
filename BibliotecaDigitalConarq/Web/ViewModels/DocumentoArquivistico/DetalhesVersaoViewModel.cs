using Core.Objetos;

namespace Web.ViewModels.DocumentoArquivistico
{
    public class DetalhesVersaoViewModel
    {
        public Core.Objetos.DocumentoArquivistico DocumentoArquivistico { get; set; }
        public Core.Objetos.VersaoDocumentoArquivistico Versao { get; set; }

        public DetalhesVersaoViewModel(Core.Objetos.DocumentoArquivistico docArq, VersaoDocumentoArquivistico versao)
        {
            DocumentoArquivistico = docArq;
            Versao = versao;
        }
    }
}