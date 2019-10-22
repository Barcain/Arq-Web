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
    [Authorize(Roles = "Admin")]
    public class ClienteController : Controller
    {
        // GET: Cliente
        public ActionResult Index()
        {
            IClienteService clienteService = new ClienteService();
            var lista = clienteService.ListarTodos();
            return View(lista);
        }

        // GET: Cliente/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Cliente/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Cliente/Create
        [HttpPost]
        public ActionResult Create(Cliente model)
        {
            try
            {
                // TODO: Add insert logic here
                IClienteService clienteService = new ClienteService();
                clienteService.Agregar(model);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Cliente/Edit/5
        public ActionResult Edit(int id)
        {
            IClienteService clienteService = new ClienteService();
            var cliente = clienteService.Find(id);
            return View(cliente);
        }

        // POST: Cliente/Edit/5
        [HttpPost]
        public ActionResult Edit(Cliente model)
        {
            try
            {
                // TODO: Add update logic here
                IClienteService clienteService = new ClienteService();
                clienteService.Editar(model);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Cliente/Delete/5
        public ActionResult Delete(int id)
        {
            IClienteService clienteService = new ClienteService();
            var cliente = clienteService.Find(id);
            return View(cliente);
        }

        // POST: Cliente/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Cliente model)
        {
            try
            {
                // TODO: Add insert logic here
                IClienteService clienteService = new ClienteService();
                clienteService.Eliminar(model);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
