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
    public class ProcesadorDAL
    {
        //Declaracion del contexto
        private ProjectContext db = new ProjectContext();

        //Metodo Guardar
        public int GuardarProcesador(Procesador procesador)
        {
            int r = 0;
            try
            {
                if (procesador != null)
                {
                    procesador.Estado = 1;
                    db.Procesadors.Add(procesador);
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
        public int EditarProcesador(Procesador procesador)
        {
            int r = 0;
            try
            {
                var local = db.Set<Procesador>().Local.FirstOrDefault(f => f.ProcesadorID == procesador.ProcesadorID);
                if (local != null)
                {
                    db.Entry(local).State = EntityState.Detached;
                }
                db.Entry(procesador).State = EntityState.Modified;
                r = db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return r;
        }

        //Metodo Eliminado Logico 
        public int EliminaProcesador(int ProcesadorID)
        {
            int r = 0;
            try
            {
                Procesador procesador = BuscarID(ProcesadorID);
                procesador.Estado = 0;
                r = EditarProcesador(procesador);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return r;
        }

        //Metodo Buscar ID
        public Procesador BuscarID(int ProcesadorID)
        {
            Procesador procesador = null;
            try
            {
                if (ProcesadorID > 0 || ProcesadorID != 0)
                {
                    procesador = db.Procesadors.Find(ProcesadorID);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return procesador;
        }

        public ListPagingProcesador listPaging(int page = 1, int pageSize = 5, string proce = "")
        {
            var procesadors = (from Procesador in db.Procesadors
                               where Procesador.Estado == 1 && (Procesador.Modelo + Procesador.Velocidad).Contains(proce)
                               select Procesador)
                               .OrderByDescending(x => x.ProcesadorID)
                               .Skip((page - 1) * pageSize)
                               .Take(pageSize).ToList();

            int totalRegistros = (from Procesador in db.Procesadors
                                  where Procesador.Estado == 1
                                  select Procesador).Count();

            var model = new ListPagingProcesador();
            model.Procesadors = procesadors;
            model.paginaActual = page;
            model.TotalRegistros = (int)Math.Ceiling((double)totalRegistros / pageSize);
            model.RegistroPorPagina = pageSize;

            return model;
        }

        //LISTA PROCESADOR 
        public List<Procesador> procesadors()
        {
            var procesadors = (from Procesador in db.Procesadors
                               where Procesador.Estado == 1
                               select Procesador).ToList();

            return procesadors;
        }
    }
}
