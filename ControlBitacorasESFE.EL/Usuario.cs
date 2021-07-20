using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlBitacorasESFE.EL
{
    public class Usuario
    {
        public Int16 UsuarioID { get; set; }
        //Propiedad de reLACION
        public Int16 RoleID { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string Apellido { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Pass { get; set; }
        [Required]
        public int Estado { get; set; }

        //Propiedades de navegacion 
        public Role Role { get; set; }
    }
}
