using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.BuisnessLayer.Models
{
    public class Salary : BaseEntity
    {
        [Key]
        public int SalaryId { get; set; }
        public int EmpId { get; set; }
        public decimal Amount { get; set; }
    }
}
