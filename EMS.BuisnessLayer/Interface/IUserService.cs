﻿using EMS.BuisnessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.BuisnessLayer.Interface
{
    public interface IUserService
    {
        Task<BaseResponse> GetUsers(UserSearch userSearch);
        Task<BaseResponse> CreateUsers(UserMaster userMaster);
        Task<BaseResponse> UpdateUsers(UserMaster userMaster);
        Task<BaseResponse> DeleteUsers(long userId);
    }
}
