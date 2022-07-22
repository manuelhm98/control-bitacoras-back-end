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
    public class PuestosTrabajoDAL
    {
        //Declaracion del contexto
        private ProjectContext db = new ProjectContext();

        //Metodo Guardar 
        public int GuardarPuestosTrabajo(PuestosTrabajo puestosTrabajo)
        {
            int r = 0;
            try
            {
                if(puestosTrabajo != null)
                {
                    puestosTrabajo.Estado = 1;
                    db.PuestosTrabajos.Add(puestosTrabajo);
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
        public int EditarPuestosTrabajo(PuestosTrabajo puestosTrabajo)
        {
            int r = 0;
            try
            {
                var local = db.Set<PuestosTrabajo>().Local.FirstOrDefault(f => f.PuestosTrabajoID == puestosTrabajo.PuestosTrabajoID);
                if(local != null)
                {
                    db.Entry(local).State = EntityState.Detached;
                }
                db.Entry(puestosTrabajo).State = EntityState.Modified;
                r = db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return r;
        }

        //Metodo Eliminado Logico
        public int EliminarPuestosTrabajo(int PuestosTrabajoID)
        {
            int r = 0;
            try
            {
                PuestosTrabajo puestosTrabajo = BuscarID(PuestosTrabajoID);
                puestosTrabajo.Estado = 0;
                r = EditarPuestosTrabajo(puestosTrabajo);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return r;
        }


        //Metodo Buscar ID
        public PuestosTrabajo BuscarID(int PuestosTrabajoID)
        {
            PuestosTrabajo puestosTrabajo = null;
            try
            {
                if(PuestosTrabajoID > 0 || PuestosTrabajoID != 0)
                {
                    puestosTrabajo = db.PuestosTrabajos
                        .Include(a => a.Area)
                                  .Include(m => m.Monitor)
                                  .Include(u => u.Ups)
                                  .Include(c => c.Cpu)
                                  .Include(mu => mu.Mueble).FirstOrDefault(x => x.PuestosTrabajoID == PuestosTrabajoID);

                    // puestosTrabajo = db.PuestosTrabajos.Find(PuestosTrabajoID);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return puestosTrabajo;
        }

        //LIST PAGING
        public ListPagingPuestosTrabajo listPaging(int page = 1, int pageSize = 5, string puesto = "",
            string area = "", string monitor = "", string ups = "", string cpu = "", string mueble = "")
        {
            var puestosTrabajo = (from PuestosTrabajo in db.PuestosTrabajos.Include(a => a.Area)
                                  .Include(m => m.Monitor)
                                  .Include(u => u.Ups)
                                  .Include(c => c.Cpu)
                                  .Include(mu => mu.Mueble)
                                  where PuestosTrabajo.Estado == 1 && PuestosTrabajo.Codigo.Contains(puesto)
                                  && PuestosTrabajo.Area.NombreArea.Contains(area) 
                                  && (PuestosTrabajo.Monitor.Codigo + PuestosTrabajo.Monitor.Modelo).Contains(monitor)
                                  && PuestosTrabajo.Ups.Codigo.Contains(ups)
                                  && PuestosTrabajo.Cpu.Codigo.Contains(cpu)
                                  && PuestosTrabajo.Mueble.Codigo.Contains(mueble)
                                  select PuestosTrabajo).OrderByDescending(x => x.PuestosTrabajoID)
                                  .Skip((page - 1) * pageSize)
                                  .Take(pageSize).ToList();

            int totalRegistros = (from PuestosTrabajo in db.PuestosTrabajos where PuestosTrabajo.Estado == 1 select PuestosTrabajo).Count();

            var model = new ListPagingPuestosTrabajo();
            model.PuestosTrabajos = puestosTrabajo;
            model.paginaActual = page;
            model.TotalRegistros = (int)Math.Ceiling((double)totalRegistros / pageSize);
            model.RegistroPorPagina = pageSize;

            return model;
        }


        public PaginCount  puestosTrabajosCount()
        {
            int monitores = (from Monitor in db.Monitors where Monitor.Estado == 1 select Monitor).Count();
            int ups = (from Ups in db.Upss where Ups.Estado == 1 select Ups).Count();
            int cpu = (from Cpu in db.Cpus where Cpu.Estado == 1 select Cpu).Count();
            int puestosTrabajo = (from PuestosTrabajo in db.PuestosTrabajos where PuestosTrabajo.Estado == 1 select PuestosTrabajo).Count();
            int bitacora = (from Bitacora in db.Bitacoras where Bitacora.Estado == 1 select Bitacora).Count();

            PaginCount paginCount = new PaginCount();
            paginCount.Monitores = monitores;
            paginCount.Ups = ups;
            paginCount.Cpu = cpu;
            paginCount.PuestosTrabajo = puestosTrabajo;
            paginCount.Bitacoras = bitacora;

            return paginCount;
        }


        //LISTA PUESTOS TRABAJO 
        public List<PuestosTrabajo> puestosTrabajos()
        {
            var puestosTrabajo = (from PuestosTrabajo in db.PuestosTrabajos.Include(a => a.Area)
                                  .Include(m => m.Monitor)
                                  .Include(u => u.Ups)
                                  .Include(c => c.Cpu)
                                  .Include(mu => mu.Mueble)
                                  where PuestosTrabajo.Estado == 1
                                  select PuestosTrabajo).ToList();

            return puestosTrabajo;
        }

   


    }
}
