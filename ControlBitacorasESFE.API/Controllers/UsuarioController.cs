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


      //Metodo Guardar 
      [HttpPost]
      [Route("api/usuario/guardar")]
      public int Guardar(Usuario usuario)
        {
            
            return usuarioBL.Guardar(usuario);
        }

        //BUSCAR USUARIO ID
        [HttpGet]
        [Route("api/usuario/{id}")]
        public Usuario buscarUsuarioID(int id)
        {
            return usuarioBL.buscarUsuarioId(id);
        }

      //Metodo Login
        [HttpPost]
        [Route("login")]
        public Respuesta Login(Auth auth)
        {
            return usuarioBL.Login(auth);
        }

        [HttpGet]
        [Route("api/usuario/lista")]
        public List<Usuario> pageList(int? posicion)
        {
            if(posicion == null)
            {
                posicion = 0;
            }
            int totalRegistros = 0;
            List<Usuario> usuarios = usuarioBL.listaUsuario(posicion.GetValueOrDefault(), ref totalRegistros);
            return usuarios;
        }
        [HttpGet]
        [Route("api/usuario/listasuser")]
        public List<Usuario> GetPage(string busqueda, int? page)
        {

            List<Usuario> U;

            if (busqueda == null)
            {
                U = (from s in usuarioBL.getUsuarios(true) select s).ToList();
            }
            else
            {
                
                U = (from s in usuarioBL.getUsuarios(true)
                     where s.Nombre.ToLower().Contains(busqueda.ToLower())
                     select s).ToList();
            }
            U = U.OrderBy(s => s.Nombre).ToList();

            int pageSize = 10;
            int pageNumber = (page ?? 1);
            U.ToPagedList(pageNumber, pageSize);
            return U;
        }


        [HttpGet]
        [Route("api/usuario/usuarioLista")]
        public ListPaging usuariosLista(int page = 1, int pageSize = 5)
        {
            return usuarioBL.usuariosLista(page, pageSize);
        }
    }
}
