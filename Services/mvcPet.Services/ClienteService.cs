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
    public class ClienteService : IClienteService
    {
        public Cliente Agregar(Cliente cliente)
        {
            var bc = new ClienteComponent();
            return bc.Agregar(cliente);
        }

        public List<Cliente> ListarTodos() 
        {
            var bc = new ClienteComponent();
            return bc.ListarTodos();
        }

        public List<ListaClientes> CrearListaClientes()
        {
            var bc = new ClienteComponent();
            return bc.CrearListaClientes();
        }

        public void Eliminar(Cliente model)
        {
            var bc = new ClienteComponent();
            bc.Eliminar(model.Id);
        }

        public void Editar(Cliente model)
        {
            var bc = new ClienteComponent();
            bc.Editar(model);
        }

        public Cliente Find(int id)
        {
            var bc = new ClienteComponent();
            return bc.FindBy(id);
        }
    }
}
