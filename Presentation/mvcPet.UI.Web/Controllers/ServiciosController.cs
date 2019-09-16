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
    public class ServiciosController : Controller
    {
        // GET: Servicios
        public ActionResult Index()
        {
            IServiciosService serviciosService = new ServiciosService();
            var lista = serviciosService.ListarTodos();
            return View(lista);
        }

        // GET: Servicios/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Servicios/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Servicios/Create
        [HttpPost]
        public ActionResult Create(Servicios model)
        {
            try
            {
                // TODO: Add insert logic here
                IServiciosService serviciosService = new ServiciosService();
                serviciosService.Agregar(model);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Servicios/Edit/5
        public ActionResult Edit(int id)
        {
            IServiciosService servicioService = new ServiciosService();
            var servicio = servicioService.Find(id);
            return View(servicio);
        }

        // POST: Servicios/Edit/5
        [HttpPost]
        public ActionResult Edit(Servicios model)
        {
            try
            {
                // TODO: Add update logic here
                IServiciosService servicioService = new ServiciosService();
                servicioService.Editar(model);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Servicios/Delete/5
        public ActionResult Delete(int id)
        {
            IServiciosService servicioService = new ServiciosService();
            var servicio = servicioService.Find(id);
            return View(servicio);
        }

        // POST: Servicios/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Servicios model)
        {
            try
            {
                // TODO: Add insert logic here
                IServiciosService servicioService = new ServiciosService();
                servicioService.Eliminar(model);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
