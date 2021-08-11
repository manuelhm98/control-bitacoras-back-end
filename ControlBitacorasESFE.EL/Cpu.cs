using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlBitacorasESFE.EL
{
    public class Cpu
    {
        public Int16 CpuID { get; set; }
        //Propiedad de relacion
        public Int16 ProcesadorID { get; set; }
        [Required]
        public string Codigo { get; set; }
        [Required]
        public string Ram { get; set; }
        [Required]
        public string Almacenamiento { get; set; }
        [Required]
        public int Estado { get; set; }
        
        //Propiedades de navegacion 
        public Procesador Procesador { get; set; }
    }
}
