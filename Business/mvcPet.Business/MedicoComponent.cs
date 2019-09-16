using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using mvcPet.Entities;
using mvcPet.Data;


namespace mvcPet.Business
{
    public partial class MedicoComponent
    {
        public Medico Agregar(Medico medico)
        {
            Medico result = default(Medico);
            var medicoDAC = new MedicoDAC();
            result = medicoDAC.Create(medico);
            return result;
        }

        public List<Medico> ListarTodos()
        {
            List<Medico> result = default(List<Medico>);
            var medicoDAC = new MedicoDAC();
            result = medicoDAC.Read();
            return result;

        }

        public void Eliminar(int id)
        {
            var medicoDAC = new MedicoDAC();
            medicoDAC.Delete(id);

        }

        public void Editar(Medico model)
        {

            var medicoDAC = new MedicoDAC();
            medicoDAC.Update(model);

        }

        public Medico FindBy(int id)
        {
            var medicoDAC = new MedicoDAC();
            return medicoDAC.ReadBy(id);

        }
    }
}
