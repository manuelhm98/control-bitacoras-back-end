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
    public class TipoFallaBL
    {
        //Instancia de lo metodos DAL
        private TipoFallaDAL tipoFallaDAL = new TipoFallaDAL();


        //Instancia Guardar
        public int GuardarTipoFalla(TipoFalla tipoFalla)
        {
            return tipoFallaDAL.GuardarTipoFalla(tipoFalla);
        }


        //Instancia Editar
        public int EditarTipoFalla(TipoFalla tipoFalla)
        {
            return tipoFallaDAL.EditarTipoFalla(tipoFalla);
        }


        //Instancia Eliminar
        public int EliminarTipoFalla(int TipoFallaID)
        {
            return tipoFallaDAL.EliminarTipoFalla(TipoFallaID);
        }

        //LISTA PAGING 
        public ListPagingTipoFalla listPaging(int page = 1, int pageSize = 5)
        {
            return tipoFallaDAL.ListPaging(page, pageSize);
        }

        //LISTA TIPO FALLA 
        public List<TipoFalla> tipoFallas()
        {
            return tipoFallaDAL.tipoFallas();
        }

        //BY ID 
        public TipoFalla buscarId(int id)
        {
            return tipoFallaDAL.BuscarID(id);
        }
    }
}
