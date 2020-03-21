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
    }
}