using iTECH_Application.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace iTECH_Application.Data
{
    public class iTECHCourseContext :IdentityDbContext<ApplicationUser>
    {
        public iTECHCourseContext(DbContextOptions<iTECHCourseContext> options)
                : base(options)
        {
          
        }
        public DbSet<Course> Courses { get; set; }
        public DbSet<CategoryModel> Categories { get; set; }
    }
}
