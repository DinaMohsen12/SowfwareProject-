namespace Software2_project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Adding_Questions_Table : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.QuestionModels",
                c => new
                    {
                        id = c.Short(nullable: false, identity: true),
                        question = c.String(nullable: false),
                        answer1 = c.String(nullable: false),
                        answer2 = c.String(nullable: false),
                        answer3 = c.String(),
                        answer4 = c.String(),
                        answer5 = c.String(),
                        rightAnswer = c.String(nullable: false),
                        CourseId = c.Short(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.CourseModels", t => t.CourseId, cascadeDelete: true)
                .Index(t => t.CourseId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.QuestionModels", "CourseId", "dbo.CourseModels");
            DropIndex("dbo.QuestionModels", new[] { "CourseId" });
            DropTable("dbo.QuestionModels");
        }
    }
}
