using ControlBitacorasESFE.DAL;
using ControlBitacorasESFE.EL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlBitacorasESFE.BL
{
    public class AreaBL
    {
        //LIST
        public List<Area> areas()
        {
            return areaDAL.listaArea();
        }
        //Instancia de los metodos
        private AreaDAL areaDAL = new AreaDAL();

        //Instancia Guardar
        public int GuardarArea(Area area)
        {
            return areaDAL.GuardarAreas(area);
        }

        //Instancia Editar
        public int EditarArea(Area area)
        {
            return areaDAL.EditarAreas(area);
        }

        //Instancia Eliminar
        public int EliminarAre(int AreaID)
        {
            return areaDAL.EliminarArea(AreaID);
        }

        //Buscar ID
        public Area BuscarId (int id)
        {
            return areaDAL.BuscarID(id);
        } 
    }
}
