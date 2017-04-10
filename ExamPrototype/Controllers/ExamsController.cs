using ExamPrototype.Models;
using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ExamPrototype.Controllers
{
    public class ExamsController : Controller
    {
        ApplicationDbContext _context = new ApplicationDbContext();
        // GET: Exams
        public ActionResult Index()
        {
            var examModel = _context.Exams.Include(e => e.Courses);
            return View(examModel);
        }
        public ActionResult New()
        {
            var viewModel = new ExamViewModel
            {
                Exam = new Exam(),
                CourseList = _context.Courses.ToList()
            };
            return View(viewModel);
        }
        public ActionResult Save(ExamViewModel model)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new ExamViewModel
                {
                    Exam = model.Exam,
                    CourseList = _context.Courses.ToList()

                };
                return View("New", viewModel);
            }

            if (model.Exam.Exam_id == 0)
            {
                //var threeRandomFoos = foos.OrderBy(x => Guid.NewGuid()).Take(3);
                int NuQ = int.Parse(Request.Form["NumberOfQ"]);
                var quesSample = _context.Questions.OrderBy(q => Guid.NewGuid()).Take(NuQ) as IEnumerable<Question>;
                model.Exam.Questions.AddRange(quesSample);
                _context.Exams.Add(model.Exam);
            }
            else
            {
                var Oldex = _context.Exams.SingleOrDefault(CC => CC.Exam_id == model.Exam.Exam_id);
                //TryUpdateModel(OldCus);
                Oldex.Subject = model.Exam.Subject;
                Oldex.Duration = model.Exam.Duration;
                Oldex.from = model.Exam.from;
                Oldex.to = model.Exam.to;
                Oldex.Course_key = model.Exam.Course_key;

            }

            _context.SaveChanges();
            return RedirectToAction("Index", "Exams");
            
        }


        [HttpGet]
        public ActionResult Assign(int exid)
        {
            var exam = _context.Exams.SingleOrDefault(ex => ex.Exam_id == exid);
            var deptlist = _context.Courses.SingleOrDefault(C => C.Course_Id == exam.Course_key).Departments.ToList();
            var viewModel = new ExamDeptViewModel()
            {
                DepartmentList = deptlist,
                ExamObj = exam,
                CourseObj = _context.Courses.SingleOrDefault(C => C.Course_Id == exam.Course_key),
                DepartmentObj = new Department()
            };



            return View(viewModel);
        }
        [HttpPost]
        public ActionResult Assign(ExamDeptViewModel model)
        {
            var stds = model.DepartmentObj.Students.ToList();
            var ex = model.ExamObj;
            foreach (var item in stds)
            {
                ex.Std_Exams.Add(new Std_Exam() { Students = item });
            }
            _context.SaveChanges();




            return RedirectToAction("Index", "Exams");
        }
    }
}