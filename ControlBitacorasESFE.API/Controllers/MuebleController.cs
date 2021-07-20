using ControlBitacorasESFE.BL;
using ControlBitacorasESFE.EL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ControlBitacorasESFE.API.Controllers
{
    public class MuebleController : ApiController
    {
        private MuebleBL muebleBL = new MuebleBL();

        //Instancia Guardar
        [HttpPost]
        [Route("api/mueble/guardar")]
        public int GuardarMueble(Mueble mueble)
        {
            return muebleBL.GuardarMueble(mueble);
        }

        //Instancia Editar
        [HttpPut] 
        [Route("api/mueble/editar")]
        public int EditarMueble(Mueble mueble)
        {
            return muebleBL.EditarMueble(mueble);
        }

        //Instancia ELiminar
        [HttpDelete]
        [Route("api/mueble/eliminar/{id}")]
        public int EliminarMueble(int id)
        {
            return muebleBL.EliminarMueble(id);
        }
    }
}
