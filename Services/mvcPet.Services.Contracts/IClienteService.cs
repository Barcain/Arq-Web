using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ServiceModel;
using mvcPet.Entities;

namespace mvcPet.Services.Contracts
{
    [ServiceContract]
    public interface IClienteService
    {
            [OperationContract]
            Cliente Agregar(Cliente model);

            [OperationContract]
            List<Cliente> ListarTodos();

            [OperationContract]
            void Eliminar(Cliente model);

            [OperationContract]
            void Editar(Cliente model);

            [OperationContract]
            Cliente Find(int id);
    }


}
