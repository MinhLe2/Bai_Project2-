using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Bai_Project2__.Models;

namespace Bai_Project2__.Controllers
{
    public class ExamsController : Controller
    {
        private Model_Student_Contex db = new Model_Student_Contex();

        // GET: Exams
        public ActionResult Index(string search,string M, string mark)
        {
            var exams = from a in db.Exams
                        join b in db.Students
                        on a.StudentId equals b.StudentId
                        join c in db.Subjects
                        on a.SubjectId equals c.SubjectId
                        select a;

            if (!String.IsNullOrEmpty(search))
                exams = exams.Where(a => a.Student.StudentName.Contains(search));

            var SubjectList = new List<String>();
            var SubejectSQL = from d in db.Subjects
                              orderby d.SubjectId
                              select d.SubjectName;
            SubjectList.AddRange(SubejectSQL.Distinct());
            ViewBag.M = new SelectList(SubejectSQL);

            if (!String.IsNullOrEmpty(search))
                exams = exams.Where(b => b.Subject.SubjectName.Contains(M));

            var markList = new List<String>() {
                "Do","Truot"
            };
            ViewBag.mark = new SelectList(markList);
            if(!String.IsNullOrEmpty(mark) && mark.Equals("Do"))
            {
                exams = exams.Where(e => e.Mark >= 40);

            }
            else if (!String.IsNullOrEmpty(mark) && mark.Equals("Truot"))
            {
                exams = exams.Where(e => e.Mark <= 40);
            }
            /*ar exams = db.Exams.Include(e => e.Student);*/
            return View(exams.ToList());
        }

        // GET: Exams/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Exam exam = db.Exams.Find(id);
            if (exam == null)
            {
                return HttpNotFound();
            }
            return View(exam);
        }

        // GET: Exams/Create
        public ActionResult Create()
        {
            ViewBag.StudentId = new SelectList(db.Students, "StudentId", "StudentName");
            return View();
        }

        // POST: Exams/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SubjectId,StudentId,Mark")] Exam exam)
        {
            if (ModelState.IsValid)
            {
                db.Exams.Add(exam);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.StudentId = new SelectList(db.Students, "StudentId", "StudentName", exam.StudentId);
            return View(exam);
        }

        // GET: Exams/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Exam exam = db.Exams.Find(id);
            if (exam == null)
            {
                return HttpNotFound();
            }
            ViewBag.StudentId = new SelectList(db.Students, "StudentId", "StudentName", exam.StudentId);
            return View(exam);
        }

        // POST: Exams/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SubjectId,StudentId,Mark")] Exam exam)
        {
            if (ModelState.IsValid)
            {
                db.Entry(exam).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.StudentId = new SelectList(db.Students, "StudentId", "StudentName", exam.StudentId);
            return View(exam);
        }

        // GET: Exams/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Exam exam = db.Exams.Find(id);
            if (exam == null)
            {
                return HttpNotFound();
            }
            return View(exam);
        }

        // POST: Exams/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Exam exam = db.Exams.Find(id);
            db.Exams.Remove(exam);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
