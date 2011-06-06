using System.Collections.Generic;
using System.Web.Mvc;
using Core.Gerenciadores;
using Core.Objetos;
using Ninject;
using Web.ViewModels.DocumentoArquivistico;

namespace Web.Controllers
{
    public class DocumentoArquivisticoController : Controller
    {
        [Inject]
        private readonly IFachadaGerenciadores _fachada;

        public DocumentoArquivisticoController(IFachadaGerenciadores fachada)
        {
            _fachada = fachada;
        }

        //
        // GET: /DocumentoArquivistico/

        public ViewResult Index()
        {
            return View(_fachada.RecuperarDocumentosArquivisticos());
        }

        //
        // GET: /DocumentoArquivistico/Details/5

        public ViewResult Details(long id)
        {
            return View(_fachada.RecuperarDocumentoArquivisticoPorId(id));
        }

        //
        // GET: /DocumentoArquivistico/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /DocumentoArquivistico/Create

        [HttpPost]
        public ActionResult Create(VersaoDocumentoArquivistico versaoSendoCriada)
        {
            if (ModelState.IsValid)
            {
                DocumentoArquivistico docArq = new DocumentoArquivistico();
                docArq.Versoes = new List<VersaoDocumentoArquivistico>();
                versaoSendoCriada.NumeroDaVersao = 1;
                docArq.Versoes.Add(versaoSendoCriada);

                _fachada.AdicionarDocumentoArquivistico(docArq);
                return RedirectToAction("Index");
            }

            return View(versaoSendoCriada);
        }

        //
        // GET: /DocumentoArquivistico/Editar/5

        public ActionResult Edit(long id)
        {
            // mesma coisa do details, ver se tem como reaproveitar algo (DRY!)
            DocumentoArquivistico docArq = _fachada.RecuperarDocumentoArquivisticoPorId(id);
            return View(new EditDocumentoArquivisticoViewModel(docArq));
        }

        //
        // POST: /DocumentoArquivistico/Editar/5

        [HttpPost]
        public ActionResult Edit(EditDocumentoArquivisticoViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                DocumentoArquivistico docArq = _fachada.RecuperarDocumentoArquivisticoPorId(viewModel.DocumentoArquivistico.Id);
                viewModel.VersaoNova.NumeroDaVersao = docArq.VersaoAtual.NumeroDaVersao + 1;

                docArq.Versoes.Add(viewModel.VersaoNova);

                _fachada.SalvarDocumentoArquivistico(docArq);
                return RedirectToAction("Index");
            }
            return View(viewModel);
        }

        //
        // GET: /DocumentoArquivistico/Delete/5

        public ActionResult Delete(long id)
        {
            // mesma coisa do details, ver se tem como reaproveitar algo (DRY!)
            return View(_fachada.RecuperarDocumentoArquivisticoPorId(id));
        }

        //
        // POST: /DocumentoArquivistico/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(long id)
        {
            _fachada.RemoverDocumentoArquivistico(id);
            return RedirectToAction("Index");
        }
    }
}