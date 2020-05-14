using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Software2_project.Context;

namespace Software2_project.Controllers
{
    public class ProfessorController : Controller
    {
        examinationContext _context = new examinationContext();
        // GET: Professor
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult LoggedIn()
        {
            if (Session["username"] != null && Session["role"].Equals("professor"))
            {
                short id = (short)Session["id"];
                var professor = _context.professorDb.Single(a => a.id == id);
                return View(professor);
            }

            return RedirectToAction("Login", "Home");
        }
    }
}