namespace ExamPrototype.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ExamGradeNull : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Std_Exam", "Exam_grade", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Std_Exam", "Exam_grade", c => c.Int(nullable: false));
        }
    }
}
