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
    public class DocumentoController : Controller
    {
        private GerenciadorDocumentosArquivisticos servico = new GerenciadorDocumentosArquivisticos();

        //
        // GET: /Documento/

        public ViewResult Index()
        {
            IEnumerable<Documento> documentos = servico.RecuperarDocumentos();
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