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
    public class TipoAreaController : ApiController
    {
        private TipoAreaBL tipoAreaBL = new TipoAreaBL();

        //LISTA TIPOAREAS
        [HttpGet]
        [Route("api/tipoarea")]
        public List<TipoArea> tipoAreas()
        {
            return tipoAreaBL.tipoAreas();
        }

        //LIST PAGIN
        [HttpGet]
        [Route("api/tipoarea/lista")]
        public ListPagingTipoArea listPaging(int page = 1, int pageSize = 5)
        {
            return tipoAreaBL.listPaging(page, pageSize);
        } 

        //Instancia Guardar
        [HttpPost]
        [Route("api/tipoarea")]
        public int GuardarTipoArea(TipoArea tipoArea)
        {
            return tipoAreaBL.GuardarTipoArea(tipoArea);
        }


        //Instancia Editar
        [HttpPut]
        [Route("api/tipoarea")]
        public int EditarTipoArea(TipoArea tipoArea)
        {
            return tipoAreaBL.EditarTipoArea(tipoArea);
        }


        //Instancia Eliminar
        [HttpDelete]
        [Route("api/tipoarea/{id}")]
        public int EliminarTipoArea(int id)
        {
            return tipoAreaBL.EliminarTipoArea(id);
        }

        //BY ID 
        [HttpGet]
        [Route("api/tipoarea/{id}")]
        public TipoArea buscarId(int id)
        {
            return tipoAreaBL.buscarId(id);
        }
    }
}
