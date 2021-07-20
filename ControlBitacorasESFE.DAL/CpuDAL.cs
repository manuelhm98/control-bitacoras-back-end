using ControlBitacorasESFE.EL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlBitacorasESFE.DAL
{
    public class CpuDAL
    {
        //Declaracion del contexto 
        private ProjectContext db = new ProjectContext();

        //Metodo Guardar
        public int GuardarCpu(Cpu cpu)
        {
            int r = 0;
            try
            {
                if(cpu != null)
                {
                    db.Cpus.Add(cpu);
                    db.SaveChanges();
                }
                return r;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //Metodo Editar 
        public int EditarCpu(Cpu cpu)
        {
            int r = 0;
            try
            {
                var local = db.Set<Cpu>().Local.FirstOrDefault(f => f.CpuID == cpu.CpuID);
                if(local != null)
                {
                    db.Entry(local).State = EntityState.Detached;
                }
                db.Entry(cpu).State = EntityState.Modified;
                r = db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return r;
        }

        //Metodo Eliminado logico
        
        public int EliminarCpu(int CpuID)
        {
            int r = 0;
            try
            {
                Cpu cpu = BuscarID(CpuID);
                cpu.Estado = 0;
                r = EditarCpu(cpu);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return r;
        }


        //Obtener ID
        public Cpu BuscarID(int CpuID)
        {
            Cpu cpu = null;
            try
            {
                if(CpuID > 0 || CpuID != 0)
                {
                    cpu = db.Cpus.Find(CpuID);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return cpu;
        }
    }
}
