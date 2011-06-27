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

        //
        // GET: /DocumentoArquivistico/1/Volume/1/Documento/

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

        //
        // GET: /DocumentoArquivistico/1/Volume/1/Documento/Details/5

        public ViewResult Details(long idDocArq, long idVol, long id)
        {
            return View(_fachada.RecuperarDocumentoPorId(id));
        }

        //
        // GET: /DocumentoArquivistico/1/Volume/1/Documento/Create

        public ActionResult Create(long idDocArq, long idVol)
        {
            return View();
        }

        //
        // POST: /DocumentoArquivistico/1/Volume/1/Documento/Create

        [HttpPost]
        public ActionResult Create(long idDocArq, long idVol, VersaoDocumento versaoSendoCriada)
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

        //
        // GET: /DocumentoArquivistico/1/Volume/1/Documento/Editar/5

        public ActionResult Edit(long idDocArq, long idVol, long id)
        {
            Documento doc = _fachada.RecuperarDocumentoPorId(id);
            return View(new EditDocumentoViewModel(doc));
        }

        //
        // POST: /DocumentoArquivistico/1/Volume/1/Documento/Editar/5

        [HttpPost]
        public ActionResult Edit(long idDocArq, long idVol, EditDocumentoViewModel viewModel)
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

        //
        // GET: /DocumentoArquivistico/1/Volume/1/Documento/Delete/5

        public ActionResult Delete(long idDocArq, long idVol, long id)
        {
            return View(_fachada.RecuperarDocumentoPorId(id));
        }

        //
        // POST: /DocumentoArquivistico/1/Volume/1/Documento/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(long idDocArq, long idVol, long id)
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