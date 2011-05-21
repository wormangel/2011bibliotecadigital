using System.IO;
using System.Linq;
using System.Web.Mvc;
using Core.Gerenciadores;
using Core.Interfaces;
using Core.Objetos;
using EntityAcessoADados.Gerenciadores;
using Web.ViewModels.Arquivo;

namespace Web.Controllers
{
    public class ArquivoController : Controller
    {
        private readonly IGerenciadorArquivos _servico;

        public ArquivoController(IGerenciadorArquivos gerenciador)
        {
            _servico = gerenciador;
        }

        //
        // GET: /Arquivo/

        public ActionResult Index(long idDocArq, long idVol, long idDoc)
        {
            IQueryable<Arquivo> arquivos = _servico.RecuperarArquivos();
            return View(arquivos);
        }

        //
        // GET: /Arquivo/Details/5

        public ActionResult Details(long idDocArq, long idVol, long idDoc, int id)
        {
            return View(_servico.RecuperarPorId(id));
        }

        //
        // GET: /Arquivo/Create

        public ActionResult Create(long idDocArq, long idVol, long idDoc)
        {
            return View();
        }

        //
        // POST: /Arquivo/Create

        [HttpPost]
        public ActionResult Create(long idDocArq, long idVol, long idDoc, CreateArquivoViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                if (viewModel.Anexo.ContentLength > 0)
                {
                    // NOTE: Coloquei tudo dentro do gerenciador menos as linhas abaixo para o gerenciador não
                    // NOTE: precisar conhecer coisa de view/controller
                    viewModel.Arquivo.Formato = Path.GetExtension(viewModel.Anexo.FileName);
                    viewModel.Arquivo.Nome = Path.GetFileNameWithoutExtension(viewModel.Anexo.FileName);
                    _servico.Adicionar(viewModel.Arquivo, viewModel.Anexo.InputStream);
                }
                return RedirectToAction("Index");
            }
            return View(viewModel);
        }

        //
        // GET: /Arquivo/Edit/5

        public ActionResult Edit(long idDocArq, long idVol, long idDoc, int id)
        {
            return View(_servico.RecuperarPorId(id));
        }

        //
        // POST: /Arquivo/Edit/5

        [HttpPost]
        public ActionResult Edit(long idDocArq, long idVol, long idDoc, Arquivo arquivo)
        {
            if (ModelState.IsValid)
            {
                _servico.Salvar(arquivo);
                return RedirectToAction("Index");
            }
            return View(arquivo);
        }

        //
        // GET: /Arquivo/Delete/5

        public ActionResult Delete(long idDocArq, long idVol, long idDoc, int id)
        {
            return View(_servico.RecuperarPorId(id));
        }

        //
        // POST: /Arquivo/Delete/5

        [HttpPost]
        public ActionResult DeleteConfirmed(long idDocArq, long idVol, long idDoc, int id)
        {
            _servico.Remover(id);
            return RedirectToAction("Index");
        }
    }
}