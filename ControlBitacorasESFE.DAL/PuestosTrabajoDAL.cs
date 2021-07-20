using ControlBitacorasESFE.EL;
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
    }
}
