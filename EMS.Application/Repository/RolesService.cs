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
    public class RolesService : IRoleService
    {
        private readonly EMSDBContext _EMSDBContext;
        public RolesService(EMSDBContext EMSDBContext)
        {
            _EMSDBContext = EMSDBContext;

        }

        public async Task<BaseResponse> GetRole()
        {
            BaseResponse response = new BaseResponse();
            try
            {
                var query =  _EMSDBContext.rolemaster.AsQueryable();

                response.result = await query.ToListAsync();
                if (response.result != null)
                {
                    response.Message = "role Success";
                    response.IsSuccess = true;
                    response.Status = "200";
                }
                else
                {
                    response.Message = "Error In Get role";
                    response.IsSuccess = false;
                    response.Status = "500";
                }
            }
            catch (Exception ex)
            {
                response.Message = "Error In Get role";
                response.IsSuccess = false;
                response.Status = "500";
            }
            return response;
        }

        
    }
}
