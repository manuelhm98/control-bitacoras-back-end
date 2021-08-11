using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlBitacorasESFE.EL.Middlewares
{
   public class ListPagingTipoArea: PagingModel
    {
        public List<TipoArea> TipoAreas { get; set; }
    }
}
