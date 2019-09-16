using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using mvcPet.Entities;
using mvcPet.Data;


namespace mvcPet.Business
{
    public partial class ServiciosComponent
    {
        public Servicios Agregar(Servicios servicio)
        {
            Servicios result = default(Servicios);
            var serviciosDAC = new ServiciosDAC();
            result = serviciosDAC.Create(servicio);
            return result;
        }
        public List<Servicios> ListarTodos()
        {
            List<Servicios> result = default(List<Servicios>);
            var serviciosDAC = new ServiciosDAC();
            result = serviciosDAC.Read();
            return result;

        }

        public void Eliminar(int id)
        {
            var serviciosDAC = new ServiciosDAC();
            serviciosDAC.Delete(id);

        }

        public void Editar(Servicios model)
        {

            var serviciosDAC = new ServiciosDAC();
            serviciosDAC.Update(model);

        }

        public Servicios FindBy(int id)
        {
            var servicioDAC = new ServiciosDAC();
            return servicioDAC.ReadBy(id);

        }
    }
}
