using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using mvcPet.Entities;
using mvcPet.Data;


namespace mvcPet.Business
{
    public partial class PacienteComponent
    {
        public Paciente Agregar(Paciente paciente)
        {
            Paciente result = default(Paciente);
            var pacienteDAC = new PacienteDAC();
            result = pacienteDAC.Create(paciente);
            return result;
        }
        public List<Paciente> ListarTodos()
        {
            List<Paciente> result = default(List<Paciente>);
            var pacienteDAC = new PacienteDAC();
            result = pacienteDAC.Read();
            return result;

        }

        public void Eliminar(int id)
        {
            var pacienteDAC = new PacienteDAC();
            pacienteDAC.Delete(id);

        }

        public void Editar(Paciente model)
        {

            var pacienteDAC = new PacienteDAC();
            pacienteDAC.Update(model);

        }

        public Paciente FindBy(int id)
        {
            var pacienteDAC = new PacienteDAC();
            return pacienteDAC.ReadBy(id);

        }
    }
}
