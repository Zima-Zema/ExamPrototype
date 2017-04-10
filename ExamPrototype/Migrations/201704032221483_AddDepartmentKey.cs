namespace ExamPrototype.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDepartmentKey : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Students", name: "Department_Department_Id", newName: "Department_Key");
            RenameIndex(table: "dbo.Students", name: "IX_Department_Department_Id", newName: "IX_Department_Key");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Students", name: "IX_Department_Key", newName: "IX_Department_Department_Id");
            RenameColumn(table: "dbo.Students", name: "Department_Key", newName: "Department_Department_Id");
        }
    }
}
