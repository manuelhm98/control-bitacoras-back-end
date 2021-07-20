using ControlBitacorasESFE.EL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlBitacorasESFE.DAL
{
    public class EquipoAreaDAL
    {
        //Declaracion del contexto
        private ProjectContext db = new ProjectContext();

        //Metodo Lista 
        
        //Metodo Guardar 
        public int GuardarEquipoArea(EquipoArea equipoArea)
        {
            int r = 0;
            try
            {
                if(equipoArea != null)
                {
                    db.EquipoAreas.Add(equipoArea);
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
        public int EditarEquipoArea(EquipoArea equipoArea)
        {
            int r = 0;
            try
            {
                var local = db.Set<EquipoArea>().Local.FirstOrDefault(f => f.EquipoAreaID == equipoArea.EquipoAreaID);
                if(local != null)
                {
                    db.Entry(local).State = EntityState.Detached;
                }
                db.Entry(equipoArea).State = EntityState.Modified;
                r = db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return r;
        }

       //Metodo Eliminado Logico 
       public int EliminarEquipoArea(int EquipoAreaID)
        {
            int r = 0;
            try
            {
                EquipoArea equipoArea = BuscarID(EquipoAreaID);
                equipoArea.Estado = 0;
                r = EditarEquipoArea(equipoArea);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return r;
        }

        //Metodo Buscar ID
        public EquipoArea BuscarID(int EquipoAreaID)
        {
            EquipoArea equipoArea = null;
            try
            {
                if(EquipoAreaID > 0 || EquipoAreaID != 0)
                {
                    equipoArea = db.EquipoAreas.Find(EquipoAreaID);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return equipoArea;
        }
    }
}
