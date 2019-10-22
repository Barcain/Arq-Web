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
    public class MedicoService : IMedicoService
    {
        public Medico Agregar(Medico medico)
        {
            var bc = new MedicoComponent();            
            return bc.Agregar(medico);
        }

        public List<Medico> ListarTodos()
        {
            var bc = new MedicoComponent();
            return bc.ListarTodos();
        }


        public void Eliminar(Medico model)
        {
            var bc = new MedicoComponent();
            bc.Eliminar(model.Id);
        }

        public void Editar(Medico model)
        {
            var bc = new MedicoComponent();
            bc.Editar(model);
        }

        public Medico Find(int id)
        {
            var bc = new MedicoComponent();
            return bc.FindBy(id);
        }
    }
}
