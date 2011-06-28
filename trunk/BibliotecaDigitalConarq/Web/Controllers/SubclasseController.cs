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
    public class SubclasseController : Controller
    {
        [Inject]
        private readonly IFachadaGerenciadores _fachada;

        public SubclasseController(IFachadaGerenciadores fachada)
        {
            this._fachada = fachada;
        }

        public ViewResult Index(int idClasse)
        {
            return View(_fachada.RecuperarSubclasses());
        }

        public ViewResult Detalhes(int idClasse, int id)
        {
            return View(_fachada.RecuperarSubclassePorId(id));
        }

        public ViewResult Criar()
        {
            return View();
        } 

        [HttpPost]
        public ActionResult Criar(int idClasse, Subclasse subclasse)
        {
            if (ModelState.IsValid)
            {
                _fachada.AdicionarSubclasse(idClasse, subclasse);
                return RedirectToAction("Detalhes", new { idClasse = idClasse, id = subclasse.Id });
            }

            return View(subclasse);
        }

        public ViewResult Editar(int idClasse, int id)
        {
            return View(_fachada.RecuperarSubclassePorId(id));
        }

        [HttpPost]
        public ActionResult Editar(int idClasse, Subclasse subclasse)
        {
            if (ModelState.IsValid)
            {
                _fachada.SalvarSubclasse(subclasse);
                return RedirectToAction("Index");
            }
            return View(subclasse);
        }

        public ViewResult Remover(int idClasse, int id)
        {
            return View(_fachada.RecuperarSubclassePorId(id));
        }

        [HttpPost, ActionName("Remover")]
        public ActionResult RemoverConfirmed(int idClasse, int id)
        {
            _fachada.RemoverSubclasse(id);
            return RedirectToAction("Index");
        }
    }
}
