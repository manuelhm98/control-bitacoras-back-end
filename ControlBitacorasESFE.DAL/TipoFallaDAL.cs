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
                    tipoFalla.Estado = 1;
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

        //LIST PAGING 
        public ListPagingTipoFalla ListPaging(int page = 1, int pageSize = 5)
        {
            var tipoFalla = (from TipoFalla in db.TipoFallas
                             where TipoFalla.Estado == 1
                             select TipoFalla).OrderByDescending(x => x.TipoFallaID)
                             .Skip((page - 1) * pageSize)
                             .Take(pageSize).ToList();

            int totalRegistros = (from TipoFalla in db.TipoFallas
                                  where TipoFalla.Estado == 1
                                  select TipoFalla).Count();

            var model = new ListPagingTipoFalla();
            model.TipoFallas = tipoFalla;
            model.paginaActual = page;
            model.TotalRegistros = totalRegistros / pageSize;

            if(model.TotalRegistros % 2 != 0)
            {
                model.TotalRegistros = Math.Truncate(model.TotalRegistros) + 1;
            }

            model.RegistroPorPagina = pageSize;

            return model;
        }

        //LIST TIPO FALLA
        public List<TipoFalla> tipoFallas()
        {
            var tipoFalla = (from TipoFalla in db.TipoFallas
                             where TipoFalla.Estado == 1
                             select TipoFalla).ToList();

            return tipoFalla;
        }


    }
}
