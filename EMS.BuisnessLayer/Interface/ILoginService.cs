using EMS.BuisnessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.BuisnessLayer.Interface
{
    public interface ILoginService
    {
        Task<BaseResponse> GetLogin(string UserName ,string PassWord);
    }
}
