namespace Software2_project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class adding_DataAnnotation_to_Course_Attribute : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.CourseModels", "code", c => c.String(nullable: false));
            AlterColumn("dbo.CourseModels", "name", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.CourseModels", "name", c => c.String());
            AlterColumn("dbo.CourseModels", "code", c => c.String());
        }
    }
}
