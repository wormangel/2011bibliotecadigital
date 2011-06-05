﻿using System;
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
    public class SubclasseController : Controller
    {
        [Inject]
        private readonly IFachadaGerenciadores _fachada;

        public SubclasseController(IFachadaGerenciadores fachada)
        {
            this._fachada = fachada;
        }
        
        //
        // GET: /Classe/

        public ViewResult Index()
        {
            return View(_fachada.RecuperarSubclasses());
        }

        //
        // GET: /Classe/Details/5

        public ViewResult Details(int id)
        {
            return View(_fachada.RecuperarSubclassePorId(id));
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
        public ActionResult Create(Subclasse subclasse)
        {
            if (ModelState.IsValid)
            {
                _fachada.AdicionarSubclasse(subclasse);
                return RedirectToAction("Index");
            }

            return View(subclasse);
        }
        
        //
        // GET: /Classe/Edit/5

        public ViewResult Edit(int id)
        {
            return View(_fachada.RecuperarSubclassePorId(id));
        }

        //
        // POST: /Classe/Edit/5

        [HttpPost]
        public ActionResult Edit(Subclasse subclasse)
        {
            if (ModelState.IsValid)
            {
                _fachada.SalvarSubclasse(subclasse);
                return RedirectToAction("Index");
            }
            return View(subclasse);
        }

        //
        // GET: /Classe/Delete/5

        public ViewResult Delete(int id)
        {
            return View(_fachada.RecuperarSubclassePorId(id));
        }

        //
        // POST: /Classe/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            _fachada.RemoverSubclasse(id);
            return RedirectToAction("Index");
        }
    }
}
