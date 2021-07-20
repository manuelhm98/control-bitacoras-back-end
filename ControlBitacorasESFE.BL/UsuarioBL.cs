using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Referencias 
using ControlBitacorasESFE.EL;
using ControlBitacorasESFE.DAL;
using ControlBitacorasESFE.EL.Login;

namespace ControlBitacorasESFE.BL
{
    public class UsuarioBL
    {
        //Intancia de la clase Usuarios DAL
        UsuarioDAL usuarioDAL = new UsuarioDAL();

        public List<Usuario> listaUsuario(int posicion,ref int totalpage)
        {
            return usuarioDAL.listusuarios(posicion, ref totalpage);
        }


        //Metodo Guardar Usuarios 

        public int Guardar(Usuario usuario)
        {
            return usuarioDAL.Guardar(usuario);
        }

        //BUSCAR POR ID
        public Usuario buscarUsuarioId(int id)
        {
            return usuarioDAL.buscarId(id);
        }

        //Metodo Login 
        public Respuesta Login(Auth auth)
        {
            return usuarioDAL.Login(auth);
        }

        public List<Usuario> getUsuarios(bool estado)
        {
            return usuarioDAL.getUsuarios(estado);
        }
        public ListPaging usuariosLista(int page = 1, int pageSize = 5)
        {
            return usuarioDAL.usuariosLista(page, pageSize);
        }
    }
}
