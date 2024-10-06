using EMS.BuisnessLayer.Interface;
using EMS.BuisnessLayer.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagementSystemAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class UsersController:ControllerBase
    {
        private readonly IUserService _UserService;
        public UsersController(IUserService userService)
        {
            _UserService = userService;
        }

        [HttpGet("GetUsers")]
        public async Task<ActionResult<BaseResponse>> GetUsers([FromQuery] UserSearch userSearch)
        {
            BaseResponse response = new BaseResponse();
            try
            {
                response = await _UserService.GetUsers(userSearch);
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
        [HttpPost("CreateUsers")]
        public async Task<ActionResult<BaseResponse>> CreateUsers( UserMaster userMaster)
        {
            BaseResponse response = new BaseResponse();
            try
            {
                response = await _UserService.CreateUsers(userMaster);
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
        [HttpPut("UpdateUsers")]
        public async Task<ActionResult<BaseResponse>> UpdateUsers(UserMaster userMaster)
        {
            BaseResponse response = new BaseResponse();
            try
            {
                response = await _UserService.UpdateUsers(userMaster);
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
        [HttpDelete("DeleteUsers")]
        public async Task<ActionResult<BaseResponse>> DeleteUsers([FromQuery]long UserId)
        {
            BaseResponse response = new BaseResponse();
            try
            {
                response = await _UserService.DeleteUsers(UserId);
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
