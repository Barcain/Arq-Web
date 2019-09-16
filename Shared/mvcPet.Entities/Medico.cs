using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mvcPet.Entities
{
    public partial class Medico : IEntity
    {
        [DisplayName("Id")]
        public int Id { get; set; }

        [DisplayName("Tipo Matrícula")]
        public string TipoMatricula { get; set; }

        [DisplayName("N° Matrícula")]
        public int NumeroMatricula { get; set; }

        [DisplayName("Apellido")]
        public string Apellido { get; set; }

        [DisplayName("Nombre")]
        public string Nombre { get; set; }

        [DisplayName("Especialidad")]
        public string Especialidad { get; set; }

        [DisplayName("Fecha Nacimiento")]
        public DateTime FechaNacimiento { get; set; }

        [DisplayName("Email")]
        public string Email { get; set; }

        [DisplayName("Teléfono")]
        public string Telefono { get; set; }
        
    }
}
