using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ServiceModel;
using mvcPet.Entities;

namespace mvcPet.Services.Contracts
{    
    [ServiceContract]
    public interface IEspecieService
    {
        [OperationContract]
        Especie Agregar(Especie especie);

        [OperationContract]
        List<Especie> ListarTodos();

        [OperationContract]
        List<ListaEspecies> CrearListaEspecies();

        [OperationContract]
        void Eliminar(Especie model);

        [OperationContract]
        void Editar(Especie model);

        [OperationContract]
        Especie Find(int id);


    }
}
