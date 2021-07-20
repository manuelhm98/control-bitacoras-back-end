using ControlBitacorasESFE.EL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlBitacorasESFE.DAL
{
    public class MuebleDAL
    {
        //Declaracion del contexto
        private ProjectContext db = new ProjectContext();

        //Metodo Guardar 
        public int GuardarMueble(Mueble mueble)
        {
            int r = 0;
            try
            {
                if(mueble != null)
                {
                    db.Muebles.Add(mueble);
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
        public int EditarMueble(Mueble mueble)
        {
            int r = 0;
            try
            {
                var local = db.Set<Mueble>().Local.FirstOrDefault(f => f.MuebleID == mueble.MuebleID);
                if(local != null)
                {
                    db.Entry(local).State = EntityState.Detached;
                }
                db.Entry(mueble).State = EntityState.Modified;
                r = db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return r;
        }

        //Metodo Eliminado Logico 
        public int EliminarMueble(int MuebleID)
        {
            int r = 0;
            try
            {
                Mueble mueble = BuscarID(MuebleID);
                mueble.Estado = 0;
                r = EditarMueble(mueble);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return r;
        }

        //Metodo Buscar ID
        public Mueble BuscarID(int MuebleID)
        {
            Mueble mueble = null;
            try
            {
                if(MuebleID > 0 || MuebleID != 0)
                {
                    mueble = db.Muebles.Find(MuebleID);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return mueble;
        }
    }
}
