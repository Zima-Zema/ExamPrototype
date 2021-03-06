﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ExamPrototype.Models
{
    public class Department
    {
        public Department()
        {
            Students = new List<Student>();
            Courses = new List<Course>();
        }
        [Key]
        public int? Department_Id { get; set; }
        [Required][DataType(DataType.Text,ErrorMessage = "Please enter valid Name")]
        [Index(IsUnique =true)][MaxLength(50)]
        public string Name { get; set; }
        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Please enter valid Number")]
        public int Capacity { get; set; }
        public virtual List<Student> Students { get; set; }
     

        public virtual List<Course> Courses { get; set; }
        
    }
}