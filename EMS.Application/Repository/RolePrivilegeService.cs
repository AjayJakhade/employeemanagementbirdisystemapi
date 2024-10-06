using EMS.BuisnessLayer.Interface;
using EMS.BuisnessLayer.Models;
using EMS.DAL.DAL;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.Application.Repository
{
    public class RolePrivilegeService : IRolePrivilegeService
    {
        private readonly EMSDBContext _EMSDBContext;
        public RolePrivilegeService(EMSDBContext EMSDBContext)
        {
            _EMSDBContext = EMSDBContext;

        }
        public async Task<BaseResponse> CreateRolePrivilege(RolePrivilege rolePrivilege)
        {
            BaseResponse response = new BaseResponse();
            try
            {
                await _EMSDBContext.roleprivilege.AddAsync(rolePrivilege);
                response.result = await _EMSDBContext.SaveChangesAsync();
                if (response.result != null)
                {
                    response.Message = "rolePrivilege is Created";
                    response.IsSuccess = true;
                    response.Status = "200";
                }
                else
                {
                    response.Message = "Error In Saving rolePrivilege";
                    response.IsSuccess = false;
                    response.Status = "404";
                }
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.IsSuccess = false;
                response.Status = "500";
            }
            return response;
        }

        public async Task<BaseResponse> DeleteRolePrivilege(long roleprivilegeId)
        {
            BaseResponse response = new BaseResponse();
            try
            {

                var roleprivilege = await _EMSDBContext.roleprivilege.FindAsync(roleprivilegeId);

                if (roleprivilege == null)
                {
                    response.Message = "User not found.";
                    response.IsSuccess = false;
                    response.Status = "500";
                    return response;
                }


                _EMSDBContext.roleprivilege.Remove(roleprivilege);


                await _EMSDBContext.SaveChangesAsync();

                response.Message = "rolePrivilege deleted successfully.";
                response.IsSuccess = true;
                response.Status = "200";
            }
            catch (Exception ex)
            {

                response.Message = "An error occurred while deleting the rolePrivilege.";
                response.IsSuccess = false;
                response.Status = "500";
            }

            return response;
        }

        public async  Task<BaseResponse> GetRolePrivilege()
        {
            BaseResponse response = new BaseResponse();
            try
            {
               
                var roleprivilegequery = from rolesprivilege in _EMSDBContext.roleprivilege
                                         join roles in _EMSDBContext.rolemaster on rolesprivilege.roleid equals roles.roleid
                                         join privilege in _EMSDBContext.privilege on rolesprivilege.privilegeid equals privilege.privilegeid
                                         select new RolePrivilegeDTO()
                                         {
                                             roleprivilegeid=rolesprivilege.roleprivilegeid,
                                             roleid=roles.roleid,
                                             rolename=roles.rolename,
                                             privilegeid=privilege.privilegeid,
                                             privilegename=privilege.privilegename,
                                             canadd=rolesprivilege.canadd,
                                             candelete=rolesprivilege.candelete,
                                             canedit=rolesprivilege.canedit,
                                             canexport=rolesprivilege.canexport,
                                             canget=rolesprivilege.canget,
                                             IsActive=rolesprivilege.IsActive
                                         };

                response.result = await roleprivilegequery.ToListAsync();
                if (response.result != null)
                {
                    response.Message = "rolePrivilege Success";
                    response.IsSuccess = true;
                    response.Status = "200";
                }
                else
                {
                    response.Message = "Error In Get rolePrivilege";
                    response.IsSuccess = false;
                    response.Status = "500";
                }
            }
            catch (Exception ex)
            {
                response.Message = "Error In Get rolePrivilege";
                response.IsSuccess = false;
                response.Status = "500";
            }
            return response;
        }

        public async Task<BaseResponse> UpdateRolePrivilege(RolePrivilege rolePrivilege)
        {
            BaseResponse response = new BaseResponse();
            try
            {
                var existingroleprivilege = await _EMSDBContext.roleprivilege.FindAsync(rolePrivilege.roleprivilegeid);

                if (existingroleprivilege == null)
                {
                    response.Message = "roleprivilege not found.";
                    response.IsSuccess = false;
                    response.Status = "500";
                    return response;
                }

                existingroleprivilege.roleprivilegeid = rolePrivilege.roleprivilegeid;
                existingroleprivilege.roleid = rolePrivilege.roleid;
                existingroleprivilege.privilegeid = rolePrivilege.privilegeid;
                existingroleprivilege.canadd = rolePrivilege.canadd;
                existingroleprivilege.canget = rolePrivilege.canget;
                existingroleprivilege.canedit = rolePrivilege.canedit;
                existingroleprivilege.canexport = rolePrivilege.canexport;
                existingroleprivilege.candelete = rolePrivilege.candelete;




                await _EMSDBContext.SaveChangesAsync();
                response.result = rolePrivilege.roleprivilegeid;
                response.Message = "rolePrivilege updated successfully.";
                response.IsSuccess = true;
                response.Status = "200";
            }
            catch (Exception ex)
            {

                response.Message = "An error occurred while updating the rolePrivilege.";
                response.IsSuccess = false;
                response.Status = "500";
            }
            return response;
        }
    }
}
