using EMS.BuisnessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.BuisnessLayer.Interface
{
    public interface IPrivilegeService
    {
        Task<BaseResponse> GetPrivilege(PrivilegeSearch privilegeSearch);
        Task<BaseResponse> CreatePrivilege(Privilege privilege);
        Task<BaseResponse> UpdatePrivilege(Privilege privilege);
        Task<BaseResponse> DeletePrivilege(int privilegeid);
    }
}
