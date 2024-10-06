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
    public class DepartmentService : IDepartmentService
    {
        private readonly EMSDBContext _EMSDBContext;
        public DepartmentService(EMSDBContext EMSDBContext)
        {
            _EMSDBContext = EMSDBContext;

        }
        public async Task<BaseResponse> CreateDepatment(Department department)
        {
            BaseResponse response = new BaseResponse();
            try
            {
                await _EMSDBContext.Department.AddAsync(department);
                response.result = await _EMSDBContext.SaveChangesAsync();
                if (response.result != null)
                {
                    response.Message = "Department is Created";
                    response.IsSuccess = true;
                    response.Status = "200";
                }
                else
                {
                    response.Message = "Error In Saving Department";
                    response.IsSuccess = false;
                    response.Status = "404";
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

        public async Task<BaseResponse> DeleteDepartment(int departmentid)
        {
            BaseResponse response = new BaseResponse();
            try
            {

                var department = await _EMSDBContext.Department.FindAsync(departmentid);

                if (department == null)
                {
                    response.Message = "Department not found.";
                    response.IsSuccess = false;
                    response.Status = "500";
                    return response;
                }


                _EMSDBContext.Department.Remove(department);


                await _EMSDBContext.SaveChangesAsync();

                response.Message = "Department deleted successfully.";
                response.IsSuccess = true;
                response.Status = "200";
            }
            catch (Exception ex)
            {

                response.Message = "An error occurred while deleting the Department.";
                response.IsSuccess = false;
                response.Status = "500";
            }

            return response;
        }

        public async Task<BaseResponse> GetDepartment()
        {
            BaseResponse response = new BaseResponse();
            try
            {
                var query = _EMSDBContext.Department.AsQueryable();
                response.result = await query.ToListAsync();
                if (response.result != null)
                {
                    response.Message = "Department Success";
                    response.IsSuccess = true;
                    response.Status = "200";
                }
                else
                {
                    response.Message = "Error In Get Department";
                    response.IsSuccess = false;
                    response.Status = "500";
                }
            }
            catch (Exception ex)
            {
                response.Message = "Error In Get Department";
                response.IsSuccess = false;
                response.Status = "500";
            }
            return response;
        }

        public async Task<BaseResponse> UpdateDepartment(Department department)
        {
            BaseResponse response = new BaseResponse();
            try
            {
                var existingdept = await _EMSDBContext.Department.FindAsync(department.DeptId);

                if (existingdept == null)
                {
                    response.Message = "Deapartment not found.";
                    response.IsSuccess = false;
                    response.Status = "500";
                    return response;
                }

                existingdept.DeptId = department.DeptId;
                existingdept.Name = department.Name;
                existingdept.Description= department.Description;
               



                await _EMSDBContext.SaveChangesAsync();
                response.result = department.DeptId;
                response.Message = "Department updated successfully.";
                response.IsSuccess = true;
                response.Status = "200";
            }
            catch (Exception ex)
            {

                response.Message = "An error occurred while updating the Department.";
                response.IsSuccess = false;
                response.Status = "500";
            }
            return response;
        }
    }
}
