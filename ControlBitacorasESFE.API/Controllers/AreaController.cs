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
    public class AreaController : ApiController
    {
        //Instancia de los metodos BL
        private AreaBL areaBL = new AreaBL();


        //Instancia Guardar
        [HttpPost]
        [Route("api/area/guardar")]
        public int GuardarArea(Area area)
        {
            return areaBL.GuardarArea(area);
        }

        //Instancia Editar
        [HttpPut]
        [Route("api/area/editar")]
        public int EditarArea(Area area)
        {
            return areaBL.EditarArea(area);
        }

        //Instancia Eliminar 
        [HttpDelete]
        [Route("api/area/eliminar/{id}")]
        public int EliminarArea(int id)
        {
            return areaBL.EliminarAre(id);
        }
    }
}
