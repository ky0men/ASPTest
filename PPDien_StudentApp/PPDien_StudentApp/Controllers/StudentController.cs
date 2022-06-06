using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PPDien_StudentApp.Models;
using System.Data.Entity;

namespace PPDien_StudentApp.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        public ActionResult Index()
        {
            var StudentList = new DBStudentConnectionString().Students.Include(c =>c.Batch).ToList();
            return View(StudentList);
        }

        // GET: Student/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Student/Create
        public ActionResult Create()
        {
            var context = new DBStudentConnectionString();
            var batchSelect = new SelectList(context.Batches, "ID", "BatchName");
            ViewBag.BatchName = batchSelect;
            return View();
        }

        // POST: Student/Create
        [HttpPost]
        public ActionResult Create(Student model)
        {
            try
            {
                // TODO: Add insert logic here
                var context = new DBStudentConnectionString();
                context.Students.Add(model);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Student/Edit/5
        public ActionResult Edit(int id)
        {
            var context = new DBStudentConnectionString();
            var editing = context.Students.Find(id);
            var batchSelect = new SelectList(context.Batches, "ID", "BatchName", editing.BachtID);
            ViewBag.BatchName = batchSelect;
            return View(editing);
        }

        // POST: Student/Edit/5
        [HttpPost]
        public ActionResult Edit(Student model)
        {
            try
            {
                // TODO: Add update logic here
                var context = new DBStudentConnectionString();
                var oldItem = context.Students.Find(model.ID);
                oldItem.StudentName = model.StudentName;
                oldItem.Gender = model.Gender;
                oldItem.Birthday = model.Birthday;
                oldItem.Phone = model.Phone;
                oldItem.Email = model.Email;
                oldItem.BachtID = model.BachtID;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Student/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Student/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
