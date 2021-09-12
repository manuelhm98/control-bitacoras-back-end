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
    public class ProcesadorController : ApiController
    {
        private ProcesadorBL procesadorBL = new ProcesadorBL();

        //LISTA PAGING 
        [HttpGet]
        [Route("api/procesador/lista")]
        public ListPagingProcesador listPaging(int page = 1 , int pageSize = 5)
        {
            return procesadorBL.listPaging(page, pageSize);
        }

        //LISTA PROCESADOR 
        [HttpGet]
        [Route("api/procesador")]
        public List<Procesador> procesadors()
        {
            return procesadorBL.procesadors();
        }

        //Intancia Guardar
        [HttpPost]
        [Route("api/procesador")]
        public int GuardarProcesador(Procesador procesador)
        {
            return procesadorBL.GuardarProcesador(procesador);
        }


        //Instancia Editar 
        [HttpPut]
        [Route("api/procesador")]
        public int EditarProcesador(Procesador procesador)
        {
            return procesadorBL.EditarProcesador(procesador);
        }


        //Instancia Eliminar
        [HttpDelete]
        [Route("api/procesador/{id}")]
        public int EliminarProcesador(int id)
        {
            return procesadorBL.EliminarProcesador(id);
        }

        [HttpGet]
        [Route("api/procesador/{id}")]
        public Procesador buscarId(int id)
        {
            return procesadorBL.buscarId(id);
        }
    }
}
