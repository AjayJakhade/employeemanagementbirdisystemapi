using EMS.Application.Repository;
using EMS.BuisnessLayer.Interface;
using EMS.BuisnessLayer.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagementSystemAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RoleController:ControllerBase
    {
        private readonly IRoleService _roleService;
        public RoleController(IRoleService roleService )
        {
            _roleService = roleService;
        }
        [HttpGet("GetRole")]
        public async Task<ActionResult<BaseResponse>> GetRole()
        {
            BaseResponse response = new BaseResponse();
            try
            {
                response = await _roleService.GetRole();
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
