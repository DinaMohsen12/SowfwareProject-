using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Software2_project.Models;
using Software2_project.Context;

namespace Software2_project.Controllers
{
    
    public class HomeController : Controller
    {
        examinationContext DB = new examinationContext();
        public ActionResult Index()
        {
            return View();
        }

        private examinationContext _context;
        public ActionResult Login()
        {
            return View();
        }

        public HomeController()
        {
            _context = new examinationContext();
        }

        public ActionResult About()
        {
            ViewBag.Message = "This web application helps you to manage college and its exams.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult LoginConfirmmed(Login lg)
        {
            if (ModelState.IsValid)
            {
                using (_context)
                {
                    var logStudent = _context.studentDb.Where(a => a.username.Equals(lg.username) && a.password.Equals(lg.password)).FirstOrDefault();
                    var logProfessor = _context.professorDb.Where(a => a.username.Equals(lg.username) && a.password.Equals(lg.password)).FirstOrDefault();
                    var logAdmin = _context.adminDb.Where(a => a.username.Equals(lg.username) && a.password.Equals(lg.password)).FirstOrDefault();
                    if (logStudent != null)
                    {
                        Session["username"] = logStudent.username;
                        Session["role"] = logStudent.role;
                        Session["id"] = logStudent.id;
                        return RedirectToAction("LoggedIn", "Student");
                    }
                    else if (logProfessor != null)
                    {
                        Session["username"] = logProfessor.username;
                        Session["role"] = logProfessor.role;
                        Session["id"] = logProfessor.id;
                        return RedirectToAction("LoggedIn", "Professor");
                    }
                    else if (logAdmin != null)
                    {
                        Session["username"] = logAdmin.username;
                        Session["role"] = logAdmin.role;
                        Session["id"] = logAdmin.id;
                        return RedirectToAction("LoggedIn", "Admin");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Username or Password undefiend");
                    }
                }
            }
            return View("Login");
        }

        public ActionResult listCourses()
        {
            var courses = _context.courseDb.ToList();
            return View(courses);
        }
    }
}