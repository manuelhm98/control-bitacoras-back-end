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
    public class TipoFallaController : ApiController
    {
        private TipoFallaBL tipoFallaBL = new TipoFallaBL();


        //LISTA TIPO FALLA 
        [HttpGet]
        [Route("api/tipofalla")]
        public List<TipoFalla> tipoFallas()
        {
            return tipoFallaBL.tipoFallas();
        }

        //LIST PAGING 
        [HttpGet]
        [Route("api/tipofalla/lista")]
        public ListPagingTipoFalla listPaging(int page = 1, int pageSize = 5)
        {
            return tipoFallaBL.listPaging(page, pageSize);
        }
        //Instancia Guardar
        [HttpPost]
        [Route("api/tipofalla")]
        public int GuardarTipoFalla(TipoFalla tipoFalla)
        {
            return tipoFallaBL.GuardarTipoFalla(tipoFalla);
        }


        //Instancia Editar
        [HttpPut]
        [Route("api/tipofalla")]
        public int EditarTipoFalla(TipoFalla tipoFalla)
        {
            return tipoFallaBL.EditarTipoFalla(tipoFalla);
        }


        //Instancia Eliminar
        [HttpDelete] 
        [Route("api/tipofalla/{id}")]
        public int EliminarTipoFalla(int id)
        {
            return tipoFallaBL.EliminarTipoFalla(id);
        }

        //BY ID 
        [HttpGet]
        [Route("api/tipofalla/{id}")]
        public TipoFalla buscarId(int id)
        {
            return tipoFallaBL.buscarId(id);
        }
    }
}
