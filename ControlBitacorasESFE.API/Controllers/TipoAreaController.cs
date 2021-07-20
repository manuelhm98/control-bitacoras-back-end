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
    public class TipoAreaController : ApiController
    {
        private TipoAreaBL tipoAreaBL = new TipoAreaBL();

        //Instancia Guardar
        [HttpPost]
        [Route("api/tipoarea/guardar")]
        public int GuardarTipoArea(TipoArea tipoArea)
        {
            return tipoAreaBL.GuardarTipoArea(tipoArea);
        }


        //Instancia Editar
        [HttpPut]
        [Route("api/tipoarea/editar")]
        public int EditarTipoArea(TipoArea tipoArea)
        {
            return tipoAreaBL.EditarTipoArea(tipoArea);
        }


        //Instancia Eliminar
        [HttpDelete]
        [Route("api/tipoarea/eliminar/{id}")]
        public int EliminarTipoArea(int id)
        {
            return tipoAreaBL.EliminarTipoArea(id);
        }
    }
}
