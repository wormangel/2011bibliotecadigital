using System.Collections.Generic;
using System.Web.Mvc;
using Core.Gerenciadores;
using Core.Objetos;
using Ninject;

namespace Web.Controllers
{
    public class DocumentoArquivisticoController : Controller
    {
        [Inject]
        private readonly FachadaGerenciadores _fachada;

        public DocumentoArquivisticoController(FachadaGerenciadores fachada)
        {
            _fachada = fachada;
        }

        //
        // GET: /DocumentoArquivistico/

        public ViewResult Index()
        {
            IEnumerable<DocumentoArquivistico> documentos = _fachada.RecuperarDocumentosArquivisticos();
            return View(documentos);
        }

        //
        // GET: /DocumentoArquivistico/Details/5

        public ViewResult Details(long id)
        {
            return View(_fachada.RecuperarDocumentoArquivisticoPorId(id));
        }

        //
        // GET: /DocumentoArquivistico/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /DocumentoArquivistico/Create

        [HttpPost]
        public ActionResult Create(DocumentoArquivistico documentoArquivistico)
        {
            if (ModelState.IsValid)
            {
                _fachada.AdicionarDocumentoArquivistico(documentoArquivistico);
                return RedirectToAction("Index");
            }

            return View(documentoArquivistico);
        }

        //
        // GET: /DocumentoArquivistico/Editar/5

        public ActionResult Edit(long id)
        {
            // mesma coisa do details, ver se tem como reaproveitar algo (DRY!)
            return View(_fachada.RecuperarDocumentoArquivisticoPorId(id));
        }

        //
        // POST: /DocumentoArquivistico/Editar/5

        [HttpPost]
        public ActionResult Edit(DocumentoArquivistico documentoarquivistico)
        {
            if (ModelState.IsValid)
            {
                _fachada.SalvarDocumentoArquivistico(documentoarquivistico);
                return RedirectToAction("Index");
            }
            return View(documentoarquivistico);
        }

        //
        // GET: /DocumentoArquivistico/Delete/5

        public ActionResult Delete(long id)
        {
            // mesma coisa do details, ver se tem como reaproveitar algo (DRY!)
            return View(_fachada.RecuperarDocumentoArquivisticoPorId(id));
        }

        //
        // POST: /DocumentoArquivistico/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(long id)
        {
            _fachada.RemoverDocumentoArquivistico(id);
            return RedirectToAction("Index");
        }
    }
}