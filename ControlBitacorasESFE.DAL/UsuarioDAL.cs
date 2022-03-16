using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ControlBitacorasESFE.EL;
using ControlBitacorasESFE.EL.Login;
using PracticaCRUD.DAL;

namespace ControlBitacorasESFE.DAL
{
    public class UsuarioDAL
    {
        //Declaracion del contexto DB
        private ProjectContext db = new ProjectContext();

       
        //Metodo Guardar Usuarios 
        public int Guardar(Usuario usuario)
        {
            int r = 0;
            try
            {
                if (usuario != null)
                {
                    usuario.Pass = Sha256.GetSHA256(usuario.Pass);
                    usuario.Estado = 1;
                    db.Usuarios.Add(usuario);
                    r = db.SaveChanges();
                }
                return r;
            }
            catch
            {
                return 0;
            }

        }
        //Metodo de Editar
        public int EditarUsuario(Usuario usuario)
        {
            int r = 0;
            try
            {
                var local = db.Set<Usuario>().Local.FirstOrDefault(f => f.UsuarioID == usuario.UsuarioID);
                if (local != null)
                {
                    db.Entry(local).State = EntityState.Detached;
                }
                db.Entry(usuario).State = EntityState.Modified;
                r = db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return r;
        }

        //Metodo Eliminado Logico 
        public int EliminarUsuario(int id)
        {
            int r = 0;
            try
            {
                Usuario usuario = buscarId(id);
                usuario.Estado = 0;
                r = EditarUsuario(usuario);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return r;
        }


        //Busqueda por ID
        public Usuario buscarId(int id)
        {
            //
            Usuario usuario = null;
            try
            {
                if (id > 0 || id != 0)
                {
                    usuario = db.Usuarios.Find(id);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return usuario;
        }

        //Metodo Login 
        public Respuesta Login(Auth auth)
        {
            Respuesta respuesta = new Respuesta();
            var user = Validar(auth);

            if(user == null)
            {
                respuesta.Exito = 0;
                respuesta.Mensaje = "Usuario o contraseña incorrectas";
                return respuesta;

            }

            respuesta.Exito = 1;
            respuesta.Data = user;

            return respuesta;
        }

        //Metodo para validar Email y Pass
        public UserData Validar(Auth auth)
        {
            UserData userData = new UserData();
            string password = Sha256.GetSHA256(auth.Pass);
            var usuario = db.Usuarios.Include(r => r.Role).Where(d => d.Email == auth.Email && d.Pass == password).FirstOrDefault();
            
            if(usuario == null)
            {
                return null;
            }

            userData.Id = usuario.UsuarioID;
            userData.Roles = usuario.Role.Roles;
            userData.Token = GenerateToken(auth, userData);
            return userData;
        }

        //Metodo Generar JWT
        public string GenerateToken(Auth auth, UserData userData)
        {
            string r = "";
            var token = TokenGenerator.GenerateTokenJwt(auth.Email, userData.Roles, userData.Id);
            return r = token; 
        }

        //Paginacion
        public ListPaging  usuariosLista(int page = 1, int pageSize = 5, string name = "", string rol = "")
        {
     

            var usuarios = (from Usuario in db.Usuarios.Include(r => r.Role) 
                           where Usuario.Estado == 1  && (Usuario.Nombre + Usuario.Apellido).Contains(name)  && Usuario.Role.Roles.Contains(rol) select Usuario)
                .OrderByDescending(x => x.UsuarioID).Skip((page - 1) * pageSize)
                .Take(pageSize).ToList();
            int totalRegistros = (from Usuario in db.Usuarios where Usuario.Estado == 1 select Usuario).Count();

            var model = new ListPaging();
            model.Usuarios = usuarios;
            model.paginaActual = page;
            model.TotalRegistros = totalRegistros / pageSize;



            if (model.TotalRegistros % 2 != 0)
            {
                model.TotalRegistros = Math.Truncate(model.TotalRegistros) + 1;
            }
            model.RegistroPorPagina = pageSize;
     
            return model;
        }

        public List<Usuario> usuarios()
        {
            var usuarios = (from Usuario in db.Usuarios.Include(r => r.Role)
                            where Usuario.Estado == 1
                            select Usuario)
                            .OrderByDescending(x => x.UsuarioID).ToList();

            return usuarios;

        }

    }
}
