using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using System.Web;
using System.Web.Mvc;
using StudentCourseFluentMVCApp.Data;
using StudentCourseFluentMVCApp.Models;

namespace StudentCourseFluentMVCApp.Controllers
{
    public class StudentController : Controller
    {

        // GET: Student
        public ActionResult Index()
        {
            using (var session = NHibernateHelper.CreateSession())
            {
                var students = session.Query<Student>().ToList();
                return View(students);
            }
        }

        public ActionResult Create() {
        
            return View();
        }

        [HttpPost]
        public ActionResult Create(Student student)
        {

            if (student.Course.Id == 0)
                ModelState.Remove("Course.Id");

            if (ModelState.IsValid)
            {
                using (var session = NHibernateHelper.CreateSession())
                {
                    using (var txn = session.BeginTransaction())
                    {
                        student.Course.Student = student;
                        session.Save(student);
                        txn.Commit();
                        return RedirectToAction("Index");
                    }
                }
            }
            else
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors);
                foreach (var error in errors)
                {
                    Console.WriteLine(error.ErrorMessage);
                }

                return View(student);
            }
        }

        public ActionResult Edit(int id)
        {
            using (var session = NHibernateHelper.CreateSession())
            {
                var student = session.Query<Student>().FirstOrDefault(s => s.Id == id);
                return View(student);
            }
        }

        [HttpPost]

        public ActionResult Edit(Student student)
        {
            if (ModelState.IsValid)
            {
                using (var session = NHibernateHelper.CreateSession())
                {
                    using (var txn = session.BeginTransaction())
                    {
                        student.Course.Student = student;
                        session.Update(student);
                        txn.Commit();
                        return RedirectToAction("Index");
                    }
                }
            }
            else
            {
                return View(student);
            }
        }

        public ActionResult Delete(int id)
        {
            using (var session = NHibernateHelper.CreateSession())
            {
                var student = session.Query<Student>().FirstOrDefault(s=>s.Id==id);
                return View(student);
            }
        }

        [HttpPost,ActionName("Delete")]

        public ActionResult DeleteStudent(int id)
        {
            using (var session = NHibernateHelper.CreateSession())
            {
                using (var txn = session.BeginTransaction()){
                    var student = session.Query<Student>().FirstOrDefault(u => u.Id == id);
                    session.Delete(student);
                    txn.Commit();
                    return RedirectToAction("Index");
                }
            }
        }
    }
}