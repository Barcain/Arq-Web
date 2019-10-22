using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mvcPet.Entities
{
    public partial class ListaEspecies : IEntity
    {
        [DisplayName("Id")]
        public int Id { get; set; }

        [DisplayName("Nombre Especie")]
        public string ENombre { get; set; }
    }
}
