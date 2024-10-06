using EMS.BuisnessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.BuisnessLayer.Interface
{
    public interface IEmployeeService
    {
        Task<BaseResponse> GetEmployee();
        Task<BaseResponse> CreateEmployee(Employee employee);
        Task<BaseResponse> UpdateEmployee(Employee employee);
        Task<BaseResponse> DeleteEmployee(int employeeid);
    }
}
