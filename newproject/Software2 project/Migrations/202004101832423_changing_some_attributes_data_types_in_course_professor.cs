namespace Software2_project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changing_some_attributes_data_types_in_course_professor : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ProfessorModelCourseModels", "CourseModel_id", "dbo.CourseModels");
            DropForeignKey("dbo.StudentModelCourseModels", "CourseModel_id", "dbo.CourseModels");
            DropIndex("dbo.ProfessorModelCourseModels", new[] { "CourseModel_id" });
            DropIndex("dbo.StudentModelCourseModels", new[] { "CourseModel_id" });
            DropPrimaryKey("dbo.CourseModels");
            DropPrimaryKey("dbo.ProfessorModelCourseModels");
            DropPrimaryKey("dbo.StudentModelCourseModels");
            AlterColumn("dbo.CourseModels", "id", c => c.Short(nullable: false, identity: true));
            AlterColumn("dbo.ProfessorModels", "salary", c => c.Double(nullable: false));
            AlterColumn("dbo.ProfessorModelCourseModels", "CourseModel_id", c => c.Short(nullable: false));
            AlterColumn("dbo.StudentModelCourseModels", "CourseModel_id", c => c.Short(nullable: false));
            AddPrimaryKey("dbo.CourseModels", "id");
            AddPrimaryKey("dbo.ProfessorModelCourseModels", new[] { "ProfessorModel_id", "CourseModel_id" });
            AddPrimaryKey("dbo.StudentModelCourseModels", new[] { "StudentModel_id", "CourseModel_id" });
            CreateIndex("dbo.ProfessorModelCourseModels", "CourseModel_id");
            CreateIndex("dbo.StudentModelCourseModels", "CourseModel_id");
            AddForeignKey("dbo.ProfessorModelCourseModels", "CourseModel_id", "dbo.CourseModels", "id", cascadeDelete: true);
            AddForeignKey("dbo.StudentModelCourseModels", "CourseModel_id", "dbo.CourseModels", "id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.StudentModelCourseModels", "CourseModel_id", "dbo.CourseModels");
            DropForeignKey("dbo.ProfessorModelCourseModels", "CourseModel_id", "dbo.CourseModels");
            DropIndex("dbo.StudentModelCourseModels", new[] { "CourseModel_id" });
            DropIndex("dbo.ProfessorModelCourseModels", new[] { "CourseModel_id" });
            DropPrimaryKey("dbo.StudentModelCourseModels");
            DropPrimaryKey("dbo.ProfessorModelCourseModels");
            DropPrimaryKey("dbo.CourseModels");
            AlterColumn("dbo.StudentModelCourseModels", "CourseModel_id", c => c.Int(nullable: false));
            AlterColumn("dbo.ProfessorModelCourseModels", "CourseModel_id", c => c.Int(nullable: false));
            AlterColumn("dbo.ProfessorModels", "salary", c => c.Single(nullable: false));
            AlterColumn("dbo.CourseModels", "id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.StudentModelCourseModels", new[] { "StudentModel_id", "CourseModel_id" });
            AddPrimaryKey("dbo.ProfessorModelCourseModels", new[] { "ProfessorModel_id", "CourseModel_id" });
            AddPrimaryKey("dbo.CourseModels", "id");
            CreateIndex("dbo.StudentModelCourseModels", "CourseModel_id");
            CreateIndex("dbo.ProfessorModelCourseModels", "CourseModel_id");
            AddForeignKey("dbo.StudentModelCourseModels", "CourseModel_id", "dbo.CourseModels", "id", cascadeDelete: true);
            AddForeignKey("dbo.ProfessorModelCourseModels", "CourseModel_id", "dbo.CourseModels", "id", cascadeDelete: true);
        }
    }
}
