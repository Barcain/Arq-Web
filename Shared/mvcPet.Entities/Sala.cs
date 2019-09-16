using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mvcPet.Entities
{
    public partial class Sala : IEntity
    {
        [DisplayName("Id")]
        public int Id { get; set; }
        
        [DisplayName("Nombre")]
        public string Nombre { get; set; }

        [DisplayName("Tipo de Sala")]
        public string TipoSala { get; set; }
    }
}
