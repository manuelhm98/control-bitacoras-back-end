using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlBitacorasESFE.EL
{
    public class PagingModel
    {
        public int paginaActual { get; set; }
        public decimal TotalRegistros { get; set; }
        public int RegistroPorPagina { get; set; }

    }
}
