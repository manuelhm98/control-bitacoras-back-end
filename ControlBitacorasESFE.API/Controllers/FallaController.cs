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
    public class FallaController : ApiController
    {
        private FallaBL fallaBL = new FallaBL();

        //Instancia Guardar
        [HttpPost]
        [Route("api/falla/guardar")]
        public int GuardarFalla(Falla falla)
        {
            return fallaBL.GuardarFalla(falla);
        }
    
        
        //Instancia Editar
        [HttpPut]
        [Route("api/falla/editar")]
        public int EditarFalla(Falla falla)
        {
            return fallaBL.EditarFalla(falla);
        }


        //Instancia Eliminar
        [HttpDelete]
        [Route("api/falla/eliminar/{id}")]
        public int EliminarFalla(int id)
        {
            return fallaBL.EliminarFalla(id);
        }
    }
}
