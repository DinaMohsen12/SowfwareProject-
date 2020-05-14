using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Software2_project.Context;
using Software2_project.Models;
using Software2_project.ViewModel;

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

        public ActionResult viewCourses()
        {
            if (Session["username"] != null && Session["role"].Equals("professor"))
            {
                short id = (short)Session["id"];
                ProfessorModel professor = _context.professorDb.Where(p => p.id == id).Single();
                var CoursesOfProfessor = professor.courseModel.ToList();
                return View(CoursesOfProfessor);
            }

            return RedirectToAction("Login", "Home");
        }

        public ActionResult addQuestion(short id)
        {
            if (Session["username"] != null && Session["role"].Equals("professor"))
            {
                CourseModel course = _context.courseDb.Single(c => c.id == id);

                var viewModel = new QuestionCourseViewModel
                {
                    course = course,
                    question = new QuestionModel { CourseId = course.id }
                };

                return View("addQuestion", viewModel);
            }

            return RedirectToAction("Login", "Home");
        }

        [HttpPost]
        public ActionResult CreateQuestion(QuestionModel Question, string saveE, string newQ)
        {
            if (Question.id == 0)
                _context.questionDb.Add(Question);

            _context.SaveChanges();

            if (saveE != null)
                return RedirectToAction("loggedIn", "Professor");

            else if (newQ != null)
                return RedirectToAction("addQuestion", new RouteValueDictionary(new { Controller = "Professor", Action = "addQuestion", id = Question.CourseId }));

            else return null;
        }
    }
}