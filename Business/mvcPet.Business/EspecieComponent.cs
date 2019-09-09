using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using mvcPet.Entities;
using mvcPet.Data;


namespace mvcPet.Business
{  
    public partial class EspecieComponent
    {        
        public Especie Agregar(Especie especie)
        {
            Especie result = default(Especie);
            var especieDAC = new EspecieDAC();
            result = especieDAC.Create(especie);
            return result;
        }
        public List<Especie> ListarTodos()
        {
            List<Especie> result = default(List<Especie>);
            var especieDAC = new EspecieDAC();
            result = especieDAC.Read();
            return result;

        }

        public void Eliminar(int id)
        {          
            var especieDAC = new EspecieDAC();
            especieDAC.Delete(id);
           
        }

        public void Editar(Especie model)
        {
           
            var especieDAC = new EspecieDAC();
            especieDAC.Update(model);
  
        }
    }
}
