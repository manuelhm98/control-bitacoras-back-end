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
    public class AreaDAL
    {
        //Declaracion del contexto 
        private ProjectContext db = new ProjectContext();

        //Metodo de lista 
        public List<Area> listaArea()
        {
            var areas = (from Area in db.Areas.Include(t => t.TipoArea)
                         .Include(u => u.Usuario)
                         where Area.Estado == 1
                         select Area).ToList();

            return areas;
        }

        //Metodo de guardar
        public int GuardarAreas(Area area)
        {
            int r = 0;
            try
            {
                if(area != null)
                {
                    area.Estado = 1;
                    db.Areas.Add(area);
                    r = db.SaveChanges();
                }
                return r;
            }
            catch (Exception ex)
            {
                throw  ex; 
            }
        }

        //Metodo de Editar
        public int EditarAreas(Area area)
        {
            int r = 0;
            try
            {
                var local = db.Set<Area>().Local.FirstOrDefault(f => f.AreaID == area.AreaID);
                if(local != null)
                {
                    db.Entry(local).State = EntityState.Detached;
                }
                db.Entry(area).State = EntityState.Modified;
                r = db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return r;
        }

        //Metodo Eliminado Logico 
        public int EliminarArea(int AreaID)
        {
            int r = 0;
            try
            {
                Area area = BuscarID(AreaID);
                area.Estado = 0;
                r = EditarAreas(area);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return r;
        }

        //Obtener ID
        public Area BuscarID(int AreaID)
        {
            Area area = null;
            try
            {
                if(AreaID > 0 || AreaID != 0)
                {
                    area = db.Areas.Find(AreaID);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return area;
        }

        //LIST PAGING 
        public ListPagingArea listPaging(int page = 1, int pageSize = 5)
        {
            var areas = (from Area in db.Areas.Include(t => t.TipoArea)
                         .Include(u => u.Usuario)
                         where Area.Estado == 1
                         select Area).OrderByDescending(x => x.AreaID)
                         .Skip((page - 1) * pageSize)
                         .Take(pageSize).ToList();

            int totalRegistros = (from Area in db.Areas.Include(t => t.TipoArea)
                         .Include(u => u.Usuario)
                                  where Area.Estado == 1
                                  select Area).Count();

            var model = new ListPagingArea();
            model.Areas = areas;
            model.paginaActual = page;
            model.TotalRegistros = (int)Math.Ceiling((double)totalRegistros / pageSize);
            model.RegistroPorPagina = pageSize;

            return model;
        }

        
    }
}
