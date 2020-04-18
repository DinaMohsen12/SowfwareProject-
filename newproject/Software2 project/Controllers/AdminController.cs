
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Software2_project.Models;
using Software2_project.Context;
using Software2_project.ViewModel;
using System.Data.Entity;

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
            if (Session["username"] != null && Session["role"].Equals("admin"))
            {
                short id = (short)Session["id"];
                var admin = _context.adminDb.Single(a => a.id == id);
                return View(admin);
            }
            
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
            if (Session["username"] != null && Session["role"].Equals("admin"))
                return View();

            return RedirectToAction("Login", "Home");
        }

        public ActionResult editStudent(short id)
        {
            if (Session["username"] != null && Session["role"].Equals("admin"))
            {
                var student = _context.studentDb.SingleOrDefault(c => c.id == id);
                var listCheckedCourses = student.courseModel.ToList();

                var viewModel = new StudentCourseViewModel
                {
                    student = student,
                    courses = _context.courseDb.ToList(),
                    checkedCourses =  listCheckedCourses
                };

                if (student == null)
                    return HttpNotFound();

                return View("editStudent", viewModel);
            }

            return RedirectToAction("Login", "Home");
        }

        [HttpPost]
        public ActionResult updateStudent(StudentCourseViewModel viewModel)
        {
            var studentInDb = _context.studentDb.Include(p => p.courseModel).Single(p => p.id == viewModel.student.id);
            studentInDb.name = viewModel.student.name;
            studentInDb.phone = viewModel.student.phone;
            studentInDb.e_mail = viewModel.student.e_mail;
            studentInDb.address = viewModel.student.address;
            studentInDb.gender = viewModel.student.gender;
            studentInDb.age = viewModel.student.age;
            studentInDb.username = viewModel.student.username;

            studentInDb.courseModel.Clear();
            for (int i = 0; i < viewModel.courses.Count; i++)
            {
                if (viewModel.courses[i].IsChecked == true)
                {
                    CourseModel course = viewModel.courses[i];
                    var courseInDb = _context.courseDb.Single(p => p.id == course.id);
                    courseInDb.name = course.name;
                    courseInDb.code = course.code;
                    studentInDb.courseModel.Add(courseInDb);
                }
            }

            _context.SaveChanges();
            return RedirectToAction("ListStudents", "Admin");
        }

        public ActionResult CreateStudent(StudentModel student)
        {
            _context.studentDb.Add(student);

            _context.SaveChanges();
            return RedirectToAction("ListStudents", "Admin");
        }

        public ActionResult listStudents()
        {
            if(Session["username"] != null && Session["role"].Equals("admin"))
            {
                var students = _context.studentDb.ToList();
                return View(students);
            }

            else return RedirectToAction("Login", "Home");
        }

        public ActionResult deleteStudent(short id)
        {
            if(Session["username"] != null && Session["role"].Equals("admin"))
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
            if(Session["username"] != null && Session["role"].Equals("admin"))
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
            if (Session["username"] != null && Session["role"].Equals("admin"))
                return View();

            return RedirectToAction("Login", "Home");
        }

        public ActionResult editProfessor(short id)
        {
            if (Session["username"] != null && Session["role"].Equals("admin"))
            {
                var professor = _context.professorDb.SingleOrDefault(c => c.id == id);
                var listCheckedCourses = professor.courseModel.ToList();

                var viewModel = new ProfessorCourseViewModel
                {
                    professor = professor,
                    courses = _context.courseDb.ToList(),
                    checkedCourses = listCheckedCourses
                };

                if (professor == null)
                    return HttpNotFound();

                return View("editProfessor", viewModel);
            }

            return RedirectToAction("Login", "Home");
        }

        [HttpPost]
        public ActionResult updateProfessor(ProfessorCourseViewModel viewModel)
        {
            var professorInDb = _context.professorDb.Include(p => p.courseModel).Single(p => p.id == viewModel.professor.id);
            professorInDb.name = viewModel.professor.name;
            professorInDb.phone = viewModel.professor.phone;
            professorInDb.e_mail = viewModel.professor.e_mail;
            professorInDb.address = viewModel.professor.address;
            professorInDb.gender = viewModel.professor.gender;
            professorInDb.age = viewModel.professor.age;
            professorInDb.username = viewModel.professor.username;
            professorInDb.salary = viewModel.professor.salary;

            professorInDb.courseModel.Clear();
            for (int i = 0; i < viewModel.courses.Count; i++)
            {
                if (viewModel.courses[i].IsChecked == true)
                {
                    CourseModel course = viewModel.courses[i];
                    var courseInDb = _context.courseDb.Single(p => p.id == course.id);
                    courseInDb.name = course.name;
                    courseInDb.code = course.code;
                    professorInDb.courseModel.Add(courseInDb);
                }
            }

            _context.SaveChanges();
            return RedirectToAction("listProfessors", "Admin");
        }

        public ActionResult CreateProfessor(ProfessorModel professor)
        {
            _context.professorDb.Add(professor);
            
            _context.SaveChanges();
            return RedirectToAction("ListProfessors", "Admin");
        }

        public ActionResult listProfessors()
        {
            if (Session["username"] != null && Session["role"].Equals("admin"))
            {
                var professors = _context.professorDb.ToList();
                return View(professors);
            }

            else return RedirectToAction("Login", "Home");
        }

        public ActionResult deleteProfessor(short id)
        {
            if(Session["username"] != null && Session["role"].Equals("admin"))
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
            if(Session["username"] != null && Session["role"].Equals("admin"))
            {
                ProfessorModel prof = _context.professorDb.Find(id);
                _context.professorDb.Remove(prof);
                _context.SaveChanges();
                return RedirectToAction("listProfessors", "Admin");
            }

            else return RedirectToAction("Index", "Home");
        }

        //-------------------------------------------------Course----------------------------------------

        public ActionResult editCourse(short id)
        {
            if (Session["username"] != null && Session["role"].Equals("admin"))
            {
                var course = _context.courseDb.SingleOrDefault(c => c.id == id);
                if (course == null)
                    return HttpNotFound();

                return View("editCourse", course);
            }

            return RedirectToAction("Login", "Home");
        }
        public ActionResult addCourse() {
            if (Session["username"] != null && Session["role"].Equals("admin"))
                return View();

            return RedirectToAction("Login", "Home");

        }
        [HttpPost]
        public ActionResult CreateCourse(CourseModel course)
        {
            if(course.id != 0)
            {
                var courseInDb = _context.courseDb.Single(p => p.id == course.id);
                courseInDb.name = course.name;
                courseInDb.code = course.code;
            }
            else
            {
                _context.courseDb.Add(course);
            }
                 
            _context.SaveChanges();
            return RedirectToAction("ListCourses", "Admin");
        }

        public ActionResult listCourses()
        {
            if (Session["username"] != null && Session["role"].Equals("admin"))
            {
                var courses = _context.courseDb.ToList();
                return View(courses);
            }

            else return RedirectToAction("Login", "Home");
        }

        public ActionResult deleteCourse(short id)
        {
            if (Session["username"] != null && Session["role"].Equals("admin"))
            {
                CourseModel course = _context.courseDb.Find(id);
                if (course == null)
                    return HttpNotFound();

                return View(course);
            }

            else return RedirectToAction("Index", "Home");
        }

        [HttpPost, ActionName("deleteCourse")]
        public ActionResult deleteConfirmedCourse(short id)
        {
            if (Session["username"] != null && Session["role"].Equals("admin"))
            {
                CourseModel course = _context.courseDb.Find(id);
                _context.courseDb.Remove(course);
                _context.SaveChanges();
                return RedirectToAction("listCourses", "Admin");
            }

            else return RedirectToAction("Index", "Home");
        }
    }
}