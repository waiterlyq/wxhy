﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using wxhy.Models;

namespace wxhy.Controllers
{
    [Authentication]
    public class lystoresController : Controller
    {
        private wxhyEntities db = new wxhyEntities();

        // GET: lystores
        public ActionResult Index()
        {
            return View(db.lystore.ToList());
        }

        public string GetStoresList()
        {
            return JsonConvert.SerializeObject(db.lystore.ToList());
        }

        public JsonResult GetStoreList(int limit, int offset)
        {
            var total = db.lystore.ToList().Count;
            var rows = db.lystore.ToList().Skip(offset).Take(limit).ToList();
            return Json(new { total = total, rows = rows }, JsonRequestBehavior.AllowGet);
        }

        // GET: lystores/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            lystore lystore = db.lystore.Find(id);
            if (lystore == null)
            {
                return HttpNotFound();
            }
            return View(lystore);
        }

        // GET: lystores/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: lystores/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "storeId,businessId,address,name,remark")] lystore lystore)
        {
            if (ModelState.IsValid)
            {
                db.lystore.Add(lystore);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(lystore);
        }

        // GET: lystores/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            lystore lystore = db.lystore.Find(id);
            if (lystore == null)
            {
                return HttpNotFound();
            }
            return View(lystore);
        }

        // POST: lystores/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "storeId,businessId,address,name,remark")] lystore lystore)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lystore).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(lystore);
        }

        // GET: lystores/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            lystore lystore = db.lystore.Find(id);
            if (lystore == null)
            {
                return HttpNotFound();
            }
            return View(lystore);
        }

        public string StoreDelete(int? id)
        {
            try
            {
                lystore lystore = db.lystore.Find(id);
                db.lystore.Remove(lystore);
                db.SaveChanges();
                return "OK";
            }
            catch
            {
                return "NO";
            }
        }

        // POST: lystores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            lystore lystore = db.lystore.Find(id);
            db.lystore.Remove(lystore);
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
