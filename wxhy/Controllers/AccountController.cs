using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using wxhy.Models;
using Newtonsoft.Json;
using Loglib;

namespace wxhy.Controllers
{
    public class AccountController : Controller
    {
        private wxhyEntities db = new wxhyEntities();
        // GET: Account
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            ViewData["returnUrl"] = HttpUtility.UrlDecode(Request["returnUrl"].ToString());
            return View();
        }

        public string doLogin(string bs)
        {
            lybusiness loginbs = JsonConvert.DeserializeObject<lybusiness>(bs);
            string realPassword = db.lybusiness.Where(a => a.logincode == loginbs.logincode).First<lybusiness>().loginpassword;
            if (loginbs.loginpassword == realPassword)
            {

                HttpCookie newcookie = new HttpCookie("usercode");
                newcookie.Value = loginbs.logincode;
                newcookie.Expires = DateTime.Now.AddDays(5);
                Response.AppendCookie(newcookie);
                return "success";
            }
            return "error";
        }
    }
}