using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using PagedList;
//Referencias 
using ControlBitacorasESFE.BL;
using ControlBitacorasESFE.EL;
using ControlBitacorasESFE.EL.Login;


namespace ControlBitacorasESFE.API.Controllers
{
    public class UsuarioController : ApiController
    {
       
        // GET: api/Usuario
       UsuarioBL usuarioBL = new UsuarioBL();

        //USUARIOS
        [Authorize]
        [HttpGet]
        [Route("api/usuario")]
        public List<Usuario> usuarios()
        {
            return usuarioBL.usuarios();
        }

        //Metodo Guardar 
        [Authorize]
        [HttpPost]
        [Route("api/usuario")]
        public int Guardar(Usuario usuario)
        {
            return usuarioBL.Guardar(usuario);
        }

        //EDITAR
        [Authorize]
        [HttpPut]
        [Route("api/usuario")]
        public int editarUsuario(Usuario usuario)
        {
            return usuarioBL.EditarUsuario(usuario);
        }

        //ELIMINADI LOGICO
        [Authorize]
        [HttpDelete]
        [Route("api/usuario/{id}")]
        public int eliminarUsuario(int id)
        {
            return usuarioBL.EliminarUsuario(id);
        }

        [Authorize]
        [HttpGet]
        [Route("api/usuario/lista/")]
        public ListPaging usuariosLista(int page = 1, int pageSize = 5, string name = "", string rol = "")
        {
          
            return usuarioBL.usuariosLista(page, pageSize, name, rol);
        }

        //BUSCAR USUARIO ID
        [Authorize]         
        [HttpGet]                       
        [Route("api/usuario/{id}")]
        public Usuario buscarUsuarioID(int id)
        {
            return usuarioBL.buscarUsuarioId(id);
        }

        //Metodo Login
        [HttpPost]
        [Route("api/usuario/login")]
        public Respuesta Login(Auth auth)
        {
            return usuarioBL.Login(auth);
        }

    }
}
