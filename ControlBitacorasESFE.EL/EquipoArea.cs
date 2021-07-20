using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace ControlBitacorasESFE.EL
{
    public class EquipoArea
    {
        public Int64 EquipoAreaID { get; set; }
        //Propiedad de relacion
        public Int16 AreaID { get; set; }
        [Required]
        public string Equipo { get; set; }
        [Required]
        public string Codigo { get; set; }
        [Required]
        public int Estado { get; set; }

        //Propiedades de navegacion 
        public Area Area { get; set; }
    }
}
