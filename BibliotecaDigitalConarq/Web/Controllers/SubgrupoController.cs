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

        public ViewResult Index(int idClasse, int idSubclasse, int idGrupo)
        {
            return View(_fachada.RecuperarSubgrupos());
        }

        public ViewResult Detalhes(int idClasse, int idSubclasse, int idGrupo, int id)
        {
            return View(_fachada.RecuperarSubgrupoPorId(id));
        }

        public ViewResult Criar(int idClasse, int idSubclasse, int idGrupo)
        {
            return View();
        } 

        [HttpPost]
        public ActionResult Criar(int idClasse, int idSubclasse, int idGrupo, Subgrupo subgrupo)
        {
            if (ModelState.IsValid)
            {
                _fachada.AdicionarSubgrupo(idClasse, idSubclasse, idGrupo, subgrupo);
                return RedirectToAction("Detalhes", new { idClasse = idClasse, idSubclasse = idSubclasse, idGrupo = idGrupo, id = subgrupo.Id });
            }

            return View(subgrupo);
        }

        public ViewResult Editar(int idClasse, int idSubclasse, int idGrupo, int id)
        {
            return View(_fachada.RecuperarSubgrupoPorId(id));
        }

        [HttpPost]
        public ActionResult Editar(int idClasse, int idSubclasse, int idGrupo, Subgrupo subgrupo)
        {
            if (ModelState.IsValid)
            {
                _fachada.SalvarSubgrupo(subgrupo);
                return RedirectToAction("Index");
            }
            return View(subgrupo);
        }

        public ViewResult Remover(int idClasse, int idSubclasse, int idGrupo, int id)
        {
            return View(_fachada.RecuperarSubgrupoPorId(id));
        }

        [HttpPost, ActionName("Remover")]
        public ActionResult RemoverConfirmed(int idClasse, int idSubclasse, int idGrupo, int id)
        {
            _fachada.RemoverSubgrupo(id);
            return RedirectToAction("Index");
        }
    }
}
