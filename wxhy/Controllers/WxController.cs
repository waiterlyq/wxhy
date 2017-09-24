using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using wxhy.Models;
using Wxlib;
using Newtonsoft.Json;
using Loglib;

namespace wxhy.Controllers
{
    public class WxController : Controller
    {
        // GET: Wx
        public ActionResult Index()
        {
            string strcode = Request.QueryString["code"];
            if (string.IsNullOrEmpty(strcode))
            {
                return HttpNotFound();
            }

            string wujson = WxUtil.GetWxUserInfo(WxUtil.GetOpenIdAccess_Token(strcode));
            MyLog.writeLog(wujson);
            if (wujson == null)
            {
                return HttpNotFound();
            }
            return RedirectToAction("Create", "lycustomers", new { wu = wujson });
        }

    }
}