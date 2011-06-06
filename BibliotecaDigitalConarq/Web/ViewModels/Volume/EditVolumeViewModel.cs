using Core.Objetos;

namespace Web.ViewModels.Volume
{
    public class EditVolumeViewModel
    {
        public Core.Objetos.Volume Volume { get; set; }

        public VersaoVolume VersaoNova { get; set; }

        public EditVolumeViewModel() {}

        public EditVolumeViewModel(Core.Objetos.Volume volume)
        {
            Volume = volume;

            PreencheVersaoNova();
        }

        public void PreencheVersaoNova()
        {
            VersaoNova = new VersaoVolume();
            VersaoNova.NumeroDoVolume = Volume.VersaoAtual.NumeroDoVolume;
            VersaoNova.Localizacao = Volume.VersaoAtual.Localizacao;
            VersaoNova.QuantidadeDeFolhas = Volume.VersaoAtual.QuantidadeDeFolhas;
            VersaoNova.TipoDoMeio = Volume.VersaoAtual.TipoDoMeio;
        }
    }
}