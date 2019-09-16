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
    public class ServiciosService : IServiciosService
    {
        public Servicios Agregar(Servicios servicio)
        {
            var bc = new ServiciosComponent();
            return bc.Agregar(servicio);
        }

        public List<Servicios> ListarTodos()
        {
            var bc = new ServiciosComponent();
            return bc.ListarTodos();
        }


        public void Eliminar(Servicios model)
        {
            var bc = new ServiciosComponent();
            bc.Eliminar(model.Id);
        }

        public void Editar(Servicios model)
        {
            var bc = new ServiciosComponent();
            bc.Editar(model);
        }

        public Servicios Find(int id)
        {
            var bc = new ServiciosComponent();
            return bc.FindBy(id);
        }
    }
}
