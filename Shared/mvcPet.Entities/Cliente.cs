using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mvcPet.Entities
{
    public partial class Cliente : IEntity
    {
        [DisplayName("Id")]
        public int Id { get; set; }

        [DisplayName("Apellido")]
        public string Apellido { get; set; }

        [DisplayName("Nombre")]
        public string Nombre { get; set; }

        [DisplayName("Email")]
        public string Email { get; set; }

        [DisplayName("Telefono")]
        public string Telefono { get; set; }

        [DisplayName("URL")]
        public string Url { get; set; }
        
        [DisplayName("Fecha Nacimiento")]
        public DateTime FechaNacimiento { get; set; }
        
        [DisplayName("Domicilio")]
        public string Domicilio { get; set; }
        
    }
}
