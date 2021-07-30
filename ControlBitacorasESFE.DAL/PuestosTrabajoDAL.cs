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
                    puestosTrabajo = db.PuestosTrabajos.Find(PuestosTrabajoID);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return puestosTrabajo;
        }

        //LIST PAGING
        public ListPagingPuestosTrabajo listPaging(int page = 1, int pageSize = 5)
        {
            var puestosTrabajo = (from PuestosTrabajo in db.PuestosTrabajos.Include(a => a.Area)
                                  .Include(m => m.Monitor)
                                  .Include(u => u.Ups)
                                  .Include(c => c.Cpu)
                                  .Include(mu => mu.Mueble)
                                  where PuestosTrabajo.Estado == 1
                                  select PuestosTrabajo).OrderByDescending(x => x.PuestosTrabajoID)
                                  .Skip((page - 1) * pageSize)
                                  .Take(pageSize).ToList();

            int totalRegistros = (from PuestosTrabajo in db.PuestosTrabajos where PuestosTrabajo.Estado == 1 select PuestosTrabajo).Count();

            var model = new ListPagingPuestosTrabajo();
            model.PuestosTrabajos = puestosTrabajo;
            model.paginaActual = page;
            model.TotalRegistros = totalRegistros / pageSize;

            if(model.TotalRegistros % 2 != 0)
            {
                model.TotalRegistros = Math.Truncate(model.TotalRegistros) + 1;
            }

            model.RegistroPorPagina = pageSize;

            return model;
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
