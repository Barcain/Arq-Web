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
    public class SalaService : ISalaService
    {
        public Sala Agregar(Sala sala)
        {
            var bc = new SalaComponent();
            return bc.Agregar(sala);
        }

        public List<Sala> ListarTodos()
        {
            var bc = new SalaComponent();
            return bc.ListarTodos();
        }


        public void Eliminar(Sala model)
        {
            var bc = new SalaComponent();
            bc.Eliminar(model.Id);
        }

        public void Editar(Sala model)
        {
            var bc = new SalaComponent();
            bc.Editar(model);
        }

        public Sala Find(int id)
        {
            var bc = new SalaComponent();
            return bc.FindBy(id);
        }
    }
}
