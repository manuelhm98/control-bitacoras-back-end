using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Referencias
using ControlBitacorasESFE.EL;
using ControlBitacorasESFE.DAL;

namespace ControlBitacorasESFE.BL
{
    public class RoleBL
    {
        //Intancia de clase DAL para acceder a sus metodos
        private RoleDAL RoleDAL = new RoleDAL();

       public List<Role> listaRoles()
        {
            return RoleDAL.listaRole();
        }

        //Metodo Guardar roles 
        public int Guardar(Role role)
        {
            return RoleDAL.Guardar(role);
        }
    }
}
