using Core.Objetos;

namespace Web.ViewModels.Volume
{
    public class DetalhesVersaoViewModel
    {
        public Core.Objetos.Volume Volume { get; set; }
        public Core.Objetos.VersaoVolume Versao { get; set; }

        public DetalhesVersaoViewModel(Core.Objetos.Volume volume, VersaoVolume versao)
        {
            Volume = volume;
            Versao = versao;
        }
    }
}