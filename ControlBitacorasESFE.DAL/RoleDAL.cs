using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Referencias
using System.Data.Entity;
using ControlBitacorasESFE.EL;
using ControlBitacorasESFE.EL.Middlewares;

namespace ControlBitacorasESFE.DAL
{
    public class RoleDAL
    {
        //Declaracion del contexto DB
        private ProjectContext db = new ProjectContext();

        //List ROLES
        public List<Role> listaRol()
        {
            return db.Roles.ToList();
        }
        //Paginacion
        public ListPaginRol RoleLista(int page = 1, int pageSize = 5)
        {
            var role = (from Role in db.Roles where Role.Estado == 1 select Role).OrderByDescending(x => x.RoleID).Skip((page - 1) * pageSize)
                .Take(pageSize).ToList();
            int totalRegistros = (from Role in db.Roles where Role.Estado == 1 select Role).Count();


            var model = new ListPaginRol();
            model.Roles = role;
            model.paginaActual = page;
            model.TotalRegistros = totalRegistros / pageSize;



            if (model.TotalRegistros % 2 != 0)
            {
                model.TotalRegistros = Math.Truncate(model.TotalRegistros) + 1;
            }
            model.RegistroPorPagina = pageSize;

            return model;
        }
        //Metodo Guardar 
        public int Guardar(Role role)
        {
            int r = 0;
            try
            {
                if(role != null)
                {
                    role.Estado = 1;
                    db.Roles.Add(role);
                    r = db.SaveChanges();
                }
                return r;
            } catch
            {
                return r;
            }

        }

        //Metodo de Editar
        public int EditarRole(Role role)
        {
            int r = 0;
            try
            {
                var local = db.Set<Role>().Local.FirstOrDefault(f => f.RoleID == role.RoleID);
                if (local != null)
                {
                    db.Entry(local).State = EntityState.Detached;
                }
                db.Entry(role).State = EntityState.Modified;
                r = db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return r;
        }

        //Busqueda por ID
        public Role buscarId(int id)
        {
            //
            Role role = null;
            try
            {
                if (id > 0 || id != 0)
                {
                    role = db.Roles.Find(id);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return role;
        }

        //Metodo Eliminado Logico 
        public int ElimiarRole(int id)
        {
            int r = 0;
            try
            {
                Role role = buscarId(id);
                role.Estado = 0;
                r = EditarRole(role);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return r;
        }

    }
}
