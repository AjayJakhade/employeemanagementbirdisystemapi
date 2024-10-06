using EMS.BuisnessLayer.Interface;
using EMS.BuisnessLayer.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagementSystemAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PrivilegeController:ControllerBase
    {
        private readonly IPrivilegeService _privilegeService;
        public PrivilegeController(IPrivilegeService privilegeService)
        {
            _privilegeService = privilegeService;
        }

        [HttpGet("GetPrivilege")]
        public async Task<ActionResult<BaseResponse>> GetPrivilege([FromQuery] PrivilegeSearch privilegeSearch)
        {
            BaseResponse response = new BaseResponse();
            try
            {
                response = await _privilegeService.GetPrivilege(privilegeSearch);
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
        [HttpPost("CreatePrivilege")]
        public async Task<ActionResult<BaseResponse>> CreatePrivilege(Privilege privilege)
        {
            BaseResponse response = new BaseResponse();
            try
            {
                response = await _privilegeService.CreatePrivilege(privilege);
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
        [HttpPut("UpdatePrivilege")]
        public async Task<ActionResult<BaseResponse>> UpdatePrivilege(Privilege privilege)
        {
            BaseResponse response = new BaseResponse();
            try
            {
                response = await _privilegeService.UpdatePrivilege(privilege);
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
        [HttpDelete("DeletePrivilege")]
        public async Task<ActionResult<BaseResponse>> DeletePrivilege([FromQuery] int PrivilegeId)
        {
            BaseResponse response = new BaseResponse();
            try
            {
                response = await _privilegeService.DeletePrivilege(PrivilegeId);
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
