using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlBitacorasESFE.EL.Login
{
    public class UserData
    {
        public Int16 Id { get; set; }
        public Int16 RoleID { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Email { get; set; }
        public string Pass { get; set; }
        public int Estado { get; set; }
        public string Token { get; set; }

        //Propiedades de navegacion 
        public string  Roles { get; set; }
    }
}
