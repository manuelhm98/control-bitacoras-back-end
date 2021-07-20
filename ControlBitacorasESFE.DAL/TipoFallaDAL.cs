using ControlBitacorasESFE.EL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlBitacorasESFE.DAL
{
    public class TipoFallaDAL
    {
        //Declaracion del contexto
        private ProjectContext db = new ProjectContext();

        //Metodo Guardar 
        public int GuardarTipoFalla(TipoFalla tipoFalla)
        {
            int r = 0;
            try
            {
                if(tipoFalla != null)
                {
                    db.TipoFallas.Add(tipoFalla);
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
        public int EditarTipoFalla(TipoFalla tipoFalla)
        {
            int r = 0;
            try
            {
                var local = db.Set<TipoFalla>().Local.FirstOrDefault(f => f.TipoFallaID == tipoFalla.TipoFallaID);
                if(local != null)
                {
                    db.Entry(local).State = EntityState.Detached;
                }
                db.Entry(tipoFalla).State = EntityState.Modified;
                r = db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return r;
        }

        //Metodo Eliminado Logico
        public int EliminarTipoFalla(int TipoFallaID)
        {
            int r = 0;
            try
            {
                TipoFalla tipoFalla = BuscarID(TipoFallaID);
                tipoFalla.Estado = 0;
                r = EditarTipoFalla(tipoFalla);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return r;
        }

        //Metodo Buscar ID
        public TipoFalla BuscarID(int TipoFallaID)
        {
            TipoFalla tipoFalla = null;
            try
            {
                if(TipoFallaID > 0 || TipoFallaID != 0)
                {
                    tipoFalla = db.TipoFallas.Find(TipoFallaID);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return tipoFalla;
        }
    }
}
