using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.BuisnessLayer.Models
{
    public class Department:BaseEntity
    {
        [Key]
        public int DeptId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
