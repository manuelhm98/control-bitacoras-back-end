using ControlBitacorasESFE.EL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlBitacorasESFE.DAL
{
    public class UpsDAL
    {
        //Declaracion del contexo
        private ProjectContext db = new ProjectContext();

        //Metodo Guardar
        public int GuardarUps(Ups ups)
        {
            int r = 0;
            try
            {
                if(ups != null)
                {
                    db.Upss.Add(ups);
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
        public int EditarUps(Ups ups)
        {
            int r = 0;
            try
            {
                var local = db.Set<Ups>().Local.FirstOrDefault(f => f.UpsID == ups.UpsID);
                if(local != null)
                {
                    db.Entry(local).State = EntityState.Detached;
                }
                db.Entry(ups).State = EntityState.Modified;
                r = db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return r;
        }

        //Metodo Eliminado Logico 
        public int EliminarUps(int UpsID)
        {
            int r = 0;
            try
            {
                Ups ups = BuscarID(UpsID);
                ups.Estado = 0;
                r = EditarUps(ups);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return r;
        }


        //Metodo Buscar ID
        public Ups BuscarID(int UpsID)
        {
            Ups ups = null;
            try
            {
                ups = db.Upss.Find(UpsID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ups;
        }
        
    }
}
