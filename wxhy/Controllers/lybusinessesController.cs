using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using wxhy.Models;

namespace wxhy.Controllers
{
    public class lybusinessesController : Controller
    {
        private wxhyEntities db = new wxhyEntities();

        // GET: lybusinesses
        public ActionResult Index()
        {
            return View(db.lybusiness.ToList());
        }

        // GET: lybusinesses/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            lybusiness lybusiness = db.lybusiness.Find(id);
            if (lybusiness == null)
            {
                return HttpNotFound();
            }
            return View(lybusiness);
        }

        // GET: lybusinesses/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: lybusinesses/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "businessId,businessname,logincode,loginpassword")] lybusiness lybusiness)
        {
            if (ModelState.IsValid)
            {
                db.lybusiness.Add(lybusiness);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(lybusiness);
        }

        // GET: lybusinesses/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            lybusiness lybusiness = db.lybusiness.Find(id);
            if (lybusiness == null)
            {
                return HttpNotFound();
            }
            return View(lybusiness);
        }

        // POST: lybusinesses/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "businessId,businessname,logincode,loginpassword")] lybusiness lybusiness)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lybusiness).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(lybusiness);
        }

        // GET: lybusinesses/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            lybusiness lybusiness = db.lybusiness.Find(id);
            if (lybusiness == null)
            {
                return HttpNotFound();
            }
            return View(lybusiness);
        }

        // POST: lybusinesses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            lybusiness lybusiness = db.lybusiness.Find(id);
            db.lybusiness.Remove(lybusiness);
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
