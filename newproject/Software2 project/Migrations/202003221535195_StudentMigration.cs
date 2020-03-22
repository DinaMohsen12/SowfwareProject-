namespace Software2_project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class StudentMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.StudentModels",
                c => new
                    {
                        id = c.Short(nullable: false, identity: true),
                        name = c.String(nullable: false, maxLength: 50),
                        username = c.String(nullable: false, maxLength: 50),
                        password = c.String(nullable: false, maxLength: 25),
                        age = c.Short(nullable: false),
                        e_mail = c.String(nullable: false),
                        address = c.String(nullable: false),
                        phone = c.String(nullable: false),
                        gender = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.StudentModels");
        }
    }
}
