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
    public class PuestosTrabajoController : ApiController
    {
        private PuestosTrabajoBL puestosTrabajoBL = new PuestosTrabajoBL();

         
        [HttpGet]
        [Route("api/puestostrabajo")]
        public List<PuestosTrabajo> puestosTrabajos()
        {
            return puestosTrabajoBL.puestosTrabajos();
        }

        [HttpGet]
        [Route("api/puestostrabajo/lista")]
        public ListPagingPuestosTrabajo listPaging(int page = 1, int pageSize = 5)
        {
            return puestosTrabajoBL.listPaging(page, pageSize);
        }
        //Instancia Guardar
        [HttpPost]
        [Route("api/puestostrabajo")]
        public int GuardarPuestosTrabajo(PuestosTrabajo puestosTrabajo)
        {
            return puestosTrabajoBL.GuardarPuestosTrabajo(puestosTrabajo);
        }


        //Instancia Editar
        [HttpPut]
        [Route("api/puestostrabajo")]
        public int EditarPuestosTrabajo(PuestosTrabajo puestosTrabajo)
        {
            return puestosTrabajoBL.EditarPuestosTrabajo(puestosTrabajo);
        }

        //Intancia Eliminar
        [HttpDelete]
        [Route("api/puestostrabajo/{id}")]
        public int EliminarPuestosTrabajo(int id)
        {
            return puestosTrabajoBL.ElimarPuestosTrabajo(id);
        }

        [HttpGet]
        [Route("api/puestostrabajo/{id}")]
        public PuestosTrabajo buscarId(int id)
        {
            return puestosTrabajoBL.buscarId(id);
        }
    }
}
