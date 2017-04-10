using ExamPrototype.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExamPrototype
{
    public class ExamDeptViewModel
    {
        public IEnumerable<Department> DepartmentList { get; set; }
        public Department DepartmentObj { get; set; }
        public Exam ExamObj { get; set; }
        public Course CourseObj { get; set; }
    }
}