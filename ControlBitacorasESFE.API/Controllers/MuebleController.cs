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
    public class MuebleController : ApiController
    {
        private MuebleBL muebleBL = new MuebleBL();

        //LIST PAGING 
        [HttpGet]
        [Route("api/mueble/lista")]
        public ListPagingMueble listPaging(int page = 1, int pageSize = 5)
        {
            return muebleBL.listPaging(page, pageSize);
        }

        //LISTA MUEBLE
        [HttpGet]
        [Route("api/mueble")]
        public List<Mueble> muebles()
        {
            return muebleBL.muebles();
        }

        //Instancia Guardar
        [HttpPost]
        [Route("api/mueble")]
        public int GuardarMueble(Mueble mueble)
        {
            return muebleBL.GuardarMueble(mueble);
        }

        //Instancia Editar
        [HttpPut] 
        [Route("api/mueble")]
        public int EditarMueble(Mueble mueble)
        {
            return muebleBL.EditarMueble(mueble);
        }

        //Instancia ELiminar
        [HttpDelete]
        [Route("api/mueble/{id}")]
        public int EliminarMueble(int id)
        {
            return muebleBL.EliminarMueble(id);
        }

        //BY ID 
        [HttpGet]
        [Route("api/mueble/{id}")]
        public Mueble buscarId(int id)
        {
            return muebleBL.buscarId(id);
        }
    }
}
