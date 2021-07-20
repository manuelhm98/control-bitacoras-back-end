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
    public class PuestosTrabajoController : ApiController
    {
        private PuestosTrabajoBL puestosTrabajoBL = new PuestosTrabajoBL();

        //Instancia Guardar
        [HttpPost]
        [Route("api/puestostrabajo/guardar")]
        public int GuardarPuestosTrabajo(PuestosTrabajo puestosTrabajo)
        {
            return puestosTrabajoBL.GuardarPuestosTrabajo(puestosTrabajo);
        }


        //Instancia Editar
        [HttpPut]
        [Route("api/puestostrabajo/editar")]
        public int EditarPuestosTrabajo(PuestosTrabajo puestosTrabajo)
        {
            return puestosTrabajoBL.EditarPuestosTrabajo(puestosTrabajo);
        }

        //Intancia Eliminar
        [HttpDelete]
        [Route("api/puestostrabajo/eliminar/{id}")]
        public int EliminarPuestosTrabajo(int id)
        {
            return puestosTrabajoBL.ElimarPuestosTrabajo(id);
        }
    }
}
