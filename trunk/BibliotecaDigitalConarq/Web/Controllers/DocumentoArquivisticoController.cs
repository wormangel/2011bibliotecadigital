using System.Collections.Generic;
using System.Linq;
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

        public ViewResult Index()
        {
            return View(_fachada.RecuperarDocumentosArquivisticos());
        }

        public ViewResult Detalhes(long id)
        {
            return View(_fachada.RecuperarDocumentoArquivisticoPorId(id));
        }

        public ActionResult Criar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Criar(string classificacao, long idClassificacao, VersaoDocumentoArquivistico versaoSendoCriada)
        {
            if (ModelState.IsValid)
            {
                DocumentoArquivistico docArq = new DocumentoArquivistico();
                docArq.Versoes = new List<VersaoDocumentoArquivistico>();
                versaoSendoCriada.NumeroDaVersao = 1;
                docArq.Versoes.Add(versaoSendoCriada);

                _fachada.AdicionarDocumentoArquivistico(_fachada.RecuperarClassificacao(classificacao, idClassificacao), docArq);
                return RedirectToAction("Index");
            }

            return View(versaoSendoCriada);
        }

        public ActionResult Editar(long id)
        {
            // mesma coisa do details, ver se tem como reaproveitar algo (DRY!)
            DocumentoArquivistico docArq = _fachada.RecuperarDocumentoArquivisticoPorId(id);
            return View(new EditDocumentoArquivisticoViewModel(docArq));
        }

        [HttpPost]
        public ActionResult Editar(EditDocumentoArquivisticoViewModel viewModel)
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

        public ActionResult Remover(long id)
        {
            // mesma coisa do details, ver se tem como reaproveitar algo (DRY!)
            return View(_fachada.RecuperarDocumentoArquivisticoPorId(id));
        }

        [HttpPost, ActionName("Remover")]
        public ActionResult RemoverConfirmed(long id)
        {
            _fachada.RemoverDocumentoArquivistico(id);
            return RedirectToAction("Index");
        }

        public ActionResult Versao(long idDocArq, long? idVersao)
        {
            DocumentoArquivistico docArq = _fachada.RecuperarDocumentoArquivisticoPorId(idDocArq);

            if (idVersao != null)
            {
                VersaoDocumentoArquivistico versao = docArq.Versoes.Where(v => v.NumeroDaVersao == idVersao).FirstOrDefault();
                return View("DetalhesVersao", new DetalhesVersaoViewModel(docArq, versao));
            }

            return View(docArq);
        }
    }

    
}