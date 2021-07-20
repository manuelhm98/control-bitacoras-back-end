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
    public class TipoFallaController : ApiController
    {
        private TipoFallaBL tipoFallaBL = new TipoFallaBL();

        //Instancia Guardar
        [HttpPost]
        [Route("api/tipofalla/guardar")]
        public int GuardarTipoFalla(TipoFalla tipoFalla)
        {
            return tipoFallaBL.GuardarTipoFalla(tipoFalla);
        }


        //Instancia Editar
        [HttpPut]
        [Route("api/tipofall/editar")]
        public int EditarTipoFalla(TipoFalla tipoFalla)
        {
            return tipoFallaBL.EditarTipoFalla(tipoFalla);
        }


        //Instancia Eliminar
        [HttpDelete] 
        [Route("api/tipofalla/eliminar/{id}")]
        public int EliminarTipoFalla(int id)
        {
            return tipoFallaBL.EliminarTipoFalla(id);
        }
    }
}
