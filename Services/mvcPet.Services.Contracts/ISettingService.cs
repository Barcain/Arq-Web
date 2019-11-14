using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ServiceModel;
using mvcPet.Entities;

namespace MVParcial.Services.Contracts
{
    [ServiceContract]
    public interface ISettingService
    {
            [OperationContract]
            Setting Add(Setting setting);

            [OperationContract]
            List<Setting> ListarTodos();
                    
    }


}
