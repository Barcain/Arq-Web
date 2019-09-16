using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ServiceModel;
using mvcPet.Entities;

namespace mvcPet.Services.Contracts
{
    [ServiceContract]
    public interface ISalaService
    {
            [OperationContract]
            Sala Agregar(Sala sala);

            [OperationContract]
            List<Sala> ListarTodos();

            [OperationContract]
            void Eliminar(Sala model);

            [OperationContract]
            void Editar(Sala model);

            [OperationContract]
            Sala Find(int id);
    }


}
