using System;
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
    public class lyproductsController : Controller
    {
        private wxhyEntities db = new wxhyEntities();

        // GET: lyproducts
        public ActionResult Index()
        {
            return View(db.lyproduct.ToList());
        }

        public string GetProductsList()
        {
            return JsonConvert.SerializeObject(db.lyproduct.ToList());
        }

        public JsonResult GetProList(int limit, int offset)
        {
            var total = db.lyproduct.ToList().Count;
            var rows = db.lyproduct.ToList().Skip(offset).Take(limit).ToList();
            return Json(new { total = total, rows = rows }, JsonRequestBehavior.AllowGet);
        }

        // GET: lyproducts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            lyproduct lyproduct = db.lyproduct.Find(id);
            if (lyproduct == null)
            {
                return HttpNotFound();
            }
            return View(lyproduct);
        }

        // GET: lyproducts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: lyproducts/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "proId,code,businessId,name,remark")] lyproduct lyproduct)
        {
            if (ModelState.IsValid)
            {
                db.lyproduct.Add(lyproduct);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(lyproduct);
        }

        // GET: lyproducts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            lyproduct lyproduct = db.lyproduct.Find(id);
            if (lyproduct == null)
            {
                return HttpNotFound();
            }
            return View(lyproduct);
        }

        // POST: lyproducts/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "proId,code,businessId,name,remark")] lyproduct lyproduct)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lyproduct).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(lyproduct);
        }

        // GET: lyproducts/Delete/5
        public string ProDelete(int? id)
        {
            try
            {
                lyproduct lyproduct = db.lyproduct.Find(id);
                db.lyproduct.Remove(lyproduct);
                db.SaveChanges();
                return "OK";
            }
            catch
            {
                return "NO";
            }
            
        }



        // POST: lyproducts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            lyproduct lyproduct = db.lyproduct.Find(id);
            db.lyproduct.Remove(lyproduct);
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
