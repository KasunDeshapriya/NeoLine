using Service.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace NeoLine.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        Context db = new Context();
        public ActionResult Index()
        {
            
            List<Employee> employees = db.Employees.ToList();
            return View(employees);
        }

        public ActionResult Details(int id){
            Employee employee = db.Employees.Find(id);
            return View(employee);
        }

        [HttpGet]
        public ActionResult Edit(int ? id) {
            if (id==null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee emp = db.Employees.Find(id);
            if (emp == null) {
                return HttpNotFound();
            }
            return View(emp);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Employee emp) {
            if (ModelState.IsValid) {
                db.Entry(emp).State = EntityState.Modified; 
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(emp);
        }

        [HttpGet]
        public ActionResult Create() {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Employee emp) {
            if (ModelState.IsValid) {
                db.Employees.Add(emp);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(emp);
        }


        public ActionResult Delete(int ? id) {
            if (id==null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee emp = db.Employees.Find(id);
            if (emp == null) {
                return HttpNotFound();
            }
            return View(emp);
        }

        [HttpPost,ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult ConfirmDelete(int id) {
            Employee emp = db.Employees.Find(id);
            db.Employees.Remove(emp);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}