using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ServiceModel;
using mvcPet.Entities;

namespace mvcPet.Services.Contracts
{
    [ServiceContract]
    public interface IPacienteService
    {
            [OperationContract]
            Paciente Agregar(Paciente paciente);

            [OperationContract]
            List<Paciente> ListarTodos();

            [OperationContract]
            void Eliminar(Paciente model);

            [OperationContract]
            void Editar(Paciente model);

            [OperationContract]
            Paciente Find(int id);

            [OperationContract]
            List<ListaPacientes> CrearListaPacientes();
    }


}
