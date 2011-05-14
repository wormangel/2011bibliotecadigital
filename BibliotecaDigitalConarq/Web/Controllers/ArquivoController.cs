using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web.Mvc;
using Core.Gerenciadores;
using Core.Interfaces;
using Core.Objetos;
using Web.ViewModels.Arquivo;

namespace Web.Controllers
{
    public class ArquivoController : Controller
    {
        private readonly GerenciadorArquivos _servico;

        public ArquivoController(IRepositorio<Arquivo> repositorio)
        {
            _servico = new GerenciadorArquivos(repositorio);
        }

        //
        // GET: /Arquivo/

        public ActionResult Index()
        {
            IQueryable<Arquivo> arquivos = _servico.RecuperarArquivos();
            return View(arquivos);
        }

        //
        // GET: /Arquivo/Details/5

        public ActionResult Details(int id)
        {
            return View(_servico.RecuperarPorId(id));
        }

        //
        // GET: /Arquivo/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Arquivo/Create

        [HttpPost]
        public ActionResult Create(CreateArquivoViewModel viewModel)
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

        public ActionResult Edit(int id)
        {
            return View(_servico.RecuperarPorId(id));
        }

        //
        // POST: /Arquivo/Edit/5

        [HttpPost]
        public ActionResult Edit(Arquivo arquivo)
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

        public ActionResult Delete(int id)
        {
            return View(_servico.RecuperarPorId(id));
        }

        //
        // POST: /Arquivo/Delete/5

        [HttpPost]
        public ActionResult DeleteConfirmed(int id)
        {
            _servico.Remover(id);
            return RedirectToAction("Index");
        }
    }
}