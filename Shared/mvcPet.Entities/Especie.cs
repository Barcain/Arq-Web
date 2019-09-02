using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;


namespace mvcPet.Entities
{
    public partial class Especie : IEntity
    {
        
        [DisplayName("Id")]
        public int Id { get; set; }

        
        [DisplayName("Nombre")]
        public string Nombre { get; set; }
    }
}
