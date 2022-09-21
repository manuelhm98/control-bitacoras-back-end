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
    
    public class BitacoraController : ApiController
    {
        //Instancia de los metodos BL
        private BitacoraBL bitacoraBL = new BitacoraBL();

        //LISTA
        [HttpGet]
        [Route("api/bitacora")]
        public List<Bitacora> bitacoras(string start = "")
        {
            return bitacoraBL.bitacoras(start);
        }

        //PAGIN
        [HttpGet]
        [Route("api/bitacora/lista")]
        public ListPagingBitacora listPagingBitacora(int page = 1, int pageSize = 5, string fecha = "", string user = "", string rol = "", string falla = "", string puestos = "")
        {
            return bitacoraBL.listaBitacoras(page, pageSize, fecha, user, rol, falla, puestos);
        }

        //Instancia Guardar
        [HttpPost]
        [Route("api/bitacora")]
        public int guardarBitacora(Bitacora bitacora)
        {
            return bitacoraBL.guardarBitacora(bitacora);
        }

        //Instancia Editar
        [HttpPut]
        [Route("api/bitacora")]
        public int editarBitacora(Bitacora bitacora)
        {
            return bitacoraBL.editarBitacora(bitacora);
        }


        //Instancia Eliminar 
        [HttpDelete]
        [Route("api/bitacora/{id}")]
        public int eliminarBitacora(int id)
        {
            return bitacoraBL.eliminarBitacora(id);
        }

        //BY ID 
        [HttpGet]
        [Route("api/bitacora/{id}")]
        public Bitacora buscarId(int id)
        {
            return bitacoraBL.buscarId(id);
        }

    }
}
