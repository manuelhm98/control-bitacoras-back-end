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
    public class TipoAreaDAL
    {
        //Declaracion de contexto
        private ProjectContext db = new ProjectContext();

        //Metodo Guardar
        public int GuardarTipoArea(TipoArea tipoArea)
        {
            int r = 0;
            try
            {
                if (tipoArea != null)
                {
                    tipoArea.Estado = 1;
                    db.TipoAreas.Add(tipoArea);
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
        public int EditarTipoArea(TipoArea tipoArea)
        {
            int r = 0;
            try
            {
                var local = db.Set<TipoArea>().Local.FirstOrDefault(f => f.TipoAreaID == tipoArea.TipoAreaID);
                if (local != null)
                {
                    db.Entry(local).State = EntityState.Detached;
                }
                db.Entry(tipoArea).State = EntityState.Modified;
                r = db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return r;
        }

        //Metodo Eliminado Logico
        public int EliminarTipoArea(int TipoAreaID)
        {
            int r = 0;
            try
            {
                TipoArea tipoArea = BuscarID(TipoAreaID);
                tipoArea.Estado = 0;
                r = EditarTipoArea(tipoArea);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return r;
        }


        //Metodo Buscar ID
        public TipoArea BuscarID(int TipoAreaID)
        {
            TipoArea tipoArea = null;
            try
            {
                if (TipoAreaID > 0 || TipoAreaID != 0)
                {
                    tipoArea = db.TipoAreas.Find(TipoAreaID);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return tipoArea;
        }

        //LIST PAGIN
        public ListPagingTipoArea listPaging(int page = 1, int pageSize = 5, string tipo = "")
        {
            var tipoAreas = (from TipoArea in db.TipoAreas where TipoArea.Estado == 1 && TipoArea.Tipo.Contains(tipo)
                             select TipoArea)
                            .OrderByDescending(x => x.TipoAreaID).Skip((page - 1) * pageSize)
                            .Take(pageSize).ToList();

            int totalRegistros = (from TipoArea in db.TipoAreas where TipoArea.Estado == 1 select TipoArea).Count();

            var model = new ListPagingTipoArea
            {
                TipoAreas = tipoAreas,
                paginaActual = page,
                TotalRegistros = (int)Math.Ceiling((double)totalRegistros / pageSize),
                RegistroPorPagina = pageSize
            };

            return model;
        }

        //LISTA TIPO AREA
        public List<TipoArea> tipoAreas()
        {
            var tipoAreas = (from TipoArea in db.TipoAreas where TipoArea.Estado == 1 select TipoArea).ToList();

            return tipoAreas;
        }
    }
}
