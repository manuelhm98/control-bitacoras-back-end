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
    public class Monitor
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Int16 MonitorID { get; set; }
        [Required]
        public string Codigo { get; set; }
        [Required]
        public string Modelo { get; set; }
        [Required]
        public int Pulgadas { get; set; }
        [Required]
        public int Estado { get; set; }
    }
}
