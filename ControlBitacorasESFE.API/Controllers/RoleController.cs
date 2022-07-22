using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

//Referencias
using ControlBitacorasESFE.EL;
using ControlBitacorasESFE.BL;
using ControlBitacorasESFE.EL.Middlewares;

namespace ControlBitacorasESFE.API.Controllers
{
    [Authorize]
    public class RoleController : ApiController
    {

        //Intancia de la clase BL
        private RoleBL roleBL = new RoleBL();

        // POST: api/Role
        [HttpPost]
        [Route("api/rol")]
        public int guardarRol([FromBody]Role role)
        {
            return roleBL.Guardar(role);
        }

        //EDITAR
        [HttpPut]
        [Route("api/rol")]
        public int editarRol(Role role)
        {
            return roleBL.EditarRole(role);
        }

        //LISTA
        [HttpGet]
        [Route("api/rol/lista")]
        public ListPaginRol roleLista(int page = 1, int pageSize = 5, string rol = "")
        {
            return roleBL.listaRoles(page, pageSize, rol);
        }
       
        //list
        [HttpGet]
        [Route("api/rol")]
        public List<Role> listaRole()
        {
            return roleBL.listaRol();
        }
        //ELIMINAR
        [HttpDelete]
        [Route("api/rol/{id}")]
        public int eliminarRol(int id)
        {
            return roleBL.EliminarRole(id);
        }


        //BY ID 
        [HttpGet]
        [Route("api/rol/{id}")]
        public Role roleId(int id) 
        {
            return roleBL.RoleId(id);
        }

    }
}
