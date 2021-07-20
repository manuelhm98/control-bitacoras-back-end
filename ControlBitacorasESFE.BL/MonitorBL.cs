using ControlBitacorasESFE.DAL;
using ControlBitacorasESFE.EL;
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
    }
}
