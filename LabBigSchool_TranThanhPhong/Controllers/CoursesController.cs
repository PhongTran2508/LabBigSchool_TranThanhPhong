using LabBigSchool_TranThanhPhong.Models;
using LabBigSchool_TranThanhPhong.ViewModels;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LabBigSchool_TranThanhPhong.Controllers
{
    public class CoursesController : Controller
    {
        private readonly ApplicationDbContext _dbContext;
        public CoursesController()
        {
            _dbContext = new ApplicationDbContext();
        } 
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        // GET: Courses
        public ActionResult Create(CourseViewModels viewModels)
        {
            if (!ModelState.IsValid)
            {
                viewModels.Categories = _dbContext.Categoríe.ToList();
                return View("Create", viewModels);
            }
            var course = new Course
            {
                LecturerId=User.Identity.GetUserId(),
                DateTime=viewModels.GetDateTime(),
                CategoryId=viewModels.Category,
                Place=viewModels.Place
            };
            _dbContext.Courses.Add(course);
            _dbContext.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
    }
}