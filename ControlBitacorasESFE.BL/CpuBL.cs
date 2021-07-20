using ControlBitacorasESFE.DAL;
using ControlBitacorasESFE.EL;
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
    }
}
