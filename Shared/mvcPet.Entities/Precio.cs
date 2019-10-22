using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mvcPet.Entities
{
    public partial class Pecio : IEntity
    {
        [DisplayName("Id TipoServicio")]
        public int Id { get; set; }

        [DisplayName("Fecha Desde")]
        public DateTime FechaDesde { get; set; }

        [DisplayName("Fecha Hasta")]
        public DateTime FechaHasta { get; set; }

        [DisplayName("Valor")]
        public int Valor { get; set; }

        [DisplayName("Id Precio")]
        public double IdPrecio { get; set; }        
        
    }
}