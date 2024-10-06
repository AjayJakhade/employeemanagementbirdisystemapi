using EMS.BuisnessLayer.Interface;
using EMS.BuisnessLayer.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagementSystemAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController:ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }
        [HttpGet("GetEmployee")]
        public async Task<ActionResult<BaseResponse>> GetEmployee()
        {
            BaseResponse response = new BaseResponse();
            try
            {
                response = await _employeeService.GetEmployee();
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
        [HttpPost("CreateEmployee")]
        public async Task<ActionResult<BaseResponse>> CreateEmployee(Employee employee)
        {
            BaseResponse response = new BaseResponse();
            try
            {
                response = await _employeeService.CreateEmployee(employee);
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
        [HttpPut("UpdateEmployee")]
        public async Task<ActionResult<BaseResponse>> UpdateEmployee(Employee employee)
        {
            BaseResponse response = new BaseResponse();
            try
            {
                response = await _employeeService.UpdateEmployee(employee);
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
        [HttpDelete("DeleteEmployee")]
        public async Task<ActionResult<BaseResponse>> DeleteEmployee([FromQuery] int employeeid)
        {
            BaseResponse response = new BaseResponse();
            try
            {
                response = await _employeeService.DeleteEmployee(employeeid);
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
