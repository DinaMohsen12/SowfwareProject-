
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

        public ActionResult CreateStudent(StudentModel student)
        {
            if (student.id == 0)
            {
                _context.studentDb.Add(student);
            }
            _context.SaveChanges();
            return RedirectToAction("Index", "Home");
        }

        public ActionResult listStudents()
        {
            if(Session["username"] != null)
            {
                var students = _context.studentDb.ToList();
                return View(students);
            }

            else return RedirectToAction("Index", "Home");
        }

        public ActionResult deleteStudent(short id)
        {
            StudentModel student = _context.studentDb.Find(id);
            if (student == null)
                return HttpNotFound();

            return View(student);
        }

        [HttpPost, ActionName("deleteStudent")]
        public ActionResult deleteConfirmed(short id)
        {
            StudentModel student = _context.studentDb.Find(id);
            _context.studentDb.Remove(student);
            _context.SaveChanges();
            return RedirectToAction("listStudents", "Admin");
        }

        //-----------------------------------------------------------Professor-------------------------------------------------------

        public ActionResult addProfessor()
        {
            if (Session["username"] != null)
                return View();

            return RedirectToAction("Login", "Home");
        }

        public ActionResult CreateProfessor(ProfessorModel professor)
        {
            if (professor.id == 0)
            {
                _context.professorDb.Add(professor);
            }
            _context.SaveChanges();
            return RedirectToAction("Index", "Home");
        }

        public ActionResult listProfessors()
        {
            if (Session["username"] != null)
            {
                var professors = _context.professorDb.ToList();
                return View(professors);
            }

            else return RedirectToAction("Index", "Home");
        }
    }
}