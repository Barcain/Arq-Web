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
    public class EspecieService : IEspecieService
    {        
        public Especie Agregar(Especie especie)
        {
            var bc = new EspecieComponent();
            return bc.Agregar(especie);
        }
        
        public List<Especie> ListarTodos()
        {
            var bc = new EspecieComponent();
            return bc.ListarTodos();
        }

        public List<ListaEspecies> CrearListaEspecies()
        {
            var bc = new EspecieComponent();
            return bc.CrearListaEspecies();
        }

        public void Eliminar(Especie model)
        {
            var bc = new EspecieComponent();
            bc.Eliminar(model.Id);
        }

        public void Editar(Especie model) {
            var bc = new EspecieComponent();
            bc.Editar(model);
        }

        public Especie Find(int id)        {
            var bc = new EspecieComponent();
            return bc.FindBy(id);
        }
    }
}
