using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ServiceModel;

namespace Libreria.Contracts
{
    [ServiceContract]
    public interface ILibroService
    {
            [OperationContract]
            Libro Agregar(Libro model);

            [OperationContract]
            List<Libro> ListarTodos();
                   
            [OperationContract]
            void Eliminar(Libro model);

            [OperationContract]
            void Editar(Libro model);

            [OperationContract]
            Libro Find(int id);
    }


}
