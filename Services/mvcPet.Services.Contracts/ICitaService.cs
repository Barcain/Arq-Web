using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ServiceModel;
using mvcPet.Entities;

namespace mvcPet.Services.Contracts
{
    [ServiceContract]
    public interface ICitaService
    {
            [OperationContract]
            Cita Agregar(Cita cita);

            [OperationContract]
            List<ListaTurnos> ListaTurnos(FechaTurno hoy);

            [OperationContract]
            void Eliminar(Cita model);

            [OperationContract]
            void Editar(Cita model);

            [OperationContract]
            Cita Find(int id);
    }


}
