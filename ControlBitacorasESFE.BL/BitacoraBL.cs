using ControlBitacorasESFE.DAL;
using ControlBitacorasESFE.EL;
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
        public int GuardarBitacora(Bitacora bitacora)
        {
            return bitacoraDAL.GuardarBitacora(bitacora);
        }


        //Instancia Editar 
        public int EditarBitacora(Bitacora bitacora)
        {
            return bitacoraDAL.EditarBitacoras(bitacora);
        }


        //Instancia Eliminar 
        public int EliminarBitacora(int BitacoraID)
        {
            return bitacoraDAL.EliminarBitacora(BitacoraID);
        }
    }
}
