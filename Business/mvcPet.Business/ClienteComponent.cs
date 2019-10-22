using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using mvcPet.Entities;
using mvcPet.Data;


namespace mvcPet.Business
{
    public partial class ClienteComponent
    {
        public Cliente Agregar(Cliente cliente)
        {
            Cliente result = default(Cliente);
            var clienteDAC = new ClienteDAC();
            result = clienteDAC.Create(cliente);
            return result;
        }

        public List<Cliente> ListarTodos()
        {
            List<Cliente> result = default(List<Cliente>);
            var clienteDAC = new ClienteDAC();
            result = clienteDAC.Read();
            return result;

        }

        public List<ListaClientes> CrearListaClientes()
        {
            List<ListaClientes> result = default(List<ListaClientes>);
            var clienteDAC = new ClienteDAC();
            result = clienteDAC.CreateListClient();
            return result;

        }

        public void Eliminar(int id)
        {
            var clienteDAC = new ClienteDAC();
            clienteDAC.Delete(id);

        }

        public void Editar(Cliente model)
        {

            var clienteDAC = new ClienteDAC();
            clienteDAC.Update(model);

        }

        public Cliente FindBy(int id)
        {
            var clienteDAC = new ClienteDAC();
            return clienteDAC.ReadBy(id);

        }
    }
}
