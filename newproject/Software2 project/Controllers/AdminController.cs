
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
            // you have to add this condition for every action of admin 
            if (Session["username"] != null && Session["role"] == "admin")
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
            return RedirectToAction("ListStudents", "Admin");
        }

        public ActionResult listStudents()
        {
            if(Session["username"] != null)
            {
                var students = _context.studentDb.ToList();
                return View(students);
            }

            else return RedirectToAction("Login", "Home");
        }

        public ActionResult deleteStudent(short id)
        {
            if(Session["username"] != null)
            {
                StudentModel student = _context.studentDb.Find(id);
                if (student == null)
                    return HttpNotFound();

                return View(student);
            }

            else return RedirectToAction("Login", "Home");
        }

        [HttpPost, ActionName("deleteStudent")]
        public ActionResult deleteConfirmed(short id)
        {
            if(Session["username"] != null)
            {
                StudentModel student = _context.studentDb.Find(id);
                _context.studentDb.Remove(student);
                _context.SaveChanges();
                return RedirectToAction("listStudents", "Admin");
            }

            else return RedirectToAction("Login", "Home");
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
            return RedirectToAction("ListProfessors", "Admin");
        }

        public ActionResult listProfessors()
        {
            if (Session["username"] != null)
            {
                var professors = _context.professorDb.ToList();
                return View(professors);
            }

            else return RedirectToAction("Login", "Home");
        }

        public ActionResult deleteProfessor(short id)
        {
            if(Session["username"] != null)
            {
                ProfessorModel prof = _context.professorDb.Find(id);
                if (prof == null)
                    return HttpNotFound();

                return View(prof);
            }
            
            else return RedirectToAction("Index", "Home");
        }

        [HttpPost, ActionName("deleteProfessor")]
        public ActionResult deleteConfirmedProf(short id)
        {
            if(Session["usename"] != null)
            {
                ProfessorModel prof = _context.professorDb.Find(id);
                _context.professorDb.Remove(prof);
                _context.SaveChanges();
                return RedirectToAction("listProfessors", "Admin");
            }

            else return RedirectToAction("Index", "Home");
        }
    }
}