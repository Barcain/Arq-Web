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
    public class CitaService : ICitaService
    {
        public Cita Agregar(Cita cita)
        {
            var bc = new CitaComponent();
            return bc.Agregar(cita);
        }

        public List<ListaTurnos> ListaTurnos(FechaTurno hoy)
        {
            var bc = new CitaComponent();
            return bc.ListaTurnos(hoy);
        }


        public void Eliminar(Cita model)
        {
            var bc = new CitaComponent();
            bc.Eliminar(model.Id); 
        }

        public void Editar(Cita model)
        {
            var bc = new CitaComponent();
            bc.Editar(model);
        }

        public Cita Find(int id)
        {
            var bc = new CitaComponent();
            return bc.FindBy(id);
        }
    }
}
