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
                    equipoArea.Estado = 1;
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

        //LIST PAGIN 
        public ListPagingEquipoArea listPaging(int page = 5, int pageSize = 5)
        {
            var equipoAreas = (from EquipoArea in db.EquipoAreas.Include(a => a.Area)
                               where EquipoArea.Estado == 1
                               select EquipoArea).OrderByDescending(x => x.EquipoAreaID).Skip((page - 1) * pageSize)
                               .Take(pageSize).ToList();

            int totalRegistros = (from EquipoArea in db.EquipoAreas
                                  where EquipoArea.Estado == 1
                                  select EquipoArea).Count();

            var model = new ListPagingEquipoArea();
            model.EquipoAreas = equipoAreas;
            model.paginaActual = page;
            model.TotalRegistros = totalRegistros / pageSize;

            if(model.TotalRegistros % 2 != 0)
            {
                model.TotalRegistros = Math.Truncate(model.TotalRegistros) + 1;
            }

            model.RegistroPorPagina = pageSize;

            return model; 
        }

        //LISTA EQUIPOAREAS
        public List<EquipoArea> equipoAreas()
        {
            var equipoAreas = (from EquipoArea in db.EquipoAreas.Include(a => a.Area)
                               where EquipoArea.Estado == 1
                               select EquipoArea).ToList();

            return equipoAreas;

        }
    }
}
