using System;
using System.Collections.Generic;
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

        //Busqueda por ID
        public Usuario buscarId(int id)
        {
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
            var usuario = db.Usuarios.Where(d => d.Email == auth.Email && d.Pass == password).FirstOrDefault();
            
            if(usuario == null)
            {
                return null;
            }

            userData.Email = usuario.Email;
            userData.Token = GenerateToken(auth);
            return userData;
        }

        //Metodo Generar JWT
        public string GenerateToken(Auth auth)
        {
            string r = "";
            var token = TokenGenerator.GenerateTokenJwt(auth.Email);
            return r = token; 
        }




        public List<Usuario> listusuarios(int posicion, ref int totalpage)
        {
            totalpage =  db.Usuarios.Count();
            var list = (from Usuario in db.Usuarios where Usuario.Estado == 1 select Usuario).OrderBy(z => z.UsuarioID).Skip(posicion).Take(3).ToList();
            List<Usuario> usuarios = list;
            return usuarios;
        }

        public List<Usuario> getUsuarios(bool estado)
        {

            var list = from Usuario in db.Usuarios where Usuario.Estado == 1 select Usuario;
            return list.ToList();
        }

         
        public ListPaging  usuariosLista(int page = 1, int pageSize = 5)
        {
            var usuarios = (from Usuario in db.Usuarios where Usuario.Estado == 1 select Usuario).OrderBy(x => x.UsuarioID).Skip((page - 1) * pageSize)
                .Take(pageSize).ToList();
            int totalRegistros = db.Usuarios.Count();


            var model = new ListPaging();
            model.Usuarios = usuarios;
            model.paginaActual = page;
            model.TotalRegistros = totalRegistros / pageSize;




            if (model.TotalRegistros % 2 !=0)
            {
                model.TotalRegistros = Math.Truncate(model.TotalRegistros) + 1;
            }
            model.RegistroPorPagina = pageSize;
     
            return model;
        }

    }
}
