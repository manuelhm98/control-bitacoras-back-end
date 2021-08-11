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
                    falla.Estado = 1;
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

        //LISTA PAGING 

        public ListPagingFalla listPaging(int page = 1, int pageSize = 5)
        {
            var fallas = (from Falla in db.Fallas.Include(f => f.TipoFalla)
                          where Falla.Estado == 1
                          select Falla).OrderByDescending(x => x.FallaID).Skip((page - 1) * pageSize)
                          .Take(pageSize).ToList();

            int totalRegistros = (from Falla in db.Fallas where Falla.Estado == 1 select Falla).Count();

            var model = new ListPagingFalla();
            model.Fallas = fallas;
            model.paginaActual = page;
            model.TotalRegistros = totalRegistros / pageSize;

            if(model.TotalRegistros % 2 != 0)
            {
                model.TotalRegistros = Math.Truncate(model.TotalRegistros) + 1;
            }

            model.RegistroPorPagina = pageSize;

            return model;
        }

        //LISTA FALLA
        public List<Falla> fallas()
        {
            var fallas = (from Falla in db.Fallas
                          where Falla.Estado == 1
                          select Falla).ToList();

            return fallas;
        }
    }
}
