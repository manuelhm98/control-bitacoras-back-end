using ControlBitacorasESFE.EL;
using ControlBitacorasESFE.EL.Middlewares;
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
                    cpu.Estado = 1;
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

        //LISTA PAGIN 
        public ListPagingCpu ListPaging(int page = 1, int pageSize = 5, string name = "", string proce = "")
        {
            var cpus = (from Cpu in db.Cpus.Include(p => p.Procesador)
                        where Cpu.Estado == 1 && (Cpu.Codigo + Cpu.Ram + Cpu.Almacenamiento).Contains(name) && Cpu.Procesador.Modelo.Contains(proce)
                        select Cpu).OrderByDescending(x => x.CpuID).Skip((page - 1) * pageSize)
                        .Take(pageSize).ToList();

            int totalRegistros = (from Cpu in db.Cpus where Cpu.Estado == 1 select Cpu).Count();

            var model = new ListPagingCpu();
            model.Cpus = cpus;
            model.paginaActual = page;
            model.TotalRegistros = (int)Math.Ceiling((double)totalRegistros / pageSize);
            model.RegistroPorPagina = pageSize;
            return model;
        }

        //LISTA CPUS
        public List<Cpu> cpus()
        {
            var cpus = (from Cpu in db.Cpus.Include(p => p.Procesador)
                        where Cpu.Estado == 1
                        select Cpu).ToList();

            return cpus;
        }
    }
}
