using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mvcPet.Entities
{
    public partial class ListaTurnos : IEntity
    {
        [DisplayName("Id")]
        public int Id { get; set; }

        [DisplayName("Fecha")]
        public string Fecha { get; set; }

        [DisplayName("Hora")]
        public string Hora { get; set; }

        [DisplayName("MédicoId")]
        public int MedicoId { get; set; }

        [DisplayName("Médico")]
        public string NMedico { get; set; }

        [DisplayName("PacienteId")]
        public int PacienteId { get; set; }

        [DisplayName("Paciente")]
        public string NPaciente { get; set; }

        [DisplayName("SalaId")]
        public int SalaId { get; set; }

        [DisplayName("Sala")]
        public string NSala { get; set; }

        [DisplayName("Servicio")]
        public string NServicio { get; set; }

        [DisplayName("Estado")]
        public string Estado { get; set; }
    }


}
