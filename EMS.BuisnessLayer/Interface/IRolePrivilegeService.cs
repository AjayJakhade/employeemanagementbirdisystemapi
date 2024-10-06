using EMS.BuisnessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.BuisnessLayer.Interface
{
    public interface IRolePrivilegeService
    {
        Task<BaseResponse> GetRolePrivilege();
        Task<BaseResponse> CreateRolePrivilege(RolePrivilege rolePrivilege);
        Task<BaseResponse> UpdateRolePrivilege(RolePrivilege rolePrivilege);
        Task<BaseResponse> DeleteRolePrivilege(long roleprivilegeId);
    }
}
