using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace ControlBitacorasESFE.EL
{
   public class Role
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Int16 RoleID { get; set; }
        [Required]
        [DisplayName("Tipo de rol")]
        public string Roles { get; set; }
        [Required]
        public int Estado { get; set; }

       
       
    }
}
