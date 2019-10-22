using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mvcPet.Entities
{
    public partial class Paciente : IEntity
    {
        [DisplayName("Id")]
        public int Id { get; set; }

        [DisplayName("Cliente Id")]
        public int ClienteId { get; set; }

        [DisplayName("Cliente")]
        public string Cliente { get; set; }

        [DisplayName("Paciente")]
        public string Nombre { get; set; }

        [DisplayName("Fecha Nacimiento")]
        public DateTime FechaNacimiento { get; set; }

        [DisplayName("Especie Id")]
        public int EspecieId { get; set; }

        [DisplayName("Especie")]
        public string ENombre { get; set; }

        [DisplayName("Observación")]
        public string Observacion { get; set; }

    }
}
