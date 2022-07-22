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
                    ups.Estado = 1;
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
        public Ups BuscarID(int id)
        {
            Ups ups = null;
            try  
            {
                if (id > 0 || id != 0)
                {
                    ups = db.Upss.Find(id);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ups;
        }

        //LIST PAGING 
        public ListPagingUps listPaging(int page = 1, int pageSize = 5, string code = "")
        {
            var ups = (from Ups in db.Upss
                       where Ups.Estado == 1 && Ups.Codigo.Contains(code)
                       select Ups).OrderByDescending(x => x.UpsID)
                       .Skip((page - 1) * pageSize)
                       .Take(pageSize).ToList();

            int totalRegistros = (from Ups in db.Upss
                                  where Ups.Estado == 1
                                  select Ups).Count();

            var model = new ListPagingUps();
            model.Ups = ups;
            model.paginaActual = page;
            model.TotalRegistros = (int)Math.Ceiling((double)totalRegistros / pageSize);
            model.RegistroPorPagina = pageSize;

            return model;
        }

        //LISTA UPS 
        public List<Ups> ups()
        {
            var ups = (from Ups in db.Upss
                       where Ups.Estado == 1
                       select Ups).ToList();

            return ups;
        }

    }
}
