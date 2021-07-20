using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlBitacorasESFE.EL
{
    public class Bitacora
    {
        public Int64 BitacoraID { get; set; }
        //Propiedad de relacion 
        public Int64 PuestosTrabajoID { get; set; }
        //Propiedad de relacion
        public Int16 UsuarioID { get; set; }
        //Propiedad de relacion
        public Int64 FallaID { get; set; }
        [Required]
        [DisplayFormat(DataFormatString ="{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime FechaHora { get; set; }
        [Required]
        public string Comentario { get; set; }
        [Required]
        public int Estado { get; set; }

        //Propiedades de navegacion 
        public PuestosTrabajo PuestosTrabajo { get; set; }
        public Usuario Usuario { get; set; }
        public Falla Falla { get; set; }
    }
}
