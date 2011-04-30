using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Core.Interfaces;
using Core.Objetos;
using Web.Models;

namespace Web.Controllers
{ 
    public class VolumeController : Controller
    {
        private GerenciadorVolumes servico;

        public VolumeController(IRepositorio<Volume> repositorio)
        {
            servico = new GerenciadorVolumes(repositorio);
        }

        //
        // GET: /Volume/

        public ViewResult Index()
        {
            IEnumerable<Volume> volumes = servico.RecuperarVolumes();
            return View(volumes);
        }

        //
        // GET: /Volume/Details/5

        public ViewResult Details(long id)
        {
            return View(servico.RecuperarPorId(id));
        }

        //
        // GET: /Volume/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Volume/Create

        [HttpPost]
        public ActionResult Create(Volume volume)
        {
            if (ModelState.IsValid)
            {
                servico.Salvar(volume);
                return RedirectToAction("Index");  
            }

            return View(volume);
        }
        
        //
        // GET: /Volume/Editar/5
 
        public ActionResult Edit(long id)
        {
            // mesma coisa do details, ver se tem como reaproveitar algo (DRY!)
            return View(servico.RecuperarPorId(id));
        }

        //
        // POST: /Volume/Editar/5

        [HttpPost]
        public ActionResult Edit(Volume volume)
        {
            if (ModelState.IsValid)
            {
                servico.Salvar(volume);
                return RedirectToAction("Index");
            }
            return View(volume);
        }

        //
        // GET: /Volume/Delete/5
 
        public ActionResult Delete(long id)
        {
            // mesma coisa do details, ver se tem como reaproveitar algo (DRY!)
            return View(servico.RecuperarPorId(id));
        }

        //
        // POST: /Volume/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(long id)
        {
            servico.Remover(id);
            return RedirectToAction("Index");
        }

    }
}