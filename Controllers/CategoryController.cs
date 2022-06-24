using iTECH_Application.Data;
using iTECH_Application.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace iTECH_Application.Controllers
{
    public class CategoryController : Controller
    {
        private readonly iTECHCourseContext context;
        public CategoryController(iTECHCourseContext context)
        {
            this.context = context;
        }

        [Authorize]
        [HttpGet]
        public IActionResult CreateCategory()
        {
            return View();
        }
        [HttpPost]
        [Authorize]
        public IActionResult CreateCategory(CategoryModel model)
        {
            if (ModelState.IsValid)
            {
                var catgry = new CategoryModel()
                {
                    category = model.category
                };
                context.Categories.Add(catgry);
                context.SaveChanges();
                TempData["error"] = "Record Saved!";

                return RedirectToAction("Create");

            }
            else
            {
                TempData["message"] = "Empty field can't submit";
                return View(model);
            }


        }

    }
}
