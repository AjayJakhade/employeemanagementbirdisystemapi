using EMS.BuisnessLayer.Interface;
using EMS.BuisnessLayer.Models;
using EMS.DAL.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace EMS.Application.Repository
{
    public class LoginService : ILoginService
    {
        private readonly EMSDBContext _EMSDBContext;
        private readonly IConfiguration _configuration;
        public LoginService(EMSDBContext EMSDBContext,IConfiguration configuration)
        {
            _EMSDBContext = EMSDBContext;
            _configuration = configuration;

        }
        public async Task<BaseResponse> GetLogin(string UserName, string PassWord)
        {
            BaseResponse response = new BaseResponse();
            ReturnJWT JWT = new();
            try
            {
                var result = await _EMSDBContext.usermaster.Where(x => x.username == UserName && x.password == PassWord).ToListAsync();
                var query = from username in result
                            join role in _EMSDBContext.rolemaster on username.roleid equals role.roleid
                            select new
                            {
                                role.roleid,
                                role.rolename
                            };
                if (result!=null)
                {

                    int roleid = result.Select(x => x.roleid).FirstOrDefault();
                   
                    var roleprivilege = await _EMSDBContext.roleprivilege.Where(x => x.roleid == roleid).ToListAsync();
                    long privilegeid=roleprivilege.Select(x=>x.privilegeid).FirstOrDefault();
                   
                    var privilege = await _EMSDBContext.privilege.Where(x => x.privilegeid == privilegeid).ToListAsync();
                    var roleprivilegequery = from privilegedata in privilege
                                             join roleprivilegedata in roleprivilege on privilegedata.privilegeid equals roleprivilegedata.privilegeid
                                             select new PrivilegeDTO
                                             {
                                                 PrivilegeId = privilegedata.privilegeid,
                                                 PrivilegeName = privilegedata.privilegename,
                                                 CanAdd = roleprivilegedata.canadd,
                                                 CanEdit = roleprivilegedata.canedit,
                                                 CanExport = roleprivilegedata.canexport,
                                                 CanDelete = roleprivilegedata.candelete,
                                                 CanGet = roleprivilegedata.canget
                                             };
                    var claimtypes = new List<Claim>();


                    claimtypes.AddRange(result.Select(u => new Claim(ClaimTypes.Name, u.username)));
                    claimtypes.AddRange(result.Select(i => new Claim(ClaimTypes.Sid, i.userid.ToString())));
                    claimtypes.AddRange(result.Select(ri => new Claim(ClaimTypes.Sid, ri.roleid.ToString())));
                    claimtypes.AddRange(query.Select(r => new Claim(ClaimTypes.Role, r.rolename)));
                    claimtypes.AddRange(result.Select(m => new Claim(ClaimTypes.Name, m.mobile)));
                    claimtypes.AddRange(result.Select(e => new Claim(ClaimTypes.Name, e.email)));
                    var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));
                    var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
                    var tokeOptions = new JwtSecurityToken(
                       issuer: _configuration["JWT:ValidIssuer"],
                       audience: _configuration["JWT:ValidAudience"],
                       claims: claimtypes,
                       expires: DateTime.Now.AddHours(10),
                       signingCredentials: signinCredentials
                   );
                    var tokenString = new JwtSecurityTokenHandler().WriteToken(tokeOptions);
                    var loginData = result.FirstOrDefault();
                    var roledata = query.FirstOrDefault();
                    
                    JWT.UserId = loginData.userid;
                    JWT.UserName = loginData.username;

                    JWT.RoleId = loginData.roleid;
                    JWT.RoleName = roledata.rolename;
                    
                    JWT.Privilages = roleprivilegequery;


                    JWT.Token = tokenString;





                    response.result = JWT;
                    response.IsSuccess = true;
                }

             
                
            }
            catch(Exception ex)
            {
                response.Message = ex.Message;
                response.IsSuccess = false;
            }
            return response;
        }
    }
}
