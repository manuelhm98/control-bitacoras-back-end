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
   public  class BitacoraDAL
    {
        //Declaracion de contexto
        private ProjectContext db = new ProjectContext();


        //Metodo de guardar
        public int guardarBitacora(Bitacora bitacora)
        {
            int r = 0;
            try
            {
                if(bitacora != null)
                {
                    bitacora.Estado = 1;
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
        public int editarBitacoras(Bitacora bitacora)
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
        public int eliminarBitacora(int BitacoraID)
        {
            int r = 0;
            try
            {
                Bitacora bitacora = buscarId(BitacoraID);
                bitacora.Estado = 0;
                r = editarBitacoras(bitacora);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return r;
        }

        //Obtener ID
        public Bitacora buscarId(int BitacoraID)
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
        //PAGINACION
        public ListPagingBitacora bitacorasLista(int page = 1, int pageSize = 5)
        {
            var bitacoras = (from Bitacora in db.Bitacoras.Include(p => p.PuestosTrabajo.Area).Include(u => u.Usuario).Include(f => f.Falla)
                             where Bitacora.Estado == 1
                             select Bitacora).OrderByDescending(x => x.BitacoraID).Skip((page - 1) * pageSize)
                             .Take(pageSize).ToList();
            int totalRegistros = (from Bitacora in db.Bitacoras where Bitacora.Estado == 1 select Bitacora).Count();

            var model = new ListPagingBitacora();
            model.Bitacoras = bitacoras;
            model.paginaActual = page;
            model.TotalRegistros = (int)Math.Ceiling((double)totalRegistros / pageSize);
            model.RegistroPorPagina = pageSize;

            return model;
        }
        //LISTA
        public List<Bitacora> bitacoras()
        {
            var bitacoras = (from Bitacora in db.Bitacoras.Include(p => p.PuestosTrabajo).Include(u => u.Usuario).Include(f => f.Falla)
                             where Bitacora.Estado == 1
                             select Bitacora).OrderByDescending(x => x.BitacoraID).ToList();

            return bitacoras;
         //   return db.Bitacoras.ToList();
        }
    }
}
