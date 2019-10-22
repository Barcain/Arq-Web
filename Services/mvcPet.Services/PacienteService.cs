using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ServiceModel;
using mvcPet.Business;
using mvcPet.Entities;
using mvcPet.Services.Contracts;

namespace mvcPet.Services
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall, ConcurrencyMode = ConcurrencyMode.Multiple)]
    public class PacienteService : IPacienteService
    {
        public Paciente Agregar(Paciente paciente)
        {
            var bc = new PacienteComponent();
            return bc.Agregar(paciente);
        }

        public List<Paciente> ListarTodos()
        {
            var bc = new PacienteComponent();
            return bc.ListarTodos();
        }


        public void Eliminar(Paciente model)
        {
            var bc = new PacienteComponent();
            bc.Eliminar(model.Id);
        }

        public void Editar(Paciente model)
        {
            var bc = new PacienteComponent();
            bc.Editar(model);
        }

        public Paciente Find(int id)
        {
            var bc = new PacienteComponent();
            return bc.FindBy(id);
        }

        public List<ListaPacientes> CrearListaPacientes()
        {
            var bc = new PacienteComponent();
            return bc.CrearListaPacientes();
        }
    }
}
