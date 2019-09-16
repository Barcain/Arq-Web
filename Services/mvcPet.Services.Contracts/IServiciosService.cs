using mvcPet.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace mvcPet.Services.Contracts
{
    [ServiceContract]
    public interface IServiciosService
    {       
           [OperationContract]
            Servicios Agregar(Servicios servicio);

            [OperationContract]
            List<Servicios> ListarTodos();

            [OperationContract]
            void Eliminar(Servicios model);

            [OperationContract]
            void Editar(Servicios model);

            [OperationContract]
            Servicios Find(int id);
    }


}
