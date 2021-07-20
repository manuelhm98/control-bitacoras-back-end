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
    public class Mueble
    {
        public Int16 MuebleID { get; set; }
        [Required]
        public string Codigo { get; set; }
        [Required]
        public int Estado { get; set; }
    }
}
