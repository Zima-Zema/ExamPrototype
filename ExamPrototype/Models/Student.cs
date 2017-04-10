using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ExamPrototype.Models
{
    public class Student
    {
        public Student()
        {
            Std_Exam_Ques = new List<Models.Std_Exam_Quest>();
            Std_Exams = new List<Std_Exam>();
            Courses = new List<Course>();
        }
        [Key]
        public int Student_Id { get; set; }
        [Required(ErrorMessage ="*")]
        [DataType(DataType.Text, ErrorMessage = "Please enter valid Name")]
        [RegularExpression(@"^[a-zA-Z ]+$", ErrorMessage = "Please Enter Valid Name")]
        public string FirstName { get; set; }
        [DataType(DataType.Text, ErrorMessage = "Please enter valid Name")]
        [RegularExpression(@"^[a-zA-Z ]+$", ErrorMessage = "Please Enter Valid Name")]
        public string LastName { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime BirthDate { get; set; }
        //
        [Required(ErrorMessage ="*")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Enter Valid Email")]
        [EmailAddress]    
        public string Email { get; set; }
        //
        [Required(ErrorMessage ="*")]
        public string UserName { get; set; }
        //
        [Required(ErrorMessage ="*")]
        [DataType(DataType.Password, ErrorMessage = "Please Enter Strong Password ")]
        public string Password { get; set; }
        //
        [DefaultValue("600")]
        [Range(0, 600, ErrorMessage = "Please enter valid Number")]
        [Required(ErrorMessage ="*")]
        public int Attend_Balance { get; set; }
        //
     // [Required(ErrorMessage ="*")]
        [DataType(DataType.PhoneNumber, ErrorMessage = "Enter Valid Phone")]
        [RegularExpression(@"^(\d{11})$", ErrorMessage = "Enter Valid Mobile Phone")]
        public string Telephone { get; set; }
        //
        public FullAddress Address { get; set; }

        public virtual List<Course> Courses { get; set; }
        public virtual List<Std_Exam_Quest> Std_Exam_Ques { get; set; }
        public virtual List<Std_Exam> Std_Exams { get; set; }
        [ForeignKey("Department")]
        public int? Department_Key { get; set; }
        //
        public virtual Department Department { get; set; }
    }
}