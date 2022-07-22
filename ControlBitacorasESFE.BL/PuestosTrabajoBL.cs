using ControlBitacorasESFE.DAL;
using ControlBitacorasESFE.EL;
using ControlBitacorasESFE.EL.Middlewares;
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

        //LISTA PAGNG
        public ListPagingPuestosTrabajo listPaging(int page = 1, int pageSize = 5, string puesto = "",
            string area = "", string monitor = "", string ups = "", string cpu = "", string mueble = "")
        {
            return PuestosTrabajoDAL.listPaging(page, pageSize, puesto, area, monitor, ups, cpu, mueble);
        }

        //LISTA COUNT 

        public PaginCount puestosTrabajosCount()
        {
            return PuestosTrabajoDAL.puestosTrabajosCount();
        }

        //LISTA PUESTOS 
        public List<PuestosTrabajo> puestosTrabajos()
        {
            return PuestosTrabajoDAL.puestosTrabajos();
        }

        //BY ID 
        public PuestosTrabajo buscarId(int id)
        {
            return PuestosTrabajoDAL.BuscarID(id);
        }


    }
}
