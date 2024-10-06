using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.BuisnessLayer.Models
{
    public class UserMaster : BaseEntity
    {
        [Key]
        public long userid { get; set; }
        public string username { get; set; }
        public string email { get; set; }
        public string mobile { get; set; }
        public string password { get; set; }
        public int roleid { get; set; }
      

    }
    public class UserSearch
    {
      
        public string? UserName { get; set; }
        public string? Email { get; set; }
       
        
    }
}
