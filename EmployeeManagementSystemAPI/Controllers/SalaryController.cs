using EMS.BuisnessLayer.Interface;
using EMS.BuisnessLayer.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagementSystemAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SalaryController:ControllerBase
    {
        private readonly ISalaryService _salaryService;
        public SalaryController(ISalaryService salaryService)
        {
            _salaryService = salaryService;
        }
        [HttpGet("GetSalary")]
        public async Task<ActionResult<BaseResponse>> GetSalary()
        {
            BaseResponse response = new BaseResponse();
            try
            {
                response = await _salaryService.GetSalary();
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
        [HttpPost("CreateSalary")]
        public async Task<ActionResult<BaseResponse>> CreateSalary(Salary salary)
        {
            BaseResponse response = new BaseResponse();
            try
            {
                response = await _salaryService.CreateSalary(salary);
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
        [HttpPut("UpdateSalary")]
        public async Task<ActionResult<BaseResponse>> UpdateSalary(Salary salary)
        {
            BaseResponse response = new BaseResponse();
            try
            {
                response = await _salaryService.UpdateSalary(salary);
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
        [HttpDelete("DeleteSalary")]
        public async Task<ActionResult<BaseResponse>> DeleteSalary([FromQuery] int salaryid)
        {
            BaseResponse response = new BaseResponse();
            try
            {
                response = await _salaryService.DeleteSalary(salaryid);
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
