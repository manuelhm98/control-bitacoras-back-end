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
    public class UpsBL
    {
        //Instancia de los metodos DAL 
        private UpsDAL upsDAL = new UpsDAL();


        //Instancia Guardar 
        public int GuardarUps(Ups ups)
        {
            return upsDAL.GuardarUps(ups);
        }


        //Instancia Editar
        public int EditarUps(Ups ups)
        {
            return upsDAL.EditarUps(ups);
        }

        
        //Instancia Eliminar
        public int EliminarUps(int UpsID)
        {
            return upsDAL.EliminarUps(UpsID);
        }

        //LIST PAGING 
        public ListPagingUps listPaging(int page = 1, int pageSize = 5)
        {
            return upsDAL.listPaging(page, pageSize);
        }

        //LISTA UPS 
        public List<Ups> ups()
        {
            return upsDAL.ups();
        }

        //BY ID 
        public Ups buscarId(int id)
        {
            return upsDAL.BuscarID(id);
        }
    }
}
