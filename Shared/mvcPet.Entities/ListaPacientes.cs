using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mvcPet.Entities
{
    public partial class ListaPacientes : IEntity
    {
        [DisplayName("Id")]
        public int Id { get; set; }

        [DisplayName("Nombre Paciente")]
        public string PNombre { get; set; }
    }
}
