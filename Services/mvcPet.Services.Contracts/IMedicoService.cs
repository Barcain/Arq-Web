using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ServiceModel;
using mvcPet.Entities;

namespace mvcPet.Services.Contracts
{
    [ServiceContract]
    public interface IMedicoService
    {
            [OperationContract]
            Medico Agregar(Medico model);

            [OperationContract]
            List<Medico> ListarTodos();

            [OperationContract]
            void Eliminar(Medico model);

            [OperationContract]
            void Editar(Medico model);

            [OperationContract]
            Medico Find(int id);
    }


}
