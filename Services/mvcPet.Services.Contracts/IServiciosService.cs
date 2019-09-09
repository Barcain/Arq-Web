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
            void Eliminar(Servicios model);
            void Editar(Servicios model);


        }

    
}
