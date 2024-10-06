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
    public class PrivilegeRepository:IPrivilegeService
    {
        private readonly EMSDBContext _EMSDBContext;
        public PrivilegeRepository(EMSDBContext EMSDBContext)
        {
            _EMSDBContext = EMSDBContext;

        }

        public async Task<BaseResponse> CreatePrivilege(Privilege privilege)
        {
            BaseResponse response = new BaseResponse();
            try
            {
                await _EMSDBContext.privilege.AddAsync(privilege);
                response.result = await _EMSDBContext.SaveChangesAsync();
                if (response.result != null)
                {
                    response.Message = "Privilege is Created";
                    response.IsSuccess = true;
                    response.Status = "200";
                }
                else
                {
                    response.Message = "Error In Saving Privilege";
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

      

        public async Task<BaseResponse> DeletePrivilege(int privilegeId)
        {
            BaseResponse response = new BaseResponse();
            try
            {

                var privilege = await _EMSDBContext.privilege.FindAsync(privilegeId);

                if (privilege == null)
                {
                    response.Message = "User not found.";
                    response.IsSuccess = false;
                    response.Status = "500";
                    return response;
                }


                _EMSDBContext.privilege.Remove(privilege);


                await _EMSDBContext.SaveChangesAsync();

                response.Message = "Privilege deleted successfully.";
                response.IsSuccess = true;
                response.Status = "200";
            }
            catch (Exception ex)
            {

                response.Message = "An error occurred while deleting the Privilege.";
                response.IsSuccess = false;
                response.Status = "500";
            }

            return response;
        }

       

        public async Task<BaseResponse> GetPrivilege(PrivilegeSearch privilegeSearch)
        {
            BaseResponse response = new BaseResponse();
            try
            {
                var query = _EMSDBContext.privilege.AsQueryable();


                if (!string.IsNullOrWhiteSpace(privilegeSearch.PrivilegeName))
                {
                    query = query.Where(x => x.privilegename.Contains(privilegeSearch.PrivilegeName));
                }

                if (!string.IsNullOrWhiteSpace(Convert.ToString(privilegeSearch.IsActive)))
                {
                    query = query.Where(x => x.IsActive==privilegeSearch.IsActive);
                }


                response.result = await query.ToListAsync();
                if (response.result != null)
                {
                    response.Message = "Privilege Success";
                    response.IsSuccess = true;
                    response.Status = "200";
                }
                else
                {
                    response.Message = "Error In Get Privilege";
                    response.IsSuccess = false;
                    response.Status = "500";
                }
            }
            catch (Exception ex)
            {
                response.Message = "Error In Get Privilege";
                response.IsSuccess = false;
                response.Status = "500";
            }
            return response;
        }

       

        public async Task<BaseResponse> UpdatePrivilege(Privilege privilege)
        {
            BaseResponse response = new BaseResponse();
            try
            {
                var existingprivilege = await _EMSDBContext.privilege.FindAsync(privilege.privilegeid);

                if (existingprivilege == null)
                {
                    response.Message = "User not found.";
                    response.IsSuccess = false;
                    response.Status = "500";
                    return response;
                }

                existingprivilege.privilegeid = privilege.privilegeid;
                existingprivilege.privilegename = privilege.privilegename;
              


                await _EMSDBContext.SaveChangesAsync();
                response.result = privilege.privilegeid;
                response.Message = "Privilege updated successfully.";
                response.IsSuccess = true;
                response.Status = "200";
            }
            catch (Exception ex)
            {

                response.Message = "An error occurred while updating the Privilege.";
                response.IsSuccess = false;
                response.Status = "500";
            }
            return response;
        }

      
    }
}
