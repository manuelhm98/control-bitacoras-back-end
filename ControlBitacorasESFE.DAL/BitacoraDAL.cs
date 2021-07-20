using ControlBitacorasESFE.EL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlBitacorasESFE.DAL
{
   public  class BitacoraDAL
    {
        //Declaracion de contexto
        private ProjectContext db = new ProjectContext();


        //Metodo de guardar
        public int GuardarBitacora(Bitacora bitacora)
        {
            int r = 0;
            try
            {
                if(bitacora != null)
                {
                    db.Bitacoras.Add(bitacora);
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
        public int EditarBitacoras(Bitacora bitacora)
        {
            int r = 0;
            try
            {
                var local = db.Set<Bitacora>().Local.FirstOrDefault(f => f.BitacoraID == bitacora.BitacoraID);
                if(local != null)
                {
                    db.Entry(local).State = EntityState.Detached;
                }
                db.Entry(bitacora).State = EntityState.Modified;
                r = db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return r;
        }

        //Eliminado logico 
        public int EliminarBitacora(int BitacoraID)
        {
            int r = 0;
            try
            {
                Bitacora bitacora = BuscarID(BitacoraID);
                bitacora.Estado = 0;
                r = EditarBitacoras(bitacora);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return r;
        }

        //Obtener ID
        public Bitacora BuscarID(int BitacoraID)
        {
            Bitacora bitacora = null;
            try
            {
                if(BitacoraID > 0 || BitacoraID != 0)
                {
                    bitacora = db.Bitacoras.Find(BitacoraID);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return bitacora;
        }
    }
}
