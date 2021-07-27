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


        //Metodo Guardar Usuarios 

        public int Guardar(Usuario usuario)
        {
            return usuarioDAL.Guardar(usuario);
        }

        //EDITAR
        public int EditarUsuario(Usuario usuario)
        {
            return usuarioDAL.EditarUsuario(usuario);
        }


        //ELIMINAR
        public int EliminarUsuario(int id)
        {
            return usuarioDAL.EliminarUsuario(id);
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

        public ListPaging usuariosLista(int page = 1, int pageSize = 5)
        {
            return usuarioDAL.usuariosLista(page, pageSize);
        }
    }
}
