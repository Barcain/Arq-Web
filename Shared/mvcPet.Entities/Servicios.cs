using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mvcPet.Entities
{
    public partial class Servicios : IEntity
    {

        [DisplayName("Id")]
        public int Id { get; set; }

        [DisplayName("Nombre")]
        public string Nombre { get; set; }

        [DisplayName("Id TipoServicio")]
        public int TipoServicioId { get; set; }

        [DisplayName("Fecha Desde")]
        public DateTime FechaDesde { get; set; }

        [DisplayName("Fecha Hasta")]
        public DateTime FechaHasta { get; set; }

        [DisplayName("Valor")]
        public decimal Valor { get; set; }

        [DisplayName("Id Precio")]
        public int IdPrecio { get; set; }
    }
}
