using System.Collections.Generic;
using System.Web.Mvc;
using Core.Interfaces;
using Core.Objetos;
using Core.Gerenciadores;

namespace Web.Controllers
{ 
    public class DocumentoController : Controller
    {
        private readonly GerenciadorDocumentosArquivisticos servico;

        public DocumentoController(IRepositorio<DocumentoArquivistico> repositorio)
        {
            servico =  new GerenciadorDocumentosArquivisticos(repositorio);
        }

        //
        // GET: /Documento/

        public ViewResult Index()
        {
            IEnumerable<DocumentoArquivistico> documentos = servico.RecuperarDocumentos();
            return View(documentos);
        }

        //
        // GET: /Documento/Details/5

        public ViewResult Details(long id)
        {
            return View(servico.RecuperarPorId(id));
        }

        //
        // GET: /Documento/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Documento/Create

        [HttpPost]
        public ActionResult Create(Documento documento)
        {
            if (ModelState.IsValid)
            {
                servico.Salvar(documento);
                return RedirectToAction("Index");  
            }

            return View(documento);
        }
        
        //
        // GET: /Documento/Editar/5
 
        public ActionResult Edit(long id)
        {
            return View(servico.RecuperarPorId(id));
        }

        //
        // POST: /Documento/Editar/5

        [HttpPost]
        public ActionResult Edit(Documento documento)
        {
            if (ModelState.IsValid)
            {
                servico.Salvar(documento);
                return RedirectToAction("Index");
            }
            return View(documento);
        }

        //
        // GET: /Documento/Delete/5
 
        public ActionResult Delete(long id)
        {
            return View(servico.RecuperarPorId(id));
        }

        //
        // POST: /Documento/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(long id)
        {
            servico.Remover(id);
            return RedirectToAction("Index");
        }

    }
}