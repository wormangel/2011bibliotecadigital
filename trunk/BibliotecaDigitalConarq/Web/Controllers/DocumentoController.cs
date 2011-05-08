using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using Core.Gerenciadores;
using Core.Interfaces;
using Core.Objetos;

namespace Web.Controllers
{
    public class DocumentoController : Controller
    {
        private readonly GerenciadorDocumentos _servico;

        public DocumentoController(IRepositorio<Documento> repositorio)
        {
            _servico = new GerenciadorDocumentos(repositorio);
        }

        //
        // GET: /Documento/

        public ViewResult Index()
        {
            IList<Documento> documentos = _servico.RecuperarDocumentos();
            return View(documentos);
        }

        //
        // GET: /Documento/Details/5

        public ViewResult Details(long id)
        {
            return View(_servico.RecuperarPorId(id));
        }

        //
        // GET: /Documento/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Documento/Create

        [HttpPost]
        public ActionResult Create(Documento documento)
        {
            if (ModelState.IsValid)
            {
                _servico.Adicionar(documento);
                return RedirectToAction("Index");
            }

            return View(documento);
        }

        //
        // GET: /Documento/Editar/5

        public ActionResult Edit(long id)
        {
            return View(_servico.RecuperarPorId(id));
        }

        //
        // POST: /Documento/Editar/5

        [HttpPost]
        public ActionResult Edit(Documento documento)
        {
            if (ModelState.IsValid)
            {
                _servico.Salvar(documento);
                return RedirectToAction("Index");
            }
            return View(documento);
        }

        //
        // GET: /Documento/Delete/5

        public ActionResult Delete(long id)
        {
            return View(_servico.RecuperarPorId(id));
        }

        //
        // POST: /Documento/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(long id)
        {
            _servico.Remover(id);
            return RedirectToAction("Index");
        }

        //
        // GET: /Documento/Upload/5
        public ActionResult Upload(long idDocumento)
        {
            return View();
        }

        //
        // POST: /Documento/Upload/5
        [HttpPost]
        public ActionResult Upload(long idDocumento, HttpPostedFileBase arquivo)
        {
            if (arquivo.ContentLength > 0)
            {
                // TODO: this._servico.salvarArquivo(idDocumento, arquivo);
                return RedirectToAction("Details", new {id = idDocumento});
            }

            return View();
        }
    }
}