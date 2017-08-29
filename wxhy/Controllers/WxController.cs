using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using wxhy.Models;
using Wxlib;

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
            WxOpenIdAt woa = WxUtil.GetOpenIdAccess_Token(strcode);
            WxUserInfo wu = WxUtil.GetWxUserInfo(woa);
            if(wu==null)
            {
                return HttpNotFound();
            }
            return RedirectToAction("Create", "lycustomers", new { wu = wu });
        }

    }
}