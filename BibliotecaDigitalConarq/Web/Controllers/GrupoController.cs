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
    public class GrupoController : Controller
    {
        [Inject]
        private readonly IFachadaGerenciadores _fachada;

        public GrupoController(IFachadaGerenciadores fachada)
        {
            this._fachada = fachada;
        }
        
        //
        // GET: /Classe/

        public ViewResult Index()
        {
            return View(_fachada.RecuperarGrupos());
        }

        //
        // GET: /Classe/Details/5

        public ViewResult Details(int id)
        {
            return View(_fachada.RecuperarGrupoPorId(id));
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
        public ActionResult Create(Grupo grupo)
        {
            if (ModelState.IsValid)
            {
                _fachada.AdicionarGrupo(grupo);
                return RedirectToAction("Index");
            }

            return View(grupo);
        }
        
        //
        // GET: /Classe/Edit/5

        public ViewResult Edit(int id)
        {
            return View(_fachada.RecuperarGrupoPorId(id));
        }

        //
        // POST: /Classe/Edit/5

        [HttpPost]
        public ActionResult Edit(Grupo grupo)
        {
            if (ModelState.IsValid)
            {
                _fachada.SalvarGrupo(grupo);
                return RedirectToAction("Index");
            }
            return View(grupo);
        }

        //
        // GET: /Classe/Delete/5

        public ViewResult Delete(int id)
        {
            return View(_fachada.RecuperarGrupoPorId(id));
        }

        //
        // POST: /Classe/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            _fachada.RemoverGrupo(id);
            return RedirectToAction("Index");
        }
    }
}
