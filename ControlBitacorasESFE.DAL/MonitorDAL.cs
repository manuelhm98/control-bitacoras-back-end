using ControlBitacorasESFE.EL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlBitacorasESFE.DAL
{
    public class MonitorDAL
    {
        //Declaracion del contexto 
        private ProjectContext db = new ProjectContext();

        //Metodo Guardar 
        public int GuardarMonitor(Monitor monitor)
        {
            int r = 0;
            try
            {
                if(monitor != null)
                {
                    db.Monitors.Add(monitor);
                    r = db.SaveChanges();
                }
                return r;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //Metodo Editar 
        public int EditarMonitor(Monitor monitor)
        {
            int r = 0;
            try
            {
                var local = db.Set<Monitor>().Local.FirstOrDefault(f => f.MonitorID == monitor.MonitorID);
                if (local != null)
                {
                    db.Entry(local).State = EntityState.Detached;
                }
                db.Entry(monitor).State = EntityState.Modified;
                r = db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return r;
        }

        //Metodo Eliminado Logico
        public int EliminarMonitor(int MonitorID)
        {
            int r = 0;
            try
            {
                Monitor monitor = BuscarID(MonitorID);
                monitor.Estado = 0;
                r = EditarMonitor(monitor);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return r;
        }

        //Metodo Buscar ID
        public Monitor BuscarID(int MonitorID)
        {
            Monitor monitor = null;
            try
            {
                if(MonitorID > 0 || MonitorID != 0)
                {
                    monitor = db.Monitors.Find(MonitorID);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return monitor;
        }
    }
}
