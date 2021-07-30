using ControlBitacorasESFE.BL;
using ControlBitacorasESFE.EL;
using ControlBitacorasESFE.EL.Middlewares;
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
  
        //PAGING LIST
        [HttpGet]
        [Route("api/monitor/lista")]
        public ListPagingMonitor listPaging(int page = 1, int pageSize = 5)
        {
            return monitorBL.listPaging(page, pageSize);
        }
        
        //LISTA MONITORES
        [HttpGet]
        [Route("api/monitor")]
        public List<Monitor> monitors()
        {
            return monitorBL.monitors();
        }

        // POS: api/Monitor/
        [HttpPost]
        [Route("api/monitor")]
        public int GuardarMonitor([FromBody] Monitor monitor)
        {
            return monitorBL.GuardarMonitor(monitor);
        }

        // PUT: api/Monitor/
        [HttpPut]
        [Route("api/monitor")]
        public int EditarMonitor([FromBody] Monitor monitor)
        {
            return monitorBL.EditarMonitor(monitor);
        }

        // Delete: api/Monitor/
        [HttpDelete]
        [Route("api/monitor/{id}")]
        public int EliminarMonitor(int id)
        {
            return monitorBL.EliminarMonitor(id);
        }

        //  BY ID 
        [HttpGet]
        [Route("api/monitor/{id}")]
        public Monitor buscarId(int id)
        {
            return monitorBL.buscarId(id);
        }



       
       
    }
}
