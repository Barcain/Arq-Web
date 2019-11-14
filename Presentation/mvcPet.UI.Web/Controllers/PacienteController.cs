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
    public class PacienteController : Controller
    {
        // GET: Paciente
        public ActionResult Index()
        {
            IPacienteService pacienteService = new PacienteService();
            var lista = pacienteService.ListarTodos();
            return View(lista);
        }

        // GET: Paciente/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Paciente/Create
        public ActionResult Create()
        {
            IEspecieService especieService = new EspecieService();
            IClienteService clienteService = new ClienteService();
            
            ViewBag.listaEsp = especieService.CrearListaEspecies();
            ViewBag.listaCli = clienteService.CrearListaClientes();

            return View();            
        }

        // POST: Paciente/Create
        [HttpPost]
        public ActionResult Create(Paciente model)
        {
            try
            {
                // TODO: Add insert logic here
                IPacienteService pacienteService = new PacienteService();
                pacienteService.Agregar(model);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Paciente/Edit/5
        public ActionResult Edit(int id)
        {           
            IPacienteService pacienteService = new PacienteService();
            var paciente = pacienteService.Find(id);
            
            IEspecieService especieService = new EspecieService();
            IClienteService clienteService = new ClienteService();
            
            //  Estas dos listas se mandan a la vista para elegir especie y cliente.           
            ViewBag.listaEsp = especieService.CrearListaEspecies();
            ViewBag.listaCli = clienteService.CrearListaClientes();
           
            return View(paciente);
        }

        // POST: Paciente/Edit/5
        [HttpPost]
        public ActionResult Edit(Paciente model)
        {
            try
            {
                // TODO: Add update logic here
                IPacienteService pacienteService = new PacienteService();
                pacienteService.Editar(model);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Paciente/Delete/5
        public ActionResult Delete(int id)
        {
            IPacienteService pacienteService = new PacienteService();
            var paciente = pacienteService.Find(id);
            return View(paciente);
        }

        // POST: Paciente/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Paciente model)
        {
            try
            {
                // TODO: Add insert logic here
                IPacienteService pacienteService = new PacienteService();
                pacienteService.Eliminar(model);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
