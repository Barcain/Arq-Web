using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;


namespace mvcPet.Entities
{
    public partial class FechaTurno : IEntity
    {
        [DisplayName("Id")]
        public int Id { get; set; }

        [DisplayName("Fecha de consulta")]
        public string FechaConsulta { get; set; }
       
    }
}
