using Sduo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sduo.Controllers
{
    public class StudentEnrollmentsController : Controller
    {
        private Entities db = new Entities();
        //
        // GET: /StudentEnrollments/

        public ActionResult Index(int studentId)
        {
            Student student = db.Students.Find(studentId);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        //
        // GET: /StudentEnrollments/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /StudentEnrollments/Enroll

        public ActionResult Enroll(int studentId)
        {
            Student student = db.Students.Find(studentId);
            if (student == null)
            {
                return HttpNotFound();
            }

            ViewBag.Courses = new SelectList(db.Courses.ToList().Where(c => !student.Courses.Contains(c)), "Id", "Code");

            return View(student);
        }

        //
        // POST: /StudentEnrollments/Enroll

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Enroll(Student student)
        {
            if (ModelState.IsValid)
            {
                student = db.Students.Find(student.Id);
                if (student == null)
                {
                    return HttpNotFound();
                }
                int courseId = int.Parse(this.Request.Form["Course"]);
                Course course = db.Courses.Find(courseId);
                if (course == null)
                {
                    return HttpNotFound();
                }

                student.Courses.Add(course);

                db.SaveChanges();

                return RedirectToAction("Index", new { studentId = student.Id });
            }

            return View(student);
        }

        //
        // POST: /StudentEnrollments/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /StudentEnrollments/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /StudentEnrollments/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /StudentEnrollments/Delete/5

        public ActionResult Withdraw(int studentId, int courseId)
        {
            Student student = db.Students.Find(studentId);
            if (student == null)
            {
                return HttpNotFound();
            }
            Course course = db.Courses.Find(courseId);
            if (course == null)
            {
                return HttpNotFound();
            }

            ViewBag.CourseId = course.Id;
            ViewBag.CourseCode = course.Code;

            return View(student);
        }

        //
        // POST: /StudentEnrollments/Withdraw/5

        [HttpPost, ActionName("Withdraw")]
        [ValidateAntiForgeryToken]
        public ActionResult WithdrawConfirmed(int studentId, int courseId)
        {
            Student student = db.Students.Find(studentId);
            if (student == null)
            {
                return HttpNotFound();
            }

            Course course = db.Courses.Find(courseId);
            if (course == null)
            {
                return HttpNotFound();
            }

            student.Courses.Remove(course);
            db.SaveChanges();

            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index", new { studentId = student.Id });
            }
            catch
            {
                return View();
            }
        }
    }
}
