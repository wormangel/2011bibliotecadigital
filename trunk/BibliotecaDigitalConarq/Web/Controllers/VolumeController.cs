using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Core.Gerenciadores;
using Core.Objetos;
using EntityAcessoADados.Gerenciadores;
using Ninject;
using Web.ViewModels.Volume;

namespace Web.Controllers
{
    public class VolumeController : Controller
    {
        [Inject]
        private readonly IFachadaGerenciadores _fachada;

        public VolumeController(IFachadaGerenciadores fachada)
        {
            _fachada = fachada;
        }

        public ViewResult Index(long idDocArq)
        {
            IQueryable<Volume> volumes = _fachada.RecuperarVolumes();
            ViewBag.TituloDoc = _fachada.RecuperarDocumentoArquivisticoPorId(idDocArq).VersaoAtual.Titulo;
            ViewBag.IdDocArq = idDocArq;
            return View(volumes);
        }

        public ViewResult Detalhes(long idDocArq, long id)
        {
            return View(_fachada.RecuperarVolumePorId(id));
        }

        public ActionResult Criar(long idDocArq)
        {
            return View();
        }

        [HttpPost]
        public ActionResult Criar(long idDocArq, VersaoVolume versaoSendoCriada)
        {
            if (ModelState.IsValid)
            {
                Volume volume = new Volume();
                volume.Versoes = new List<VersaoVolume>();
                versaoSendoCriada.NumeroDaVersao = 1;
                volume.Versoes.Add(versaoSendoCriada);

                _fachada.AdicionarVolume(idDocArq, volume);
                return RedirectToAction("Index");
            }

            return View(versaoSendoCriada);
        }

        public ActionResult Editar(long idDocArq, long id)
        {

            // mesma coisa do details, ver se tem como reaproveitar algo (DRY!)
            Volume volume = _fachada.RecuperarVolumePorId(id);
            return View(new EditVolumeViewModel(volume));
        }

        [HttpPost]
        public ActionResult Editar(long idDocArq, EditVolumeViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                Volume volume = _fachada.RecuperarVolumePorId(viewModel.Volume.Id);
                viewModel.VersaoNova.NumeroDaVersao = volume.VersaoAtual.NumeroDaVersao + 1;

                volume.Versoes.Add(viewModel.VersaoNova);

                _fachada.SalvarVolume(volume);
                return RedirectToAction("Index");
            }
            return View(viewModel);
        }

        public ActionResult Remover(long idDocArq, long id)
        {
            // mesma coisa do details, ver se tem como reaproveitar algo (DRY!)
            return View(_fachada.RecuperarVolumePorId(id));
        }

        [HttpPost, ActionName("Remover")]
        public ActionResult RemoverConfirmed(long idDocArq, long id)
        {
            _fachada.RemoverVolume(id);
            return RedirectToAction("Index");
        }

        public ActionResult Versao(long idVolume, long? idVersao)
        {
            Volume volume = _fachada.RecuperarVolumePorId(idVolume);

            if (idVersao != null)
            {
                VersaoVolume versao = volume.Versoes.Where(v => v.NumeroDaVersao == idVersao).FirstOrDefault();
                return View("DetalhesVersao", new DetalhesVersaoViewModel(volume, versao));
            }

            return View(volume);
        }
    }
}