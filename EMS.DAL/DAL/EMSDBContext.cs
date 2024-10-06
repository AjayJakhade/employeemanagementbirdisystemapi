using EMS.BuisnessLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.DAL.DAL
{
    public class EMSDBContext:DbContext
    {
        public EMSDBContext(DbContextOptions<EMSDBContext> options):base(options) 
        {
            
        }
        public DbSet<UserMaster> usermaster { get; set; }
        public DbSet<Login> Logins { get; set; }
        public DbSet<RoleMaster> rolemaster { get; set; }
        public DbSet<Privilege>privilege { get; set; }
        public DbSet<RolePrivilege> roleprivilege { get; set; }
        public DbSet<Employee> Employee {  get; set; }
        public DbSet<Department> Department { get; set; }
        public DbSet<Salary> Salary { get; set; }
    }
}
