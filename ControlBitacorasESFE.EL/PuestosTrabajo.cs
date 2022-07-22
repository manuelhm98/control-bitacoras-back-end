using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlBitacorasESFE.EL
{
    public class PuestosTrabajo
    {
        public Int64 PuestosTrabajoID { get; set; }
        //Propiedad de relacion
        public Int16 AreaID { get; set; }
        //Propiedad de relacion
        public Int16 MonitorID { get; set; }
        //Propiedad de relacion
        public Int16 UpsID { get; set; }
        //Propiedad de relacion
        public Int16 CpuID { get; set; }
        //Propiedad de relacion
        public Int16 MuebleID { get; set; }
        public string Codigo { get; set; }

        [Required]
        public bool Teclado { get; set; }
        [Required]
        public bool Mouse { get; set; }
        [Required]
        public int Estado { get; set; }

      

        //Propiedades de navegacion 
        public Area Area { get; set; }
        public Monitor Monitor { get; set; }
        public Ups Ups { get; set; }
        public Cpu Cpu { get; set; }
        public Mueble Mueble { get; set; }

    }
}
