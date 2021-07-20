using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Referencias
using System.Data.Entity;
using ControlBitacorasESFE.EL;

namespace ControlBitacorasESFE.DAL
{
    public class RoleDAL
    {
        //Declaracion del contexto DB
        private ProjectContext db = new ProjectContext();

        public List<Role> listaRole()
        {
            return db.Roles.ToList();
        }
        //Metodo Guardar 
        public int Guardar(Role role)
        {
            int r = 0;
            try
            {
                if(role != null)
                {
                    db.Roles.Add(role);
                    r = db.SaveChanges();
                }
                return r;
            } catch
            {
                return r;
            }

        }

    }
}
