using ControlBitacorasESFE.DAL;
using ControlBitacorasESFE.EL;
using ControlBitacorasESFE.EL.Middlewares;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlBitacorasESFE.BL
{
    public class BitacoraBL
    {
        //Intancia de la clase DAL
        private BitacoraDAL bitacoraDAL = new BitacoraDAL();

        //Instancia Guardar 
        public int guardarBitacora(Bitacora bitacora)
        {
            return bitacoraDAL.guardarBitacora(bitacora);
        }


        //Instancia Editar 
        public int editarBitacora(Bitacora bitacora)
        {
            return bitacoraDAL.editarBitacoras(bitacora);
        }


        //Instancia Eliminar 
        public int eliminarBitacora(int BitacoraID)
        {
            return bitacoraDAL.eliminarBitacora(BitacoraID);
        }
        //PAGINADO
        public ListPagingBitacora listaBitacoras(int page = 1, int pageSize = 5, string fecha = "", string user = "", string rol = "", string falla = "", string puestos = "")
        {
            return bitacoraDAL.bitacorasLista(page, pageSize, fecha, user, rol, falla, puestos);
        }
        //LISTA
        public List<Bitacora> bitacoras()
        {
            return bitacoraDAL.bitacoras();
        }

        //BY ID
        public Bitacora buscarId(int id)
        {
            return bitacoraDAL.buscarId(id);
        }
    }
}
