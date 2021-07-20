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
    public class CpuController : ApiController
    {
        private CpuBL cpuBL = new CpuBL();

        //Instancia Guardar
        [HttpPost]
        [Route("api/cpu/guardar")]
        public int GuardarCpu(Cpu cpu)
        {
            return cpuBL.GuardarCpu(cpu);
        }


        //Instancia Editar
        [HttpPut]
        [Route("api/cpu/editar")]
        public int EditarCpu(Cpu cpu)
        {
            return cpuBL.EditarCpu(cpu);
        }

        //Instancia Eliminar
        [HttpPost]
        [Route("api/cpu/eliminar/{id}")]
        public int EliminarCpu(int id)
        {
            return cpuBL.EliminarCpu(id);
        }
    }
}
