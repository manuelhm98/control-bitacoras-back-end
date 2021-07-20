using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlBitacorasESFE.EL
{
    public class TipoFalla
    {
        public Int16 TipoFallaID { get; set; }
        [Required]
        [DisplayName("Tipo de falla")]
        public string Tipo { get; set; }
        [Required]
        public int Estado { get; set; }
    }
}
