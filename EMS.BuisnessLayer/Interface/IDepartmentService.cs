using EMS.BuisnessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.BuisnessLayer.Interface
{
    public interface IDepartmentService
    {
        Task<BaseResponse> GetDepartment();
        Task<BaseResponse> CreateDepatment(Department department);
        Task<BaseResponse> UpdateDepartment(Department department);
        Task<BaseResponse> DeleteDepartment(int departmentid);
    }
}
