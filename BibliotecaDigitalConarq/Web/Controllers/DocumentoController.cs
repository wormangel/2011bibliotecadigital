using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Core.Gerenciadores;
using Core.Interfaces;
using Core.Objetos;

namespace Web.Controllers
{
    public class DocumentoController : Controller
    {
        private readonly FachadaGerenciadores _fachada;

        public DocumentoController(FachadaGerenciadores fachada)
        {
            _fachada = fachada;
        }

        //
        // GET: /DocumentoArquivistico/1/Volume/1/Documento/

        public ViewResult Index(long idDocArq, long idVol)
        {
            IQueryable<Documento> documentos = _fachada.RecuperarDocumentos();
            return View(documentos);
        }

        //
        // GET: /DocumentoArquivistico/1/Volume/1/Documento/Details/5

        public ViewResult Details(long idDocArq, long idVol, long id)
        {
            return View(_fachada.RecuperarDocumentoPorId(id));
        }

        //
        // GET: /DocumentoArquivistico/1/Volume/1/Documento/Create

        public ActionResult Create(long idDocArq, long idVol)
        {
            return View();
        }

        //
        // POST: /DocumentoArquivistico/1/Volume/1/Documento/Create

        [HttpPost]
        public ActionResult Create(long idDocArq, long idVol, Documento documento)
        {
            if (ModelState.IsValid)
            {
                _fachada.AdicionarDocumento(idDocArq, idVol, documento);
                return RedirectToAction("Index");
            }

            return View(documento);
        }

        //
        // GET: /DocumentoArquivistico/1/Volume/1/Documento/Editar/5

        public ActionResult Edit(long idDocArq, long idVol, long id)
        {
            return View(_fachada.RecuperarDocumentoPorId(id));
        }

        //
        // POST: /DocumentoArquivistico/1/Volume/1/Documento/Editar/5

        [HttpPost]
        public ActionResult Edit(long idDocArq, long idVol, Documento documento)
        {
            if (ModelState.IsValid)
            {
                _fachada.SalvarDocumento(documento);
                return RedirectToAction("Index");
            }
            return View(documento);
        }

        //
        // GET: /DocumentoArquivistico/1/Volume/1/Documento/Delete/5

        public ActionResult Delete(long idDocArq, long idVol, long id)
        {
            return View(_fachada.RecuperarDocumentoPorId(id));
        }

        //
        // POST: /DocumentoArquivistico/1/Volume/1/Documento/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(long idDocArq, long idVol, long id)
        {
            _fachada.RemoverDocumento(id);
            return RedirectToAction("Index");
        }

    }
}