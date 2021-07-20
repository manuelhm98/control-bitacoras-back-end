using ControlBitacorasESFE.DAL;
using ControlBitacorasESFE.EL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlBitacorasESFE.BL
{
    public class PuestosTrabajoBL
    {
        //Instancia de los metodos DAL
        private PuestosTrabajoDAL PuestosTrabajoDAL = new PuestosTrabajoDAL();

        //Instancia Guardar
        public int GuardarPuestosTrabajo(PuestosTrabajo puestosTrabajo)
        {
            return PuestosTrabajoDAL.GuardarPuestosTrabajo(puestosTrabajo);
        }


        //Instancia Editar 
        public int EditarPuestosTrabajo(PuestosTrabajo puestosTrabajo)
        {
            return PuestosTrabajoDAL.EditarPuestosTrabajo(puestosTrabajo);
        }


        //Instancia Eliminar
        public int ElimarPuestosTrabajo(int PuestosTrabajoID)
        {
            return PuestosTrabajoDAL.EliminarPuestosTrabajo(PuestosTrabajoID);
        }
    }
}
