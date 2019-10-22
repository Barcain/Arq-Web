using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using mvcPet.Entities;
using mvcPet.Data;


namespace mvcPet.Business
{
    public partial class CitaComponent
    {
        public Cita Agregar(Cita cita)
        {
            Cita result = default(Cita);
            var citaDAC = new CitaDAC();
            result = citaDAC.Create(cita);
            return result;
        }
        public List<ListaTurnos> ListaTurnos(FechaTurno today)
        {
            List<ListaTurnos> result = default(List<ListaTurnos>);
            var citaDAC = new CitaDAC();
            result = citaDAC.CreateList(today);
            return result;

        }

        public void Eliminar(int id)
        {
            var citaDAC = new CitaDAC();
            citaDAC.Delete(id);

        }

        public void Editar(Cita model)
        {

            var citaDAC = new CitaDAC();
            citaDAC.Update(model);

        }

        public Cita FindBy(int id)
        {
            var citaDAC = new CitaDAC();
            return citaDAC.ReadBy(id);

        }
    }
}
