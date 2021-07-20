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
   public class TipoArea
    {
        public Int16 TipoAreaID { get; set; }
        [DisplayName("Tipo de area")]
        [Required]
        public string Tipo { get; set; }
        [Required]
        public int Estado { get; set; }
    }
}
