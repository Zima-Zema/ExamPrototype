using ExamPrototype.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ExamPrototype.Controllers
{
    public class CoursesController : Controller
    {
        ApplicationDbContext _context = new ApplicationDbContext();
        // GET: Courses
        public ActionResult Index()
        {
            var courseList = _context.Courses.ToList();
            return View(courseList);
        }
        [HttpGet]
        public ActionResult Generate(int id)
        {
            var course = _context.Courses.SingleOrDefault(c => c.Course_Id == id);
            return View(course);
        }
        public ActionResult Generate(Course course)
        {
            Exam ex = new Exam();
            ex.Subject = course.Name;
            
            return View();
        }
    }
}