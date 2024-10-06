using EMS.BuisnessLayer.Interface;
using EMS.BuisnessLayer.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagementSystemAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RolePrivilegeController:ControllerBase
    {
        private readonly IRolePrivilegeService _rolePrivilegeService;
        public RolePrivilegeController(IRolePrivilegeService rolePrivilegeService)
        {
            _rolePrivilegeService = rolePrivilegeService;
        }

        [HttpGet("GetRolePrivilege")]
        public async Task<ActionResult<BaseResponse>> GetRolePrivilege()
        {
            BaseResponse response = new BaseResponse();
            try
            {
                response = await _rolePrivilegeService.GetRolePrivilege();
                if (!response.IsSuccess)
                {
                    return response;
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
        [HttpPost("CreateRolePrivilege")]
        public async Task<ActionResult<BaseResponse>> CreateRolePrivilege(RolePrivilege rolePrivilege)
        {
            BaseResponse response = new BaseResponse();
            try
            {
                response = await _rolePrivilegeService.CreateRolePrivilege(rolePrivilege);
                if (!response.IsSuccess)
                {
                    return response;
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
        [HttpPut("UpdateRolePrivilege")]
        public async Task<ActionResult<BaseResponse>> UpdateRolePrivilege(RolePrivilege rolePrivilege)
        {
            BaseResponse response = new BaseResponse();
            try
            {
                response = await _rolePrivilegeService.UpdateRolePrivilege(rolePrivilege);
                if (!response.IsSuccess)
                {
                    return response;
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
        [HttpDelete("DeleteRolePrivilege")]
        public async Task<ActionResult<BaseResponse>> DeleteRolePrivilege([FromQuery] long RolePrivilegeId)
        {
            BaseResponse response = new BaseResponse();
            try
            {
                response = await _rolePrivilegeService.DeleteRolePrivilege(RolePrivilegeId);
                if (!response.IsSuccess)
                {
                    return response;
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
    }
}
