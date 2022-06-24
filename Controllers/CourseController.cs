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
    public class CourseController : Controller
    {
        private readonly iTECHCourseContext context;
       

        public CourseController(iTECHCourseContext context) 
        {
            this.context = context;
           
        }
        
        [HttpGet][HttpPost]
        public IActionResult showCourse(string SearchString, int pageNumber, int pageSize)
        {


            var result = context.Courses.ToList();
            
            if (!string.IsNullOrEmpty(SearchString))
            {

                 result = result.Where(s => s.courseName.StartsWith(SearchString)).ToList();


            }
            //int x = (pageNumber * pageSize) - pageSize;
            //result = context.Courses.Skip(x).Take(pageSize).ToList();
            return View(result);

        }

        [Authorize]
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        
        [HttpPost]
        [Authorize]
        public IActionResult Create(Course model)
        {
            if(ModelState.IsValid)
            {
                var crs = new Course()
                {
                    courseName=model.courseName,
                    duration=model.duration,
                    instructor=model.instructor,
                   

                };
                context.Courses.Add(crs);
                context.SaveChanges();
                TempData["error"]="Record Saved!";

                return RedirectToAction("showcourse");
                
            }
            else
            {
                TempData["message"] = "Empty field can't submit";
                return View(model);
            }
            

        }
        [Authorize]
        public IActionResult Delete(int id)
        {
            var crs = context.Courses.SingleOrDefault(e => e.Id == id);
            context.Courses.Remove(crs);
            context.SaveChanges();
            TempData["error"] = "Record Deleted!";
            return RedirectToAction("showcourse");

        }
        [Authorize]
        public IActionResult Edit(int id)
        {
            var crs = context.Courses.SingleOrDefault(e => e.Id == id);
            var result = new Course()
            {
                courseName = crs.courseName,
                duration = crs.duration,
                instructor = crs.instructor

            };
            return View(result);
        }
        [HttpPost]
        [Authorize]
        public IActionResult Edit(Course model)
        {
            var crs = new Course()
            {
                Id = model.Id,
                courseName = model.courseName,
                duration = model.duration,
                instructor = model.instructor

            };
            context.Courses.Update(crs);
            context.SaveChanges();
            TempData["error"] = "Record Updated!";
            return RedirectToAction("showcourse");
            
        }

     
    }
}
