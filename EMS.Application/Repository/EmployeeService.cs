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
    public class EmployeeService : IEmployeeService
    {
        private readonly EMSDBContext _EMSDBContext;
        public EmployeeService(EMSDBContext EMSDBContext)
        {
            _EMSDBContext = EMSDBContext;

        }

        public async Task<BaseResponse> CreateEmployee(Employee employee)
        {
            BaseResponse response = new BaseResponse();
            try
            {
                await _EMSDBContext.Employee.AddAsync(employee);
                response.result = await _EMSDBContext.SaveChangesAsync();
                if (response.result != null)
                {
                    response.Message = "Employee is Created";
                    response.IsSuccess = true;
                    response.Status = "200";
                }
                else
                {
                    response.Message = "Error In Saving Employee";
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

        public async Task<BaseResponse> DeleteEmployee(int employeeid)
        {
            BaseResponse response = new BaseResponse();
            try
            {

                var employee = await _EMSDBContext.Employee.FindAsync(employeeid);

                if (employee == null)
                {
                    response.Message = "Employee not found.";
                    response.IsSuccess = false;
                    response.Status = "500";
                    return response;
                }


                _EMSDBContext.Employee.Remove(employee);


                await _EMSDBContext.SaveChangesAsync();

                response.Message = "Employee deleted successfully.";
                response.IsSuccess = true;
                response.Status = "200";
            }
            catch (Exception ex)
            {

                response.Message = "An error occurred while deleting the Employee.";
                response.IsSuccess = false;
                response.Status = "500";
            }

            return response;
        }

        public async Task<BaseResponse> GetEmployee()
        {
            BaseResponse response = new BaseResponse();
            try
            {


                var salryquery = from employee in _EMSDBContext.Employee
                                 join department in _EMSDBContext.Department on employee.DeptId equals department.DeptId
                                
                                 select new
                                 {
                                    
                                    employee.EmpId,
                                    department.DeptId,
                                     department.Name,
                                     employee.FirstName,
                                     employee.LastName,
                                     employee.Email,
                                     employee.Phone,
                                     employee.Position
                                 };
                response.result = await salryquery.ToListAsync();
                if (response.result != null)
                {
                    response.Message = "Salary Success";
                    response.IsSuccess = true;
                    response.Status = "200";
                }
                else
                {
                    response.Message = "Error In Get Salry";
                    response.IsSuccess = false;
                    response.Status = "500";
                }
            }
            catch (Exception ex)
            {
                response.Message = "Error In Get salary";
                response.IsSuccess = false;
                response.Status = "500";
            }
            return response;
        }

        public async Task<BaseResponse> UpdateEmployee(Employee employee)
        {
            BaseResponse response = new BaseResponse();
            try
            {
                var existingemplyee = await _EMSDBContext.Employee.FindAsync(employee.EmpId);

                if (existingemplyee == null)
                {
                    response.Message = "Employee not found.";
                    response.IsSuccess = false;
                    response.Status = "500";
                    return response;
                }

                existingemplyee.EmpId = employee.EmpId;
                existingemplyee.FirstName = employee.FirstName;
                existingemplyee.LastName = employee.LastName;
                existingemplyee.Email = employee.Email;
                existingemplyee.Phone = employee.Phone;
                existingemplyee.Position = employee.Position;



                await _EMSDBContext.SaveChangesAsync();
                response.result = employee.EmpId;
                response.Message = "Employee updated successfully.";
                response.IsSuccess = true;
                response.Status = "200";
            }
            catch (Exception ex)
            {

                response.Message = "An error occurred while updating the Employee.";
                response.IsSuccess = false;
                response.Status = "500";
            }
            return response;
        }
    }
}
