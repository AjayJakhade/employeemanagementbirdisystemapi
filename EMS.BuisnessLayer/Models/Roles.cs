using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.BuisnessLayer.Models
{
    public class RoleMaster:BaseEntity
    {
        [Key]
        public int roleid { get; set; }
        public string rolename { get; set; }
    }
}
