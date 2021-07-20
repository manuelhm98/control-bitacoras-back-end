using ControlBitacorasESFE.DAL;
using ControlBitacorasESFE.EL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlBitacorasESFE.BL
{
    public class ProcesadorBL
    {
        //Instancia de los metodos DAL
        private ProcesadorDAL procesadorDAL = new ProcesadorDAL();


        //Instancia Guardar
        public int GuardarProcesador(Procesador procesador)
        {
            return procesadorDAL.GuardarProcesador(procesador);
        }


        //Instancia Editar
        public int EditarProcesador(Procesador procesador)
        {
            return procesadorDAL.EditarProcesador(procesador);
        }


        //Instancia Eliminar 
        public int EliminarProcesador(int ProcesadorID)
        {
            return procesadorDAL.EliminaProcesador(ProcesadorID);
        }
    }
}
