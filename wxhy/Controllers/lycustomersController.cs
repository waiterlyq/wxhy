using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Wxlib;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using wxhy.Models;
using Loglib;

namespace wxhy.Controllers
{
    public class lycustomersController : Controller
    {
        private wxhyEntities db = new wxhyEntities();
        [Authentication]
        // GET: lycustomers
        public ActionResult Index()
        {
            return View(db.lycustomer.ToList());
        }
        [Authentication]
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

        public JsonResult SaveIntegral(string cstint)
        {
           
            JObject cstjo = (JObject)JsonConvert.DeserializeObject(cstint);
            lycustomer lyc = db.lycustomer.Find(int.Parse(cstjo["cstId"].ToString()));
            lyc.integral = int.Parse(cstjo["integral"].ToString());
            db.Entry(lyc).State = EntityState.Modified;
            db.SaveChanges();
            return Json(new {data="success", status = "success" });
        }

        // GET: lycustomers/Create
        //public ActionResult Create()
        //{
        //    lycustomer lyc = new lycustomer();
        //    return View(lyc);
        //}

       
        public ActionResult Create(string  wujson)
        {
            MyLog.writeLog(wujson);
            return View(GetLyCustomer(wujson));
        }
        [Authentication]
        public JsonResult GetCstList(int limit, int offset)
        {
            var total = db.lycustomer.ToList().Count;
            var rows = db.lycustomer.ToList().Skip(offset).Take(limit).ToList();
            return Json(new { total = total, rows = rows }, JsonRequestBehavior.AllowGet);
        }
       
        public lycustomer GetLyCustomer(string wujson)
        {
            WxUserInfo wu = JsonConvert.DeserializeObject<WxUserInfo>(wujson);
            lycustomer lyc = new lycustomer();
            lyc.openid = wu.openid;
            lyc.nickname = wu.nickname;
            lyc.sex = wu.sex;
            lyc.province = wu.province;
            lyc.city = wu.city;
            lyc.country = wu.country;
            lyc.headimgurl = wu.headimgurl;
            return lyc;
        }

        public string SaveCst(string cst)
        {
            lycustomer lyc = JsonConvert.DeserializeObject<lycustomer>(cst);
            db.lycustomer.Add(lyc);
            db.SaveChanges();
            return "success";
        }

        public ActionResult RegisterSuccess()
        {
            return View();
        }

        // POST: lycustomers/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "cstId,businessId,openid,nickname,sex,city,country,province,language,headimgurl,subscribetime,unionid,remark,groupid,tagidlist,csttype,address,store,interestproduct,referees")] lycustomer lycustomer)
        {
            if (ModelState.IsValid)
            {
                db.lycustomer.Add(lycustomer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(lycustomer);
        }
        [Authentication]
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
        [Authentication]
        // POST: lycustomers/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "cstId,businessId,openid,nickname,sex,city,country,province,language,headimgurl,subscribetime,unionid,remark,groupid,tagidlist,csttype,address,store,interestproduct,referees")] lycustomer lycustomer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lycustomer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(lycustomer);
        }
        [Authentication]
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
        [Authentication]
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
