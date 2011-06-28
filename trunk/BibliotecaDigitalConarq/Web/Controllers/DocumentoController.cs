using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Core.Gerenciadores;
using Core.Objetos;
using EntityAcessoADados.Gerenciadores;
using Web.ViewModels.Documento;

namespace Web.Controllers
{
    public class DocumentoController : Controller
    {
        private readonly IFachadaGerenciadores _fachada;

        public DocumentoController(IFachadaGerenciadores fachada)
        {
            _fachada = fachada;
        }

        public ViewResult Index(long idDocArq, long idVol)
        {
            IQueryable<Documento> documentos = _fachada.RecuperarDocumentos();
            var volume = _fachada.RecuperarVolumePorId(idVol);
            ViewBag.TituloDocArq = volume.DocumentoArquivistico.VersaoAtual.Titulo;
            ViewBag.TipoDocArq = "processo/dossiê"; // TODO: criar enum!
            ViewBag.NrVolume = volume.VersaoAtual.NumeroDoVolume;
            ViewBag.IdVol = idVol;
            ViewBag.IdDocArq = idDocArq;
            return View(documentos);
        }

        public ViewResult Detalhes(long idDocArq, long idVol, long id)
        {
            return View(_fachada.RecuperarDocumentoPorId(id));
        }

        public ActionResult Criar(long idDocArq, long idVol)
        {
            return View();
        }

        [HttpPost]
        public ActionResult Criar(long idDocArq, long idVol, VersaoDocumento versaoSendoCriada)
        {
            if (ModelState.IsValid)
            {
                Documento documento = new Documento();
                documento.Versoes = new List<VersaoDocumento>();
                versaoSendoCriada.NumeroDaVersao = 1;
                documento.Versoes.Add(versaoSendoCriada);

                _fachada.AdicionarDocumento(idDocArq, idVol, documento);
                return RedirectToAction("Index");
            }

            return View(versaoSendoCriada);
        }

        public ActionResult Editar(long idDocArq, long idVol, long id)
        {
            Documento doc = _fachada.RecuperarDocumentoPorId(id);
            return View(new EditDocumentoViewModel(doc));
        }

        [HttpPost]
        public ActionResult Editar(long idDocArq, long idVol, EditDocumentoViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                Documento doc = _fachada.RecuperarDocumentoPorId(viewModel.Documento.Id);
                viewModel.VersaoNova.NumeroDaVersao = doc.VersaoAtual.NumeroDaVersao + 1;

                doc.Versoes.Add(viewModel.VersaoNova);

                _fachada.SalvarDocumento(doc);
                return RedirectToAction("Index");
            }
            return View(viewModel);
        }

        public ActionResult Remover(long idDocArq, long idVol, long id)
        {
            return View(_fachada.RecuperarDocumentoPorId(id));
        }

        [HttpPost, ActionName("Remover")]
        public ActionResult RemoverConfirmed(long idDocArq, long idVol, long id)
        {
            _fachada.RemoverDocumento(id);
            return RedirectToAction("Index");
        }

        public ActionResult Versao(long idDocumento, long? idVersao)
        {
            Documento documento = _fachada.RecuperarDocumentoPorId(idDocumento);

            if (idVersao != null)
            {
                VersaoDocumento versao = documento.Versoes.Where(v => v.NumeroDaVersao == idVersao).FirstOrDefault();
                return View("DetalhesVersao", new DetalhesVersaoViewModel(documento, versao));
            }

            return View(documento);
        }

    }
}