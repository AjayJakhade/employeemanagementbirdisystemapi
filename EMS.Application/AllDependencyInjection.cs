using EMS.Application.Repository;
using EMS.BuisnessLayer.Interface;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.Application
{
    public static class AllDependencyInjection
    {
        public static IServiceCollection AddAllDependency(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            services.AddScoped<IUserService, UserRepository>();
            services.AddScoped<IPrivilegeService, PrivilegeRepository>();
            services.AddScoped<IRolePrivilegeService, RolePrivilegeService>();
            services.AddScoped<ILoginService, LoginService>();
            services.AddScoped<IRoleService,RolesService>();
            services.AddScoped<IEmployeeService, EmployeeService>();
            services.AddScoped<IDepartmentService, DepartmentService>();
            services.AddScoped<ISalaryService, SalaryService>();
            return services;
        }
    }
}
