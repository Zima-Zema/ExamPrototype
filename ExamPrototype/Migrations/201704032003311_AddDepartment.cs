namespace ExamPrototype.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDepartment : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Departments",
                c => new
                    {
                        Department_Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Capacity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Department_Id)
                .Index(t => t.Name, unique: true);
            
            CreateTable(
                "dbo.DepartmentCourses",
                c => new
                    {
                        Department_Department_Id = c.Int(nullable: false),
                        Course_Course_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Department_Department_Id, t.Course_Course_Id })
                .ForeignKey("dbo.Departments", t => t.Department_Department_Id, cascadeDelete: true)
                .ForeignKey("dbo.Courses", t => t.Course_Course_Id, cascadeDelete: true)
                .Index(t => t.Department_Department_Id)
                .Index(t => t.Course_Course_Id);
            
            AddColumn("dbo.Students", "Department_Department_Id", c => c.Int());
            CreateIndex("dbo.Students", "Department_Department_Id");
            AddForeignKey("dbo.Students", "Department_Department_Id", "dbo.Departments", "Department_Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Students", "Department_Department_Id", "dbo.Departments");
            DropForeignKey("dbo.DepartmentCourses", "Course_Course_Id", "dbo.Courses");
            DropForeignKey("dbo.DepartmentCourses", "Department_Department_Id", "dbo.Departments");
            DropIndex("dbo.DepartmentCourses", new[] { "Course_Course_Id" });
            DropIndex("dbo.DepartmentCourses", new[] { "Department_Department_Id" });
            DropIndex("dbo.Students", new[] { "Department_Department_Id" });
            DropIndex("dbo.Departments", new[] { "Name" });
            DropColumn("dbo.Students", "Department_Department_Id");
            DropTable("dbo.DepartmentCourses");
            DropTable("dbo.Departments");
        }
    }
}
