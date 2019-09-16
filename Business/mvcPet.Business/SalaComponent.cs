using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using mvcPet.Entities;
using mvcPet.Data;


namespace mvcPet.Business
{
    public partial class SalaComponent
    {
        public Sala Agregar(Sala sala)
        {
            Sala result = default(Sala);
            var salaDAC = new SalaDAC();
            result = salaDAC.Create(sala);
            return result;
        }
        public List<Sala> ListarTodos()
        {
            List<Sala> result = default(List<Sala>);
            var salaDAC = new SalaDAC();
            result = salaDAC.Read();
            return result;

        }

        public void Eliminar(int id)
        {
            var salaDAC = new SalaDAC();
            salaDAC.Delete(id);

        }

        public void Editar(Sala model)
        {

            var salaDAC = new SalaDAC();
            salaDAC.Update(model);

        }

        public Sala FindBy(int id)
        {
            var salaDAC = new SalaDAC();
            return salaDAC.ReadBy(id);

        }
    }
}
