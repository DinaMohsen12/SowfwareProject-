
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Software2_project.Models;
using Software2_project.Context;

namespace Software2_project.Controllers
{
    public class AdminController : Controller
    {
        private examinationContext _context;
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        public AdminController()
        {
            _context = new examinationContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult LoggedIn()
        {
            if (Session["username"] != null)
                return View();

            return RedirectToAction("Login", "Home");
        }

        public ActionResult Logout()
        {
            Session.RemoveAll();
            return RedirectToAction("Login", "Home");
        }

        //------------------------------------------------------------Student--------------------------------------------------------

        public ActionResult addStudent()
        {
            if (Session["username"] != null)
                return View();

            return RedirectToAction("Login", "Home");
        }

        public ActionResult Create(StudentModel student)
        {
            if (student.id == 0)
            {
                _context.studentDb.Add(student);
            }
            _context.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
    }
}