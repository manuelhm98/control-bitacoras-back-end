using ControlBitacorasESFE.DAL;
using ControlBitacorasESFE.EL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlBitacorasESFE.BL
{
    public class EquipoAreaBL
    {
        //Instancia de los metodos DAL
        private EquipoAreaDAL equipoAreaDAL = new EquipoAreaDAL();


        //Instancia Guardar
        public int GuardarEquipoArea(EquipoArea equipoArea)
        {
            return equipoAreaDAL.GuardarEquipoArea(equipoArea);
        }


        //Instancia Editar 
        public int EditarEquipoArea(EquipoArea equipoArea)
        {
            return equipoAreaDAL.EditarEquipoArea(equipoArea);
        }


        //Metodo Eliminar 
        public int EliminarEquipoArea(int EquipoAreaID)
        {
            return equipoAreaDAL.EliminarEquipoArea(EquipoAreaID);
        }
    }
}
