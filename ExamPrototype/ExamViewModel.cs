using ExamPrototype.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExamPrototype
{
    public class ExamViewModel
    {
        public Exam Exam { get; set; }
        public IEnumerable<Course> CourseList { get; set; }
    }
}