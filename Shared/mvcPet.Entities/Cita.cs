using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mvcPet.Entities
{
    public partial class Cita : IEntity
    {
        [DisplayName("Id")]
        public int Id { get; set; }

        [DisplayName("Fecha")]
        public DateTime Fecha { get; set; }

        [DisplayName("Médico")]
        public int MedicoId { get; set; }

        [DisplayName("PacienteId")]
        public int PacienteId { get; set; }

        [DisplayName("Sala")]
        public int SalaId { get; set; }

        [DisplayName("Servicio")]
        public int TipoServicioId { get; set; }

        [DisplayName("Estado")]
        public string Estado { get; set; }

        [DisplayName("Creador")]
        public string CreatedBy { get; set; }

        [DisplayName("F. Creación")]
        public DateTime CreatedDate { get; set; }

        [DisplayName("Cambiador")]
        public int ChangedBy { get; set; }

        [DisplayName("F. Cambio")]
        public DateTime ChangedDate { get; set; }

        [DisplayName("Borrador")]
        public int DeletedBy { get; set; }

        [DisplayName("F. Borrador")]
        public DateTime DeletedDate { get; set; }

        [DisplayName("Borrado")]
        public Boolean Deleted { get; set; }
        
    }
}