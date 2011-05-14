using System.Collections.Generic;
using System.Web.Mvc;
using Core.Gerenciadores;
using Core.Interfaces;
using Core.Objetos;
using Ninject;

namespace Web.Controllers
{
    public class VolumeController : Controller
    {
        [Inject]
        private readonly FachadaGerenciadores _fachada;

        public VolumeController(FachadaGerenciadores fachada)
        {
            _fachada = fachada;
        }

        //
        // GET: /DocumentoArquivistico/1/Volume/

        public ViewResult Index(long idDocumentoArquivistico)
        {
            IEnumerable<Volume> volumes = _fachada.RecuperarVolumes();
            return View(volumes);
        }

        //
        // GET: /DocumentoArquivistico/1/Volume/Details/5

        public ViewResult Details(long idDocumentoArquivistico, long id)
        {
            return View(_fachada.RecuperarVolumePorId(id));
        }

        //
        // GET: /DocumentoArquivistico/1/Volume/Create

        public ActionResult Create(long idDocumentoArquivistico)
        {
            return View();
        }

        //
        // POST: /DocumentoArquivistico/1/Volume/Create

        [HttpPost]
        public ActionResult Create(long idDocumentoArquivistico, Volume volume)
        {
            if (ModelState.IsValid)
            {
                _fachada.AdicionarVolume(volume);
                return RedirectToAction("Index");
            }

            return View(volume);
        }

        //
        // GET: /DocumentoArquivistico/1/Volume/Editar/5

        public ActionResult Edit(long idDocumentoArquivistico, long id)
        {
            // mesma coisa do details, ver se tem como reaproveitar algo (DRY!)
            return View(_fachada.RecuperarVolumePorId(id));
        }

        //
        // POST: /DocumentoArquivistico/1/Volume/Editar/5

        [HttpPost]
        public ActionResult Edit(long idDocumentoArquivistico, Volume volume)
        {
            if (ModelState.IsValid)
            {
                _fachada.SalvarVolume(volume);
                return RedirectToAction("Index");
            }
            return View(volume);
        }

        //
        // GET: /DocumentoArquivistico/1/Volume/Delete/5

        public ActionResult Delete(long idDocumentoArquivistico, long id)
        {
            // mesma coisa do details, ver se tem como reaproveitar algo (DRY!)
            return View(_fachada.RecuperarVolumePorId(id));
        }

        //
        // POST: /DocumentoArquivistico/1/Volume/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(long idDocumentoArquivistico, long id)
        {
            _fachada.RemoverVolume(id);
            return RedirectToAction("Index");
        }
    }
}