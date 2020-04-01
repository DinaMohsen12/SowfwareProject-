namespace Software2_project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_role_attribute_to_every_user : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AdminModels", "role", c => c.String());
            AddColumn("dbo.ProfessorModels", "role", c => c.String());
            AddColumn("dbo.StudentModels", "role", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.StudentModels", "role");
            DropColumn("dbo.ProfessorModels", "role");
            DropColumn("dbo.AdminModels", "role");
        }
    }
}
