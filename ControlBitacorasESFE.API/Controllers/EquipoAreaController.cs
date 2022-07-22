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
    public class EquipoAreaController : ApiController
    {
        private EquipoAreaBL equipoAreaBL = new EquipoAreaBL();

        //LISTA EQUIPOAREA
        [HttpGet]
        [Route("api/equipoarea")]
        public List<EquipoArea> equipoAreas()
        {
            return equipoAreaBL.equipoAreas();
        }

        //PAGIN LISTA
        [HttpGet]
        [Route("api/equipoarea/lista")]
        public ListPagingEquipoArea listPaging(int page = 1, int pageSize = 5, string equipo = "", string area = "")
        {
            return equipoAreaBL.listPaging(page, pageSize, equipo, area);
        }


        //Instancia Guardar
        [HttpPost]
        [Route("api/equipoarea")]
        public int GuardarEquipoArea(EquipoArea equipoArea)
        {
            return equipoAreaBL.GuardarEquipoArea(equipoArea);
        }

        //Instancia Editar
        [HttpPut]
        [Route("api/equipoarea")]
        public int EditarEquipoArea(EquipoArea equipoArea)
        {
            return equipoAreaBL.EditarEquipoArea(equipoArea);
        }

        [HttpDelete]
        [Route("api/equipoarea/{id}")]
        public int EliminarEquipoArea(int id)
        {
            return equipoAreaBL.EliminarEquipoArea(id);
        }

        //BY ID 
        [HttpGet]
        [Route("api/equipoarea/{id}")]
        public EquipoArea buscarId(int id)
        {
            return equipoAreaBL.buscarId(id);
        }
    }
}
