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
    public class UpsController : ApiController
    {
        private UpsBL upsBL = new UpsBL();


        //Instancia Guardar
        [HttpPost]
        [Route("api/ups/guardar")]
        public int GuardarUps(Ups ups)
        {
            return upsBL.GuardarUps(ups);
        }


        //Instancia Editar
        [HttpPut]
        [Route("api/ups/editar")]
        public int EditarUps(Ups ups)
        {
            return upsBL.EditarUps(ups);
        }


        //Instancia Eliminar
        [HttpDelete]
        [Route("api/ups/eliminar/{id}")]
        public int EliminarUps(int id)
        {
            return upsBL.EliminarUps(id);
        }
    }
}
