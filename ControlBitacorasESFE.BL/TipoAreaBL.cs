using ControlBitacorasESFE.DAL;
using ControlBitacorasESFE.EL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlBitacorasESFE.BL
{
    public class TipoAreaBL
    {
        //Instancia de los metodos DAL
        private TipoAreaDAL tipoAreaDAL = new TipoAreaDAL();


        //Instancia Guardar
        public int GuardarTipoArea(TipoArea tipoArea)
        {
            return tipoAreaDAL.GuardarTipoArea(tipoArea);
        }


        //Instancia Editar
        public int EditarTipoArea(TipoArea tipoArea)
        {
            return tipoAreaDAL.EditarTipoArea(tipoArea);
        }

        public int EliminarTipoArea(int TipoAreaID)
        {
            return tipoAreaDAL.EliminarTipoArea(TipoAreaID);
        }
    }
}
