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

        public ViewResult Detalhes(int id)
        {
            return View(_fachada.RecuperarClassePorId(id));
        }

        //
        // GET: /Classe/Create

        public ViewResult Criar()
        {
            return View();
        } 

        //
        // POST: /Classe/Create

        [HttpPost]
        public ActionResult Criar(Classe classe)
        {
            if (ModelState.IsValid)
            {
                _fachada.AdicionarClasse(classe);
                return RedirectToAction("Detalhes", new { id = classe.Id });
            }

            return View(classe);
        }
        
        //
        // GET: /Classe/Edit/5

        public ViewResult Editar(int id)
        {
            return View(_fachada.RecuperarClassePorId(id));
        }

        //
        // POST: /Classe/Edit/5

        [HttpPost]
        public ActionResult Editar(Classe classe)
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

        public ViewResult Remover(int id)
        {
            return View(_fachada.RecuperarClassePorId(id));
        }

        //
        // POST: /Classe/Delete/5

        [HttpPost, ActionName("Remover")]
        public ActionResult RemoverConfirmed(int id)
        {
            _fachada.RemoverClasse(id);
            return RedirectToAction("Index");
        }
    }
}
