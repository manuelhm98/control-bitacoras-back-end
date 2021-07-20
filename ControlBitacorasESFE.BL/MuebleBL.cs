using ControlBitacorasESFE.DAL;
using ControlBitacorasESFE.EL;
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
    }
}
