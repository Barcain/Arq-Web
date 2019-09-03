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
    public class EspecieController : Controller
    {
        // GET: Especie
        public ActionResult Index()
        {
            IEspecieService especieService = new EspecieService();
            var lista = especieService.ListarTodos();
            return View(lista);
        }

        // GET: Especie/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Especie/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Especie/Create
        [HttpPost]
        public ActionResult Create(Especie model)
        {
            try
            {
                // TODO: Add insert logic here
                IEspecieService especieService = new EspecieService();
                especieService.Agregar(model);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Especie/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Especie/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Especie/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Especie/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Especie model)
        {
            try
            {
                // TODO: Add insert logic here
                IEspecieService especieService = new EspecieService();
                especieService.Eliminar(model);
                return RedirectToAction("Index");          
            }
            catch
            {
                return View();
            }
        }
    }
}
