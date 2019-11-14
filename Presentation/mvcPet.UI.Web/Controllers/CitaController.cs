/******************************************************************************************************************
 * 23/10/2019 - Darío Rodríguez: Para no tener que instalar TypeScript, está comentado en mvcPet.IU.Web.csproj el *
 * <ItemGroup> que corresponde a los <TypeScriptCompile> de todos los archivos .ts                                *                                            *
 * ****************************************************************************************************************/

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
    public class CitaController : Controller
    {
        // GET: Cita
        public ActionResult Index()
        {
            //  Mando al Datepicker la fecha de hoy.
            FechaTurno hoy = new FechaTurno();
            hoy.FechaConsulta = DateTime.Now.Date.ToString("yyyy-MM-dd");
            return View(hoy);

        }

        // POST: Cita
        [HttpPost]
        public ActionResult Index(FechaTurno fecha)
        {
           //  Mando a la vista las citas de la fecha seleccionada. NOTA: la tabla de citas no tiene campo para los horarios. 
           ICitaService citaService = new CitaService();
           var listaTurnos = citaService.ListaTurnos(fecha);
           ViewBag.fech = fecha.FechaConsulta;
           return View("ListaTurnos", listaTurnos);

        }
               
        // GET: Cita/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Cita/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Cita/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Cita/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Cita/Edit/5
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

        // GET: Cita/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Cita/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
