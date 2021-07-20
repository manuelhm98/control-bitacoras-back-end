using ControlBitacorasESFE.EL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlBitacorasESFE.DAL
{
    public class FallaDAL
    {
        //Declaracion del contexto 
        private ProjectContext db = new ProjectContext();


        //Metodo Guardar 
        public int GuardarFalla(Falla falla)
        {
            int r = 0;
            try
            {
                if(falla != null)
                {
                    db.Fallas.Add(falla);
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
        public int EditarFalla(Falla falla)
        {
            int r = 0;
            try
            {
                var local = db.Set<Falla>().Local.FirstOrDefault(f => f.FallaID == falla.FallaID);
                if(local != null)
                {
                    db.Entry(local).State = EntityState.Detached;
                }
                db.Entry(falla).State = EntityState.Modified;
                r = db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return r;
        }

        //Metodo Eliminado Logico
        public int EliminarFalla(int FallaID)
        {
            int r = 0;
            try
            {
                Falla falla = BuscarID(FallaID);
                falla.Estado = 0;
                r = EditarFalla(falla);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return r;
        }

        //Metodo Buscar ID
        public Falla BuscarID(int FallaID)
        {
            Falla falla = null;
            try
            {
                if(FallaID > 0 || FallaID != 0)
                {
                    falla = db.Fallas.Find(FallaID);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return falla;
        }
    }
}
