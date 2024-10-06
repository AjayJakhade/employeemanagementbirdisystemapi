using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.BuisnessLayer.Models
{
    public class Privilege : BaseEntity
    {
        [Key]
        public int privilegeid { get; set; }
        public string privilegename { get; set; }

    }
    public class PrivilegeSearch
    {
        public string? PrivilegeName { get; set; }
        public bool? IsActive { get; set; }
    }
}
