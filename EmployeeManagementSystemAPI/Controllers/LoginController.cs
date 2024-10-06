using EMS.BuisnessLayer.Interface;
using EMS.BuisnessLayer.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagementSystemAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController:ControllerBase
    {
        private readonly ILoginService _loginService;
        public LoginController(ILoginService loginService)
        {
            _loginService = loginService;
        }

        [HttpGet("GetLogin")]
        public async Task<ActionResult<BaseResponse>> GetLogin([FromQuery] string UserName,string PassWord)
        {
            BaseResponse response = new BaseResponse();
            try
            {
                response = await _loginService.GetLogin(UserName,PassWord);
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
