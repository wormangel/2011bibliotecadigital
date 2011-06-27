using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Core.Gerenciadores;
using Core.Objetos.Classificacoes;
using Ninject;

namespace Web.Controllers
{
    public class ClasseController : Controller
    {
        [Inject]
        private readonly IFachadaGerenciadores _fachada;
        
        public ClasseController(IFachadaGerenciadores fachada)
        {
            this._fachada = fachada;
        }
        
        //
        // GET: /Classe/

        public ViewResult Index()
        {
            return View(_fachada.RecuperarClasses());
        }

        //
        // GET: /Classe/Details/5

        public ViewResult Details(int id)
        {
            return View(_fachada.RecuperarClassePorId(id));
        }

        //
        // GET: /Classe/Create

        public ViewResult Create()
        {
            return View();
        } 

        //
        // POST: /Classe/Create

        [HttpPost]
        public ActionResult Create(Classe classe)
        {
            if (ModelState.IsValid)
            {
                _fachada.AdicionarClasse(classe);
                return RedirectToAction("Details", new { id = classe.Id });
            }

            return View(classe);
        }
        
        //
        // GET: /Classe/Edit/5

        public ViewResult Edit(int id)
        {
            return View(_fachada.RecuperarClassePorId(id));
        }

        //
        // POST: /Classe/Edit/5

        [HttpPost]
        public ActionResult Edit(Classe classe)
        {
            if (ModelState.IsValid)
            {
                _fachada.SalvarClasse(classe);
                return RedirectToAction("Index");
            }
            return View(classe);
        }

        //
        // GET: /Classe/Delete/5

        public ViewResult Delete(int id)
        {
            return View(_fachada.RecuperarClassePorId(id));
        }

        //
        // POST: /Classe/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            _fachada.RemoverClasse(id);
            return RedirectToAction("Index");
        }
    }
}
