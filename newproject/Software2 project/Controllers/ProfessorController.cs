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
                return RedirectToAction("listExams", "Professor");

            else if (newQ != null)
                return RedirectToAction("addQuestion", new RouteValueDictionary(new { Controller = "Professor", Action = "addQuestion", id = Question.CourseId }));

            else return null;
        }

        public ActionResult editExam(short id)
        {
            if (Session["username"] != null && Session["role"].Equals("professor"))
            {
                var questions = _context.questionDb.Where(q => q.CourseId == id).ToList();
                CourseModel course = _context.courseDb.Single(c => c.id == id);

                var viewModel = new CourseQuestionsViewModel
                {
                    course = course,
                    questions = questions
                };

                return View(viewModel);
            }

            return RedirectToAction("login", "Home");
        }

        public ActionResult updateExam(List<QuestionModel> questions)
        {
            foreach (var counter in questions)
            {
                var question = _context.questionDb.Where(q => q.id == counter.id).FirstOrDefault();
                question.question = counter.question;
                question.answer1 = counter.answer1;
                question.answer2 = counter.answer2;
                question.answer3 = counter.answer3;
                question.answer4 = counter.answer4;
                question.answer5 = counter.answer5;
                question.rightAnswer = counter.rightAnswer;
                question.CourseId = counter.CourseId;
            }

            _context.SaveChanges();
            var professorId = (short)Session["id"];
            ProfessorModel professor = _context.professorDb.Find(professorId);
            var courses = professor.courseModel.ToList();
            return View("listExams", courses);
        }

        public ActionResult editProfessorProfile(short id)
        {
            if (Session["username"] != null && Session["role"].Equals("professor"))
            {
                ProfessorModel professor = _context.professorDb.Find(id);
                return View(professor);
            }

            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public ActionResult updateProfessorProfile(ProfessorModel professor)
        {
            if (Session["username"] != null && Session["role"].Equals("professor"))
            {
                var professorInDb = _context.professorDb.Single(p => p.id == professor.id);
                professorInDb.name = professor.name;
                professorInDb.phone = professor.phone;
                professorInDb.e_mail = professor.e_mail;
                professorInDb.address = professor.address;
                professorInDb.gender = professor.gender;
                professorInDb.age = professor.age;
                professorInDb.username = professor.username;

                _context.SaveChanges();
                return RedirectToAction("editProfessorProfile", new RouteValueDictionary(new { Controller = "Professor", Action = "editProfessorProfile", id = professor.id }));
            }

            return RedirectToAction("Index", "Home");
        }

        public ActionResult deleteExam(short id)
        {
            if (Session["username"] != null && Session["role"].Equals("professor"))
            {
                CourseModel course = _context.courseDb.Find(id);

                if (course == null)
                    return HttpNotFound();

                return View(course);
            }

            return RedirectToAction("login", "Home");
        }

        [HttpPost, ActionName("deleteExam")]
        public ActionResult deleteConfirmedExam(short id)
        {
            if (Session["username"] != null && Session["role"].Equals("professor"))
            {
                var questions = _context.questionDb.Where(q => q.CourseId == id).ToList();
                for (int i = 0; i < questions.Count(); i++)
                    _context.questionDb.Remove(questions[i]);

                _context.SaveChanges();
                return RedirectToAction("listExams", "Professor");
            }

            return RedirectToAction("login", "Home");
        }

        public ActionResult deleteQuestion(short id)
        {
            if (Session["username"] != null && Session["role"].Equals("professor"))
            {
                QuestionModel question = _context.questionDb.Find(id);
                if (question == null)
                    return HttpNotFound();

                return View(question);
            }

            else return RedirectToAction("Index", "Home");
        }

        [HttpPost, ActionName("deleteQuestion")]
        public ActionResult deleteConfirmedQuestion(short id)
        {
            if (Session["username"] != null && Session["role"].Equals("professor"))
            {
                QuestionModel question = _context.questionDb.Find(id);
                _context.questionDb.Remove(question);
                _context.SaveChanges();
                return RedirectToAction("editExam", new RouteValueDictionary(new { Controller = "Professor", Action = "editExam", id = question.CourseId }));
            }

            else return RedirectToAction("login", "Home");
        }

        public ActionResult listExams()
        {
            if (Session["username"] != null && Session["role"].Equals("professor"))
            {
                var professorId = (short)Session["id"];
                ProfessorModel professor = _context.professorDb.Find(professorId);
                var courses = professor.courseModel.ToList();
                return View(courses);
            }

            return RedirectToAction("login", "Home");
        }

        public ActionResult viewExam (short id)
        {
            if (Session["username"] != null && Session["role"].Equals("professor"))
            {
                var questions = _context.questionDb.Where(q => q.CourseId == id).ToList();
                CourseModel course = _context.courseDb.Single(c => c.id == id);

                var viewModel = new CourseQuestionsViewModel
                {
                    course = course,
                    questions = questions
                };

                return View(viewModel);
            }

            return RedirectToAction("login", "Home");
        }
    }
}