using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Core.Gerenciadores;
using Core.Objetos;
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
        //
        // GET: /Temporalidade/

        public ActionResult Index()
        {
            return View(_fachada.RecuperarTemporalidades());
        }

        public ActionResult Detalhes(long id)
        {
            return View(_fachada.RecuperarTemporalidadePorId(id));
        }

        public ActionResult Criar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Criar(Temporalidade temporalidade)
        {
            if (ModelState.IsValid)
            {
                _fachada.AdicionarTemporalidade(temporalidade);
                return RedirectToAction("Index");
            }

            return View(temporalidade);
        }

        public ActionResult Remover(long id)
        {
            return View(_fachada.RecuperarTemporalidadePorId(id));
        }

        [HttpPost, ActionName("Remover")]
        public ActionResult RemoverConfirmed(long id)
        {
            _fachada.RemoverTemporalidade(id);
            return RedirectToAction("Index");
        }

        public ActionResult Editar(long id)
        {
            Temporalidade temporalidade = _fachada.RecuperarTemporalidadePorId(id);
            return View(temporalidade);
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
