using System.Collections.Generic;
using System.Web.Mvc;
using Core.Gerenciadores;
using Core.Interfaces;
using Core.Objetos;

namespace Web.Controllers
{
    public class DocumentoArquivisticoController : Controller
    {
        private readonly GerenciadorDocumentosArquivisticos _servico;

        public DocumentoArquivisticoController(IRepositorio<DocumentoArquivistico> repositorio)
        {
            _servico = new GerenciadorDocumentosArquivisticos(repositorio);
        }

        //
        // GET: /DocumentoArquivistico/

        public ViewResult Index()
        {
            IEnumerable<DocumentoArquivistico> documentos = _servico.RecuperarDocumentos();
            return View(documentos);
        }

        //
        // GET: /DocumentoArquivistico/Details/5

        public ViewResult Details(long id)
        {
            return View(_servico.RecuperarPorId(id));
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
                _servico.Salvar(documentoArquivistico);
                return RedirectToAction("Index");
            }

            return View(documentoArquivistico);
        }

        //
        // GET: /DocumentoArquivistico/Editar/5

        public ActionResult Edit(long id)
        {
            // mesma coisa do details, ver se tem como reaproveitar algo (DRY!)
            return View(_servico.RecuperarPorId(id));
        }

        //
        // POST: /DocumentoArquivistico/Editar/5

        [HttpPost]
        public ActionResult Edit(DocumentoArquivistico documentoarquivistico)
        {
            if (ModelState.IsValid)
            {
                _servico.Salvar(documentoarquivistico);
                return RedirectToAction("Index");
            }
            return View(documentoarquivistico);
        }

        //
        // GET: /DocumentoArquivistico/Delete/5

        public ActionResult Delete(long id)
        {
            // mesma coisa do details, ver se tem como reaproveitar algo (DRY!)
            return View(_servico.RecuperarPorId(id));
        }

        //
        // POST: /DocumentoArquivistico/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(long id)
        {
            _servico.Remover(id);
            return RedirectToAction("Index");
        }
    }
}