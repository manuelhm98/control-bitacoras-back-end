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
    public class CpuController : ApiController
    {
        private CpuBL cpuBL = new CpuBL();

        //LISTA CPU
        [HttpGet]
        [Route("api/cpu")]
        public List<Cpu> cpus()
        {
            return cpuBL.cpus();
        }

        //PAGING CPUS
        [HttpGet]
        [Route("api/cpu/lista")]
        public ListPagingCpu listPaging(int page = 1, int pageSize = 5)
        {
            return cpuBL.ListPaging(page, pageSize);
        }

        //Instancia Guardar
        [HttpPost]
        [Route("api/cpu")]
        public int GuardarCpu(Cpu cpu)
        {
            return cpuBL.GuardarCpu(cpu);
        }


        //Instancia Editar
        [HttpPut]
        [Route("api/cpu/")]
        public int EditarCpu(Cpu cpu)
        {
            return cpuBL.EditarCpu(cpu);
        }

        //Instancia Eliminar
        [HttpDelete]
        [Route("api/cpu/{id}")]
        public int EliminarCpu(int id)
        {
            return cpuBL.EliminarCpu(id);
        }

        [HttpGet]
        [Route("api/cpu/{id}")]
        public Cpu buscarId(int id)
        {
            return cpuBL.buscarID(id);
        }
    }

}
