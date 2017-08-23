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
            if (!string.IsNullOrEmpty(strcode))
            {
                return null;
            }
            WxOpenIdAt woa = WxUtil.GetOpenIdAccess_Token(strcode);
            WxUserInfo wu = WxUtil.GetWxUserInfo(woa);
            return RedirectToAction("lycustomers", "Create", new { wu = wu });
        }

    }
}