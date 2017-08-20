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
    public class lycustomersController : Controller
    {
        private wxhyEntities db = new wxhyEntities();

        // GET: lycustomers
        public ActionResult Index()
        {
            return View(db.lycustomer.ToList());
        }

        // GET: lycustomers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            lycustomer lycustomer = db.lycustomer.Find(id);
            if (lycustomer == null)
            {
                return HttpNotFound();
            }
            return View(lycustomer);
        }

        // GET: lycustomers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: lycustomers/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "cstId,businessId,openid,nickname,sex,city,country,province,language,headimgurl,suscribetime,unionid,remark,groupid,tagidlist,csttype,address,storeId,interestproduct,referees")] lycustomer lycustomer)
        {
            if (ModelState.IsValid)
            {
                db.lycustomer.Add(lycustomer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(lycustomer);
        }

        // GET: lycustomers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            lycustomer lycustomer = db.lycustomer.Find(id);
            if (lycustomer == null)
            {
                return HttpNotFound();
            }
            return View(lycustomer);
        }

        // POST: lycustomers/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "cstId,businessId,openid,nickname,sex,city,country,province,language,headimgurl,suscribetime,unionid,remark,groupid,tagidlist,csttype,address,storeId,interestproduct,referees")] lycustomer lycustomer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lycustomer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(lycustomer);
        }

        // GET: lycustomers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            lycustomer lycustomer = db.lycustomer.Find(id);
            if (lycustomer == null)
            {
                return HttpNotFound();
            }
            return View(lycustomer);
        }

        // POST: lycustomers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            lycustomer lycustomer = db.lycustomer.Find(id);
            db.lycustomer.Remove(lycustomer);
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
