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

                    // TODO Abstrair tudo isso dentro da fachada (aqui vai ficar soh uma chamada AdicionaArquivo, e ele 
                    // TODO cuida de adicionar metadados, anexo, indexar, etc)
                    
                    // TODO ver como vai ficar o local de salvar mesmo (isso na verdade deveria ser gerenciado já lá dentro do gerenciador)
                    // Define o local do arquivo
                    string path = Path.Combine("C://temp/arquivos/", viewModel.Anexo.FileName);

                    viewModel.Arquivo.Formato = viewModel.Anexo.ContentType;
                    viewModel.Arquivo.CaminhoDoArquivo = path;
                    
                    // Adiciona os metadados
                    long idArquivo = _servico.Adicionar(viewModel.Arquivo);
   
                    // Adiciona o anexo
                    _servico.AdicionarAnexo(viewModel.Arquivo, viewModel.Anexo.InputStream);

                    // Indexa o arquivo
                    _servico.Indexar(idArquivo, path);
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