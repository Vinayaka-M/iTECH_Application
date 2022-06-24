using iTECH_Application.Data;
using iTECH_Application.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace iTECH_Application.Controllers
{
    public class UsersController : Controller
    {
        private readonly iTECHCourseContext context;
        public UsersController(iTECHCourseContext context)
        {
            this.context = context;

        }
        [Authorize]
        public IActionResult UserList()
        {

            var users = context.Users.ToList();
            // List<ApplicationUser> users = (from user in this.context.Users.ToList());
            //var users = context.Database.ExecuteSqlRaw("Display_Users");
            return View(users);
        }
    }
}
