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

        public ViewResult Index(int idClasse, int idSubclasse)
        {
            return View(_fachada.RecuperarGrupos());
        }

        public ViewResult Detalhes(int idClasse, int idSubclasse, int id)
        {
            return View(_fachada.RecuperarGrupoPorId(id));
        }

        public ViewResult Criar(int idClasse, int idSubclasse)
        {
            ViewBag.Subclasse = _fachada.RecuperarSubclassePorId(idSubclasse);
            return View();
        } 

        [HttpPost]
        public ActionResult Criar(int idClasse, int idSubclasse, Grupo grupo)
        {
            if (ModelState.IsValid)
            {
                _fachada.AdicionarGrupo(idClasse, idSubclasse, grupo);
                return RedirectToAction("Detalhes", new { idClasse = idClasse, idSubclasse = idSubclasse, id = grupo.Id });
            }

            return View(grupo);
        }

        public ViewResult Editar(int idClasse, int idSubclasse, int id)
        {
            return View(_fachada.RecuperarGrupoPorId(id));
        }

        [HttpPost]
        public ActionResult Editar(int idClasse, int idSubclasse, Grupo grupo)
        {
            if (ModelState.IsValid)
            {
                _fachada.SalvarGrupo(grupo);
                return RedirectToAction("Index");
            }
            return View(grupo);
        }

        public ViewResult Remover(int idClasse, int idSubclasse, int id)
        {
            return View(_fachada.RecuperarGrupoPorId(id));
        }

        [HttpPost, ActionName("Remover")]
        public ActionResult RemoverConfirmed(int idClasse, int idSubclasse, int id)
        {
            _fachada.RemoverGrupo(id);
            return RedirectToAction("Index");
        }
    }
}
