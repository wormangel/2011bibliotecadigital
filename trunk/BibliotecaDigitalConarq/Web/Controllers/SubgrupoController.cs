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
    public class SubgrupoController : Controller
    {
        [Inject]
        private readonly IFachadaGerenciadores _fachada;

        public SubgrupoController(IFachadaGerenciadores fachada)
        {
            this._fachada = fachada;
        }
        
        //
        // GET: /Classe/

        public ViewResult Index()
        {
            return View(_fachada.RecuperarSubgrupos());
        }

        //
        // GET: /Classe/Details/5

        public ViewResult Details(int id)
        {
            return View(_fachada.RecuperarSubgrupoPorId(id));
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
        public ActionResult Create(Subgrupo subgrupo)
        {
            if (ModelState.IsValid)
            {
                _fachada.AdicionarSubgrupo(subgrupo);
                return RedirectToAction("Index");
            }

            return View(subgrupo);
        }
        
        //
        // GET: /Classe/Edit/5

        public ViewResult Edit(int id)
        {
            return View(_fachada.RecuperarSubgrupoPorId(id));
        }

        //
        // POST: /Classe/Edit/5

        [HttpPost]
        public ActionResult Edit(Subgrupo subgrupo)
        {
            if (ModelState.IsValid)
            {
                _fachada.SalvarSubgrupo(subgrupo);
                return RedirectToAction("Index");
            }
            return View(subgrupo);
        }

        //
        // GET: /Classe/Delete/5

        public ViewResult Delete(int id)
        {
            return View(_fachada.RecuperarSubgrupoPorId(id));
        }

        //
        // POST: /Classe/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            _fachada.RemoverSubgrupo(id);
            return RedirectToAction("Index");
        }
    }
}
