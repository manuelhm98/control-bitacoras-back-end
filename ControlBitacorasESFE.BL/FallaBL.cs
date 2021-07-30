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
    public class FallaBL
    {
        //Instancia de los metodos DAL
        private FallaDAL fallaDAL = new FallaDAL();


        //Instancia Guardar 
        public int GuardarFalla(Falla falla)
        {
            return fallaDAL.GuardarFalla(falla);
        }


        //Instancia Editar
        public int EditarFalla(Falla falla)
        {
            return fallaDAL.EditarFalla(falla);
        }
        

        //Instancia Eliminar 
        public int EliminarFalla(int FallaID)
        {
            return fallaDAL.EliminarFalla(FallaID);
        }

        //PAGING LIST 
        public ListPagingFalla listPaging(int page = 1, int pageSize = 5)
        {
            return fallaDAL.listPaging(page, pageSize);
        }

        //LISTA FALLAS
        public List<Falla> fallas()
        {
            return fallaDAL.fallas();
        }

        //BY ID 
        public Falla buscarId(int id)
        {
            return fallaDAL.BuscarID(id);
        }
    }
}
