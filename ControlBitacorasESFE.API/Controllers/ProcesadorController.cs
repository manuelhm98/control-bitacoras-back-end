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
    public class ProcesadorController : ApiController
    {
        private ProcesadorBL procesadorBL = new ProcesadorBL();

        //Intancia Guardar
        [HttpPost]
        [Route("api/procesador/guardar")]
        public int GuardarProcesador(Procesador procesador)
        {
            return procesadorBL.GuardarProcesador(procesador);
        }


        //Instancia Editar 
        [HttpPut]
        [Route("api/procesador/editar")]
        public int EditarProcesador(Procesador procesador)
        {
            return procesadorBL.EditarProcesador(procesador);
        }


        //Instancia Eliminar
        [HttpDelete]
        [Route("api/procesador/eliminar")]
        public int EliminarProcesador(int id)
        {
            return procesadorBL.EliminarProcesador(id);
        }
    }
}
