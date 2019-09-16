using mvcPet.Entities;
using mvcPet.Services;
using mvcPet.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mvcPet.UI.Web.Controllers
{
    public class SalaController : Controller
    {
        // GET: Sala
        public ActionResult Index()
        {
            ISalaService salaService = new SalaService();
            var lista = salaService.ListarTodos();
            return View(lista);
        }

        // GET: Sala/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Sala/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Sala/Create
        [HttpPost]
        public ActionResult Create(Sala model)
        {
            try
            {
                // TODO: Add insert logic here
                ISalaService salaService = new SalaService();
                salaService.Agregar(model);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Sala/Edit/5
        public ActionResult Edit(int id)
        {
            ISalaService salaService = new SalaService();
            var sala = salaService.Find(id);
            return View(sala);
        }

        // POST: Sala/Edit/5
        [HttpPost]
        public ActionResult Edit(Sala model)
        {
            try
            {
                // TODO: Add update logic here
                ISalaService salaService = new SalaService();
                salaService.Editar(model);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Sala/Delete/5
        public ActionResult Delete(int id)
        {
            ISalaService salaService = new SalaService();
            var sala = salaService.Find(id);
            return View(sala);
        }

        // POST: Sala/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Sala model)
        {
            try
            {
                // TODO: Add insert logic here
                ISalaService salaService = new SalaService();
                salaService.Eliminar(model);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
