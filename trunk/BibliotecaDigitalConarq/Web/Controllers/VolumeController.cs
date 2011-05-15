using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Core.Gerenciadores;
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

        public ViewResult Index(long idDocArq)
        {
            IQueryable<Volume> volumes = _fachada.RecuperarVolumes(idDocArq);
            ViewBag.TituloDoc = _fachada.RecuperarDocumentoArquivisticoPorId(idDocArq).Titulo;
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
        public ActionResult Create(long idDocArq, Volume volume)
        {
            if (ModelState.IsValid)
            {
                _fachada.AdicionarVolume(idDocArq, volume);
                return RedirectToAction("Index");
            }

            return View(volume);
        }

        //
        // GET: /DocumentoArquivistico/1/Volume/Editar/5

        public ActionResult Edit(long idDocArq, long id)
        {
            // mesma coisa do details, ver se tem como reaproveitar algo (DRY!)
            return View(_fachada.RecuperarVolumePorId(id));
        }

        //
        // POST: /DocumentoArquivistico/1/Volume/Editar/5

        [HttpPost]
        public ActionResult Edit(long idDocArq, Volume volume)
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