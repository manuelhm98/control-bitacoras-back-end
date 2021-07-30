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
    public class CpuBL
    {
        //Instancia de los metodos DAL
        private CpuDAL cpuDAL = new CpuDAL();

        //Instancia Guardar 
        public int GuardarCpu(Cpu cpu)
        {
            return cpuDAL.GuardarCpu(cpu);
        }


        //Instancia Editar 
        public int EditarCpu(Cpu cpu)
        {
            return cpuDAL.EditarCpu(cpu);
        }


        //Instancia Eliminar 
        public int EliminarCpu(int CpuID)
        {
            return cpuDAL.EliminarCpu(CpuID);
        }

        //BY ID 
        public Cpu buscarID(int id)
        {
            return cpuDAL.BuscarID(id);
        }
        //LIST PAGIN 
        public ListPagingCpu ListPaging(int page = 1, int pageSize = 5)
        {
            return cpuDAL.ListPaging(page, pageSize);
        }

        //LISTA CPU
        public List<Cpu> cpus()
        {
            return cpuDAL.cpus();
        } 
    }
}
