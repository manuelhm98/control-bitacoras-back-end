using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

//Referencias
using ControlBitacorasESFE.EL;
using ControlBitacorasESFE.BL;

namespace ControlBitacorasESFE.API.Controllers
{
    public class RoleController : ApiController
    {

        //Intancia de la clase BL
        private RoleBL roleBL = new RoleBL();

        // POST: api/Role
        public int Post([FromBody]Role role)
        {
            return roleBL.Guardar(role);
        }

        public List<Role> Get()

        {
            return roleBL.listaRoles();
        }
    }
}
