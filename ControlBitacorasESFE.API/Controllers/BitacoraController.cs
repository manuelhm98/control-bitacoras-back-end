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
    public class BitacoraController : ApiController
    {
        //Instancia de los metodos BL
        private BitacoraBL bitacoraBL = new BitacoraBL();


        //Instancia Guardar
        [HttpPost]
        [Route("api/bitacora/guardar")]
        public int GuardarBitacora(Bitacora bitacora)
        {
            return bitacoraBL.GuardarBitacora(bitacora);
        }

        //Instancia Editar
        [HttpPut]
        [Route("api/bitacora/editar")]
        public int EditarBitacora(Bitacora bitacora)
        {
            return bitacoraBL.EditarBitacora(bitacora);
        }


        //Instancia Eliminar 
        [HttpDelete]
        [Route("api/bitacora/eliminar/{id}")]
        public int EliminarBitacora(int id)
        {
            return bitacoraBL.EliminarBitacora(id);
        }
    }
}
