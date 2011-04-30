using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Core.Gerenciadores;
using Core.Objetos;
using Web.Models;

namespace Web.Controllers
{ 
    public class DocumentoArquivisticoController : Controller
    {
        private GerenciadorDocumentosArquivisticos servico = new GerenciadorDocumentosArquivisticos();

        //
        // GET: /DocumentoArquivistico/

        public ViewResult Index()
        {
            IEnumerable<DocumentoArquivistico> documentos = servico.RecuperarDocumentos();
            return View(documentos);
        }

        //
        // GET: /DocumentoArquivistico/Details/5

        public ViewResult Details(long id)
        {
            return View(servico.RecuperarPorId(id));
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
                servico.Salvar(documentoArquivistico);
                return RedirectToAction("Index");  
            }

            return View(documentoArquivistico);
        }
        
        //
        // GET: /DocumentoArquivistico/Editar/5
 
        public ActionResult Edit(long id)
        {
            // mesma coisa do details, ver se tem como reaproveitar algo (DRY!)
            return View(servico.RecuperarPorId(id));
        }

        //
        // POST: /DocumentoArquivistico/Editar/5

        [HttpPost]
        public ActionResult Edit(DocumentoArquivistico documentoarquivistico)
        {
            if (ModelState.IsValid)
            {
                servico.Salvar(documentoarquivistico);
                return RedirectToAction("Index");
            }
            return View(documentoarquivistico);
        }

        //
        // GET: /DocumentoArquivistico/Delete/5
 
        public ActionResult Delete(long id)
        {
            // mesma coisa do details, ver se tem como reaproveitar algo (DRY!)
            return View(servico.RecuperarPorId(id));
        }

        //
        // POST: /DocumentoArquivistico/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(long id)
        {
            servico.Remover(id);
            return RedirectToAction("Index");
        }

    }
}