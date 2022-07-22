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
    public class MuebleBL
    {
        //Instabncia de los metodos DAL
        private MuebleDAL muebleDAL = new MuebleDAL();


        //Instancia Guardar
        public int GuardarMueble(Mueble mueble)
        {
            return muebleDAL.GuardarMueble(mueble);
        }


        //Instancia Editar
        public int EditarMueble(Mueble mueble)
        {
            return muebleDAL.EditarMueble(mueble);
        }


        //Instancia Eliminar
        public int EliminarMueble(int MuebleID)
        {
            return muebleDAL.EliminarMueble(MuebleID);
        }

        //LISTA PAGING 
        public ListPagingMueble listPaging(int page = 1, int pageSize = 5, string mueble = "")
        {
            return muebleDAL.listPaging(page, pageSize, mueble);
        }

        //LISTA MUEBLES
        public List<Mueble> muebles()
        {
            return muebleDAL.muebles();
        }

        //BY ID 
        public Mueble buscarId(int id)
        {
            return muebleDAL.BuscarID(id);
        }
    }
}
