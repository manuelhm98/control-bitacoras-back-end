using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlBitacorasESFE.EL
{
    public class Area
    {
        
        public Int16 AreaID { get; set; }
        [Required]
        //Propiedad de relacion 
        public Int16 TipoAreaID { get; set; }
        [Required]
        //Propiedad de relacion 
        public Int16 UsuarioID { get; set; }
        [Required]
        public string NombreArea { get; set; }
        [Required]
        public int Estado { get; set; }

        //Propiedades de navegacion 
        public TipoArea TipoArea { get; set; }
        public Usuario Usuario { get; set; }
    }
}
