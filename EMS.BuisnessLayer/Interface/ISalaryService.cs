using EMS.BuisnessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.BuisnessLayer.Interface
{
    public interface ISalaryService
    {
        Task<BaseResponse> GetSalary();
        Task<BaseResponse> CreateSalary(Salary salary);
        Task<BaseResponse> UpdateSalary(Salary salary);
        Task<BaseResponse> DeleteSalary(int salaryid);
    }
}
