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
    public class MonitorBL
    {
        //Instancia de los metodos DAL
        private MonitorDAL monitorDAL = new MonitorDAL();


        //Instancia Guardar
        public int GuardarMonitor(Monitor monitor)
        {
            return monitorDAL.GuardarMonitor(monitor);
        }


        //Instancia Editar
        public int EditarMonitor(Monitor monitor)
        {
            return monitorDAL.EditarMonitor(monitor);
        }


        //Instancia Eliminar 
        public int EliminarMonitor(int MonitorID)
        {
            return monitorDAL.EliminarMonitor(MonitorID);
        }

        //LISTA PAGING

        public ListPagingMonitor listPaging(int page = 1, int pageSize = 5)
        {
            return monitorDAL.listPaging(page, pageSize);
        }

        //LISTA MONITORES
        public List<Monitor> monitors()
        {
            return monitorDAL.monitors();
        }

        //BY ID 
        public Monitor buscarId(int id)
        {
            return monitorDAL.BuscarID(id);
        }
    }
}
