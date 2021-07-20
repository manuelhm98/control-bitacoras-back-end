using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlBitacorasESFE.EL
{
    public class Falla
    {
        public Int64 FallaID { get; set; }
        //Propiedad de relacion 
        public Int16 TipoFallaID { get; set; }
        [Required]
        public string Descripcion { get; set; }
        [Required]
        public int Estado { get; set; }

        //Propiedades de navegacion 
        public TipoFalla TipoFalla { get; set; }
    }
}
