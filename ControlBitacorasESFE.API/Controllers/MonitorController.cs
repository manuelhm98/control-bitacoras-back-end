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
    public class MonitorController : ApiController   
    {
        //Instancia de referencias a metodos BL
        private MonitorBL monitorBL = new MonitorBL();
        // GET: api/Monitor


        // POS: api/Monitor/
        [HttpPost]
        [Route("api/monitor/guardar")]
        public int GuardarMonitor([FromBody] Monitor monitor)
        {
            return monitorBL.GuardarMonitor(monitor);
        }

        // PUT: api/Monitor/
        [HttpPut]
        [Route("api/monitor/editar")]
        public int EditarMonitor([FromBody] Monitor monitor)
        {
            return monitorBL.EditarMonitor(monitor);
        }

        // Delete: api/Monitor/
        [HttpDelete]
        [Route("api/monitor/eliminar/{id}")]
        public int EliminarMonitor(int id)
        {
            return monitorBL.EliminarMonitor(id);
        }

       
       
    }
}
