using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Core.Gerenciadores;
using Core.Objetos;
using Core.Objetos.Classificacoes;
using Ninject;

namespace Web.Controllers
{
    public class TemporalidadeController : Controller
    {

        [Inject]
        private readonly IFachadaGerenciadores _fachada;

        public TemporalidadeController(IFachadaGerenciadores fachada)
        {
            _fachada = fachada;
        }

        public ActionResult Index()
        {
            IQueryable<Classe> classes = _fachada.RecuperarClasses();

            return View(classes);
        }

        public ActionResult Detalhes(long idClasse)
        {
            return View(_fachada.RecuperarClassePorId(idClasse));
        }

        public ActionResult Criar(long idClasse)
        {
            Classe classe = _fachada.RecuperarClassePorId(idClasse);
            ViewBag.NomeDaClasse = classe.Nome;
            return View();
        }

        [HttpPost]
        public ActionResult Criar(long idClasse, Temporalidade temporalidade)
        {
            if (ModelState.IsValid)
            {
                Classe classe = _fachada.RecuperarClassePorId(idClasse);
                classe.Temporalidade = temporalidade;

                _fachada.SalvarClasse(classe);
                return RedirectToAction("Index");
            }

            return View(idClasse);
        }

        public ActionResult Remover(long idClasse)
        {
            return View(_fachada.RecuperarClassePorId(idClasse));
        }

        [HttpPost, ActionName("Remover")]
        public ActionResult RemoverConfirmed(long idClasse)
        {
            Classe classe = _fachada.RecuperarClassePorId(idClasse);
            classe.Temporalidade = null;
            _fachada.SalvarClasse(classe);
            _fachada.RemoverTemporalidade(idClasse);
            return RedirectToAction("Index");
        }

        public ActionResult Editar(long idClasse)
        {
            Classe classe = _fachada.RecuperarClassePorId(idClasse);
            return View(classe.Temporalidade);
        }

        [HttpPost]
        public ActionResult Editar(Temporalidade temporalidade)
        {
            if (ModelState.IsValid)
            {
                _fachada.SalvarTemporalidade(temporalidade);
                return RedirectToAction("Index");
            }
            return View(temporalidade);
        }

    }
}
