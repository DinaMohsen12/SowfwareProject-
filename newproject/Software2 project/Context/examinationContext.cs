using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Software2_project.Models;
using System.Data.Entity;

namespace Software2_project.Context
{
    public class examinationContext : DbContext
    {
        public DbSet<AdminModel> adminDb { get; set; }
        public DbSet<StudentModel> studentDb { get; set; }
        public DbSet<ProfessorModel> professorDb { get; set; }
        public DbSet<CourseModel> courseDb { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }


    }
}