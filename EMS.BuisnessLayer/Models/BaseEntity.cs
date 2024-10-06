using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.BuisnessLayer.Models
{
    public class BaseEntity
    {
        public DateTime? CreatedOn { get; set; } = DateTime.Now;
        public long EntryBy { get; set; }
        public bool? IsActive { get; set; } = true;
    }
}
