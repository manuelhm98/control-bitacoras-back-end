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
    public class EquipoAreaController : ApiController
    {
        private EquipoAreaBL equipoAreaBL = new EquipoAreaBL();


        //Instancia Guardar
        [HttpPost]
        [Route("api/equipoarea/guardar")]
        public int GuardarEquipoArea(EquipoArea equipoArea)
        {
            return equipoAreaBL.GuardarEquipoArea(equipoArea);
        }

        //Instancia Editar
        [HttpPut]
        [Route("api/equipoarea/editar")]
        public int EditarEquipoArea(EquipoArea equipoArea)
        {
            return equipoAreaBL.EditarEquipoArea(equipoArea);
        }

        [HttpDelete]
        [Route("api/equipoarea/eliminar/{id}")]
        public int EliminarEquipoArea(int id)
        {
            return equipoAreaBL.EliminarEquipoArea(id);
        }
    }
}
