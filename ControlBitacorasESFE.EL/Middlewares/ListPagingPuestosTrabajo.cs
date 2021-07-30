using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlBitacorasESFE.EL.Middlewares
{
  public  class ListPagingPuestosTrabajo: PagingModel
    {
        public List<PuestosTrabajo> PuestosTrabajos { get; set; }
    }
}
