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
    public class MedicoController : Controller
    {
        // GET: Medico
        public ActionResult Index()
        {
            IMedicoService medicoService = new MedicoService();
            var lista = medicoService.ListarTodos();
            return View(lista);
        }

        // GET: Medico/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Medico/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Medico/Create
        [HttpPost]
        public ActionResult Create(Medico model)
        {
            try
            {
                // TODO: Add insert logic here
                IMedicoService medicoService = new MedicoService();
                medicoService.Agregar(model);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Medico/Edit/5
        public ActionResult Edit(int id)
        {
            IMedicoService medicoService = new MedicoService();
            var medico = medicoService.Find(id);
            return View(medico);
        }

        // POST: Medico/Edit/5
        [HttpPost]
        public ActionResult Edit(Medico model)
        {
            try
            {
                // TODO: Add update logic here
                IMedicoService medicoService = new MedicoService();
                medicoService.Editar(model);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Medico/Delete/5
        public ActionResult Delete(int id)
        {
            IMedicoService medicoService = new MedicoService();
            var medico = medicoService.Find(id);
            return View(medico);
        }

        // POST: Medico/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Medico model)
        {
            try
            {
                // TODO: Add insert logic here
                IMedicoService medicoService = new MedicoService();
                medicoService.Eliminar(model);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
