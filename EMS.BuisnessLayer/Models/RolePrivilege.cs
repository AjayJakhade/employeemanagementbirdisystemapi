using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.BuisnessLayer.Models
{
    public class RolePrivilege : BaseEntity
    {
        [Key]
        public long roleprivilegeid { get; set; }
        public int roleid { get; set; }
        public int privilegeid { get; set; }
       
        public bool? canadd { get; set; } = false;
        public bool? canedit { get; set; } = false;
        public bool? candelete { get; set; } = false;
        public bool? canexport { get; set; } = false;
        public bool? canget { get; set; } = false;
    }
    
}
