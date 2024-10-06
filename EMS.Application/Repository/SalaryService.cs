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
    public class SalaryService : ISalaryService
    {
        private readonly EMSDBContext _EMSDBContext;
        public SalaryService(EMSDBContext EMSDBContext)
        {
            _EMSDBContext = EMSDBContext;

        }
        public async Task<BaseResponse> CreateSalary(Salary salary)
        {

            BaseResponse response = new BaseResponse();
            try
            {
                await _EMSDBContext.Salary.AddAsync(salary);
                response.result = await _EMSDBContext.SaveChangesAsync();
                if (response.result != null)
                {
                    response.Message = "Salary is Created";
                    response.IsSuccess = true;
                    response.Status = "200";
                }
                else
                {
                    response.Message = "Error In Saving Salary";
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

        public async  Task<BaseResponse> DeleteSalary(int salaryid)
        {
            BaseResponse response = new BaseResponse();
            try
            {

                var salary = await _EMSDBContext.Salary.FindAsync(salaryid);

                if (salary == null)
                {
                    response.Message = "Salry not found.";
                    response.IsSuccess = false;
                    response.Status = "500";
                    return response;
                }


                _EMSDBContext.Salary.Remove(salary);


                await _EMSDBContext.SaveChangesAsync();

                response.Message = "Salary deleted successfully.";
                response.IsSuccess = true;
                response.Status = "200";
            }
            catch (Exception ex)
            {

                response.Message = "An error occurred while deleting the Salary.";
                response.IsSuccess = false;
                response.Status = "500";
            }

            return response;
        }

        public async Task<BaseResponse> GetSalary()
        {
            BaseResponse response = new BaseResponse();
            try
            {
              

                var salryquery = from salary in _EMSDBContext.Salary
                                 join employee in _EMSDBContext.Employee on salary.EmpId equals employee.EmpId
                                 select new
                                 {
                                    salary.SalaryId,
                                    employee.EmpId,
                                    salary.Amount,
                                    employee.FirstName,
                                    employee.LastName,
                                    employee.Email
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

        public async Task<BaseResponse> UpdateSalary(Salary salary)
        {
            BaseResponse response = new BaseResponse();
            try
            {
                var existingsalary = await _EMSDBContext.Salary.FindAsync(salary.SalaryId);

                if (existingsalary == null)
                {
                    response.Message = "Salary not found.";
                    response.IsSuccess = false;
                    response.Status = "500";
                    return response;
                }

                existingsalary.SalaryId = salary.SalaryId;
                existingsalary.EmpId = salary.EmpId;
                existingsalary.Amount = salary.Amount;
             
                



                await _EMSDBContext.SaveChangesAsync();
                response.result = salary.SalaryId;
                response.Message = "Salary updated successfully.";
                response.IsSuccess = true;
                response.Status = "200";
            }
            catch (Exception ex)
            {

                response.Message = "An error occurred while updating the Salary.";
                response.IsSuccess = false;
                response.Status = "500";
            }
            return response;
        }
    }
}
