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
    public class UserRepository : IUserService
    {
        private readonly EMSDBContext _EMSDBContext;
        public UserRepository(EMSDBContext EMSDBContext)
        {
            _EMSDBContext = EMSDBContext;
            
        }
        public async Task<BaseResponse> CreateUsers(UserMaster userMaster)
        {
          BaseResponse response = new BaseResponse();
            try
            {
                await _EMSDBContext.usermaster.AddAsync(userMaster);
                response.result=  await _EMSDBContext.SaveChangesAsync();
                if(response.result!=null)
                {
                    response.Message = "User is Created";
                    response.IsSuccess = true;
                    response.Status = "200";
                }
                else
                {
                    response.Message = "Error In Saving Users";
                    response.IsSuccess = false;
                    response.Status = "404";
                }
            }
            catch(Exception ex)
            {
                response.Message = ex.Message;
                response.IsSuccess = false;
                response.Status = "500";
            }
            return response;
        }

        public async Task<BaseResponse> DeleteUsers(long userId)
        {
            BaseResponse response = new BaseResponse();
            try
            {
                
                var user = await _EMSDBContext.usermaster.FindAsync(userId);

                if (user == null)
                {
                    response.Message = "User not found.";
                    response.IsSuccess = false;
                    response.Status = "500"; 
                    return response;
                }

               
                _EMSDBContext.usermaster.Remove(user);

               
                await _EMSDBContext.SaveChangesAsync();

                response.Message = "User deleted successfully.";
                response.IsSuccess = true;
                response.Status = "200";
            }
            catch (Exception ex)
            {
                
                response.Message = "An error occurred while deleting the user.";
                response.IsSuccess = false;
                response.Status = "500"; 
            }

            return response;
        }

        public async Task<BaseResponse> GetUsers(UserSearch userSearch)
        {
            BaseResponse response = new BaseResponse();
            try
            {
                var query = from users in _EMSDBContext.usermaster
                            join roles in _EMSDBContext.rolemaster on users.roleid equals roles.roleid
                            select new
                            {
                                users.userid,
                                users.username,
                                users.email,
                                users.mobile,
                                roles.roleid,
                                roles.rolename

                            };

               
                if (!string.IsNullOrWhiteSpace(userSearch.UserName))
                {
                    query = query.Where(x => x.username.Contains(userSearch.UserName));
                }

                if (!string.IsNullOrWhiteSpace(userSearch.Email))
                {
                    query = query.Where(x => x.email.Contains(userSearch.Email));
                }

               
                response.result = await query.ToListAsync();
                if (response.result != null)
                {
                    response.Message = "User Success";
                    response.IsSuccess = true;
                    response.Status = "200";
                }
                else
                {
                    response.Message = "Error In Get Users";
                    response.IsSuccess = false;
                    response.Status = "500";
                }
            }
            catch(Exception ex)
            {
                response.Message = "Error In Get Users";
                response.IsSuccess = false;
                response.Status = "500";
            }
            return response;
        }

        public async Task<BaseResponse> UpdateUsers(UserMaster userMaster)
        {
           BaseResponse response=new BaseResponse();
            try
            {
                var existingUser = await _EMSDBContext.usermaster.FindAsync(userMaster.userid);

                if (existingUser == null)
                {
                    response.Message = "User not found.";
                    response.IsSuccess = false;
                    response.Status = "500"; 
                    return response;
                }

                existingUser.userid=userMaster.userid;
                existingUser.username = userMaster.username; 
                existingUser.email = userMaster.email;
                existingUser.mobile=userMaster.mobile;
                
                existingUser.roleid=userMaster.roleid;

               
                await _EMSDBContext.SaveChangesAsync();
                response.result = userMaster.userid;
                response.Message = "User updated successfully.";
                response.IsSuccess = true;
                response.Status = "200";
            }
            catch (Exception ex)
            {
       
            response.Message = "An error occurred while updating the user.";
            response.IsSuccess = false;
            response.Status = "500"; 
          }
            return response;

}
    }
}
