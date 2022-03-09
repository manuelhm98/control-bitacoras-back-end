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
    public class FallaController : ApiController
    {
        private FallaBL fallaBL = new FallaBL();

        //PAGING LIST 
        [HttpGet]
        [Route("api/falla/lista")]
        public ListPagingFalla listPaging(int page = 1, int pageSize = 5)
        {
            return fallaBL.listPaging(page, pageSize);
        }

        //LISTA FALLA
        [HttpGet]
        [Route("api/falla")]
        public List<Falla> fallas()
        {
            return fallaBL.fallas();
        }


        //Instancia Guardar
        [HttpPost]
        [Route("api/falla")]
        public int GuardarFalla(Falla falla)
        {
            return fallaBL.GuardarFalla(falla);
        }
    
        
        //Instancia Editar
        [HttpPut]
        [Route("api/falla")]
        public int EditarFalla(Falla falla)
        {
            return fallaBL.EditarFalla(falla);
        }


        //Instancia Eliminar
        [HttpDelete]
        [Route("api/falla/{id}")]
        public int EliminarFalla(int id)
        {
            return fallaBL.EliminarFalla(id);
        }

        //BY ID 
        [HttpGet]
        [Route("api/falla/{id}")]
        public Falla buscarId(int id)
        {
            return fallaBL.buscarId(id);
        }
    }
}
