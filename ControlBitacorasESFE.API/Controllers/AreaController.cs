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
    public class AreaController : ApiController
    {
        //Instancia de los metodos BL
        private AreaBL areaBL = new AreaBL();


        //Instancia Guardar
        [HttpPost]
        [Route("api/area")]
        public int GuardarArea(Area area)
        {
            return areaBL.GuardarArea(area);
        }

        //Instancia Editar
        [HttpPut]
        [Route("api/area")]
        public int EditarArea(Area area)
        {
            return areaBL.EditarArea(area);
        }

        //Instancia Eliminar 
        [HttpDelete]
        [Route("api/area/{id}")]
        public int EliminarArea(int id)
        {
            return areaBL.EliminarAre(id);
        }

        //LISTA
        [HttpGet]
        [Route("api/area")]
        public List<Area> areas()
        {
            return areaBL.areas();
        }

        //lISTA PAGING 
        [HttpGet]
        [Route("api/area/lista")]
        public ListPagingArea listPaging(int page = 1, int pageSize = 5)
        {
            return areaBL.listPaging(page, pageSize);
        }

        //BY ID 
        [HttpGet]
        [Route("api/area/{id}")]
        public Area buscarId(int id)
        {
            return areaBL.BuscarId(id);
        }
    }
}
