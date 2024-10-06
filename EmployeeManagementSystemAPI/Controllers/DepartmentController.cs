using EMS.BuisnessLayer.Interface;
using EMS.BuisnessLayer.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagementSystemAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DepartmentController:ControllerBase
    {
        private readonly IDepartmentService _departmentService;
        public DepartmentController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }
        [HttpGet("GetDepartment")]
        public async Task<ActionResult<BaseResponse>> GetDepartment()
        {
            BaseResponse response = new BaseResponse();
            try
            {
                response = await _departmentService.GetDepartment();
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
        [HttpPost("CreateDepartment")]
        public async Task<ActionResult<BaseResponse>> CreateDepartment(Department department)
        {
            BaseResponse response = new BaseResponse();
            try
            {
                response = await _departmentService.CreateDepatment(department);
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
        [HttpPut("UpdateDepartment")]
        public async Task<ActionResult<BaseResponse>> UpdateDepartment(Department department)
        {
            BaseResponse response = new BaseResponse();
            try
            {
                response = await _departmentService.UpdateDepartment(department);
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
        [HttpDelete("DeleteDepartment")]
        public async Task<ActionResult<BaseResponse>> DeleteDepartment([FromQuery] int departmentid)
        {
            BaseResponse response = new BaseResponse();
            try
            {
                response = await _departmentService.DeleteDepartment(departmentid);
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
