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

        //
        // GET: /DocumentoArquivistico/1/Volume/

        public ViewResult Index(long idDocArq)
        {
            IQueryable<Volume> volumes = _fachada.RecuperarVolumes();
            ViewBag.TituloDoc = _fachada.RecuperarDocumentoArquivisticoPorId(idDocArq).VersaoAtual.Titulo;
            ViewBag.IdDocArq = idDocArq;
            return View(volumes);
        }

        //
        // GET: /DocumentoArquivistico/1/Volume/Details/5

        public ViewResult Details(long idDocArq, long id)
        {
            return View(_fachada.RecuperarVolumePorId(id));
        }

        //
        // GET: /DocumentoArquivistico/1/Volume/Create

        public ActionResult Create(long idDocArq)
        {
            return View();
        }

        //
        // POST: /DocumentoArquivistico/1/Volume/Create

        [HttpPost]
        public ActionResult Create(long idDocArq, VersaoVolume versaoSendoCriada)
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

        //
        // GET: /DocumentoArquivistico/1/Volume/Editar/5

        public ActionResult Edit(long idDocArq, long id)
        {

            // mesma coisa do details, ver se tem como reaproveitar algo (DRY!)
            Volume volume = _fachada.RecuperarVolumePorId(id);
            return View(new EditVolumeViewModel(volume));
        }

        //
        // POST: /DocumentoArquivistico/1/Volume/Editar/5

        [HttpPost]
        public ActionResult Edit(long idDocArq, EditVolumeViewModel viewModel)
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

        //
        // GET: /DocumentoArquivistico/1/Volume/Delete/5

        public ActionResult Delete(long idDocArq, long id)
        {
            // mesma coisa do details, ver se tem como reaproveitar algo (DRY!)
            return View(_fachada.RecuperarVolumePorId(id));
        }

        //
        // POST: /DocumentoArquivistico/1/Volume/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(long idDocArq, long id)
        {
            _fachada.RemoverVolume(id);
            return RedirectToAction("Index");
        }
    }
}