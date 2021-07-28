using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Referencias
using ControlBitacorasESFE.EL;
using ControlBitacorasESFE.DAL;
using ControlBitacorasESFE.EL.Middlewares;

namespace ControlBitacorasESFE.BL
{
    public class RoleBL
    {
        //Intancia de clase DAL para acceder a sus metodos
        private RoleDAL RoleDAL = new RoleDAL();


        public List<Role> listaRol()
        {
            return RoleDAL.listaRol();
        }
        public ListPaginRol listaRoles(int page = 1, int pageSize = 5)
        {
            return RoleDAL.RoleLista(page, pageSize);
        }

        //Metodo Guardar roles 
        public int Guardar(Role role)
        {
            return RoleDAL.Guardar(role);
        }

        //EDITAR 
        public int EditarRole(Role role)
        {
            return RoleDAL.EditarRole(role);
        }
        
        //ELIMINAR
        public int EliminarRole(int id)
        {
            return RoleDAL.ElimiarRole(id);
        }

        //BY ID 
        public Role RoleId(int id)
        {
            return RoleDAL.buscarId(id);
        }
    }
}
