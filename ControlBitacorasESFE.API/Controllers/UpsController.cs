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
    [Authorize]
    public class UpsController : ApiController
    {
        private UpsBL upsBL = new UpsBL();

        //LIST UPS 
        [HttpGet]
        [Route("api/ups")]
        public List<Ups> ups()
        {
            return upsBL.ups();
        }

        //LIST PAGING 
        [HttpGet]
        [Route("api/ups/lista")]
        public ListPagingUps listPaging(int page = 1, int pageSize = 5)
        {
            return upsBL.listPaging(page, pageSize);
        }

        //Instancia Guardar
        [HttpPost]
        [Route("api/ups")]
        public int GuardarUps(Ups ups)
        {
            return upsBL.GuardarUps(ups);
        }


        //Instancia Editar
        [HttpPut]
        [Route("api/ups")]
        public int EditarUps(Ups ups)
        {
            return upsBL.EditarUps(ups);
        }


        //Instancia Eliminar
        [HttpDelete]
        [Route("api/ups/{id}")]
        public int EliminarUps(int id)
        {
            return upsBL.EliminarUps(id);
        }

        [HttpGet]
        [Route("api/ups/{id}")]
        public Ups buscarId(int id)
        {
            return upsBL.buscarId(id);
        }
    }
}
