namespace Software2_project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CourseModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CourseModels",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        code = c.String(),
                        name = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.ProfessorModelCourseModels",
                c => new
                    {
                        ProfessorModel_id = c.Short(nullable: false),
                        CourseModel_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ProfessorModel_id, t.CourseModel_id })
                .ForeignKey("dbo.ProfessorModels", t => t.ProfessorModel_id, cascadeDelete: true)
                .ForeignKey("dbo.CourseModels", t => t.CourseModel_id, cascadeDelete: true)
                .Index(t => t.ProfessorModel_id)
                .Index(t => t.CourseModel_id);
            
            CreateTable(
                "dbo.StudentModelCourseModels",
                c => new
                    {
                        StudentModel_id = c.Short(nullable: false),
                        CourseModel_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.StudentModel_id, t.CourseModel_id })
                .ForeignKey("dbo.StudentModels", t => t.StudentModel_id, cascadeDelete: true)
                .ForeignKey("dbo.CourseModels", t => t.CourseModel_id, cascadeDelete: true)
                .Index(t => t.StudentModel_id)
                .Index(t => t.CourseModel_id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.StudentModelCourseModels", "CourseModel_id", "dbo.CourseModels");
            DropForeignKey("dbo.StudentModelCourseModels", "StudentModel_id", "dbo.StudentModels");
            DropForeignKey("dbo.ProfessorModelCourseModels", "CourseModel_id", "dbo.CourseModels");
            DropForeignKey("dbo.ProfessorModelCourseModels", "ProfessorModel_id", "dbo.ProfessorModels");
            DropIndex("dbo.StudentModelCourseModels", new[] { "CourseModel_id" });
            DropIndex("dbo.StudentModelCourseModels", new[] { "StudentModel_id" });
            DropIndex("dbo.ProfessorModelCourseModels", new[] { "CourseModel_id" });
            DropIndex("dbo.ProfessorModelCourseModels", new[] { "ProfessorModel_id" });
            DropTable("dbo.StudentModelCourseModels");
            DropTable("dbo.ProfessorModelCourseModels");
            DropTable("dbo.CourseModels");
        }
    }
}
