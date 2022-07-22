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

        //BY ID 
        public EquipoArea buscarId(int id)
        {
            return equipoAreaDAL.BuscarID(id);
        }

        //LISTA PAGIN 
        public ListPagingEquipoArea listPaging(int page = 1, int pageSize = 5, string equipo = "", string area = "")
        {
            return equipoAreaDAL.listPaging(page, pageSize, equipo, area);
        }

        //LISTA EQUIPOAREA
        public List<EquipoArea> equipoAreas()
        {
            return equipoAreaDAL.equipoAreas();
        }
    }
}
