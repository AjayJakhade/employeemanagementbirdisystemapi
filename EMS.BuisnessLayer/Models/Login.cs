using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.BuisnessLayer.Models
{
    public class Login:BaseEntity
    {
        public long LoginId { get; set; }
        public long UserId { get; set; }
        public DateTime LoginDate { get; set; }
        public DateTime LogOutDate { get; set; }
    }
    public class ReturnJWT
    {
        public long UserId { get; set; }
        public string UserName { get; set; }
        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public string Token { get; set; }
       

        public IEnumerable<PrivilegeDTO> Privilages { get; set; }
    }
    public class PrivilegeDTO
    {
        public int PrivilegeId { get; set; }
        public string? PrivilegeName { get; set; }
     
        public bool? CanAdd { get; set; }
        public bool? CanEdit { get; set; }
        public bool? CanGet { get; set; }
        public bool? CanDelete { get; set; }
        public bool? CanExport { get; set; }
      
    }
}
