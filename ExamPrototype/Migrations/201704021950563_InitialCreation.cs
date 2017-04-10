namespace ExamPrototype.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreation : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Courses",
                c => new
                    {
                        Course_Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 20),
                        Lec_Duration = c.Int(nullable: false),
                        Lab_Duration = c.Int(nullable: false),
                        Status = c.Int(nullable: false),
                        Duration = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Course_Id)
                .Index(t => t.Name, unique: true);
            
            CreateTable(
                "dbo.Exams",
                c => new
                    {
                        Exam_id = c.Int(nullable: false, identity: true),
                        Duration = c.Int(nullable: false),
                        Subject = c.String(nullable: false),
                        from = c.DateTime(nullable: false),
                        to = c.DateTime(nullable: false),
                        Course_key = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Exam_id)
                .ForeignKey("dbo.Courses", t => t.Course_key, cascadeDelete: true)
                .Index(t => t.Course_key);
            
            CreateTable(
                "dbo.Questions",
                c => new
                    {
                        Question_id = c.Int(nullable: false, identity: true),
                        Header = c.String(nullable: false),
                        Body = c.String(nullable: false),
                        Answer_A = c.String(nullable: false),
                        Answer_B = c.String(nullable: false),
                        Answer_C = c.String(nullable: false),
                        Answer_D = c.String(nullable: false),
                        Answer_Model = c.String(nullable: false),
                        Grade = c.Double(nullable: false),
                        Course_key = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Question_id)
                .ForeignKey("dbo.Courses", t => t.Course_key, cascadeDelete: true)
                .Index(t => t.Course_key);
            
            CreateTable(
                "dbo.Std_Exam_Quest",
                c => new
                    {
                        Student_key = c.Int(nullable: false),
                        Exam_key = c.Int(nullable: false),
                        Question_key = c.Int(nullable: false),
                        Answer = c.String(),
                    })
                .PrimaryKey(t => new { t.Student_key, t.Exam_key, t.Question_key })
                .ForeignKey("dbo.Exams", t => t.Exam_key, cascadeDelete: false)
                .ForeignKey("dbo.Questions", t => t.Question_key, cascadeDelete: false)
                .ForeignKey("dbo.Students", t => t.Student_key, cascadeDelete: false)
                .Index(t => t.Student_key)
                .Index(t => t.Exam_key)
                .Index(t => t.Question_key);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        Student_Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(),
                        BirthDate = c.DateTime(nullable: false),
                        Email = c.String(nullable: false),
                        UserName = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        Attend_Balance = c.Int(nullable: false),
                        Telephone = c.String(),
                        Address_Street = c.String(),
                        Address_City = c.String(),
                        Address_Country = c.String(),
                    })
                .PrimaryKey(t => t.Student_Id);
            
            CreateTable(
                "dbo.Std_Exam",
                c => new
                    {
                        Student_key = c.Int(nullable: false),
                        Exam_key = c.Int(nullable: false),
                        Exam_grade = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Student_key, t.Exam_key })
                .ForeignKey("dbo.Exams", t => t.Exam_key, cascadeDelete: true)
                .ForeignKey("dbo.Students", t => t.Student_key, cascadeDelete: true)
                .Index(t => t.Student_key)
                .Index(t => t.Exam_key);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.QuestionExams",
                c => new
                    {
                        Question_Question_id = c.Int(nullable: false),
                        Exam_Exam_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Question_Question_id, t.Exam_Exam_id })
                .ForeignKey("dbo.Questions", t => t.Question_Question_id, cascadeDelete: false)
                .ForeignKey("dbo.Exams", t => t.Exam_Exam_id, cascadeDelete: false)
                .Index(t => t.Question_Question_id)
                .Index(t => t.Exam_Exam_id);
            
            CreateTable(
                "dbo.StudentCourses",
                c => new
                    {
                        Student_Student_Id = c.Int(nullable: false),
                        Course_Course_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Student_Student_Id, t.Course_Course_Id })
                .ForeignKey("dbo.Students", t => t.Student_Student_Id, cascadeDelete: true)
                .ForeignKey("dbo.Courses", t => t.Course_Course_Id, cascadeDelete: true)
                .Index(t => t.Student_Student_Id)
                .Index(t => t.Course_Course_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Std_Exam_Quest", "Student_key", "dbo.Students");
            DropForeignKey("dbo.Std_Exam", "Student_key", "dbo.Students");
            DropForeignKey("dbo.Std_Exam", "Exam_key", "dbo.Exams");
            DropForeignKey("dbo.StudentCourses", "Course_Course_Id", "dbo.Courses");
            DropForeignKey("dbo.StudentCourses", "Student_Student_Id", "dbo.Students");
            DropForeignKey("dbo.Std_Exam_Quest", "Question_key", "dbo.Questions");
            DropForeignKey("dbo.Std_Exam_Quest", "Exam_key", "dbo.Exams");
            DropForeignKey("dbo.QuestionExams", "Exam_Exam_id", "dbo.Exams");
            DropForeignKey("dbo.QuestionExams", "Question_Question_id", "dbo.Questions");
            DropForeignKey("dbo.Questions", "Course_key", "dbo.Courses");
            DropForeignKey("dbo.Exams", "Course_key", "dbo.Courses");
            DropIndex("dbo.StudentCourses", new[] { "Course_Course_Id" });
            DropIndex("dbo.StudentCourses", new[] { "Student_Student_Id" });
            DropIndex("dbo.QuestionExams", new[] { "Exam_Exam_id" });
            DropIndex("dbo.QuestionExams", new[] { "Question_Question_id" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Std_Exam", new[] { "Exam_key" });
            DropIndex("dbo.Std_Exam", new[] { "Student_key" });
            DropIndex("dbo.Std_Exam_Quest", new[] { "Question_key" });
            DropIndex("dbo.Std_Exam_Quest", new[] { "Exam_key" });
            DropIndex("dbo.Std_Exam_Quest", new[] { "Student_key" });
            DropIndex("dbo.Questions", new[] { "Course_key" });
            DropIndex("dbo.Exams", new[] { "Course_key" });
            DropIndex("dbo.Courses", new[] { "Name" });
            DropTable("dbo.StudentCourses");
            DropTable("dbo.QuestionExams");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Std_Exam");
            DropTable("dbo.Students");
            DropTable("dbo.Std_Exam_Quest");
            DropTable("dbo.Questions");
            DropTable("dbo.Exams");
            DropTable("dbo.Courses");
        }
    }
}
