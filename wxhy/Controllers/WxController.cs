using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using wxhy.Models;
using Wxlib;
using Newtonsoft.Json;
using System.Configuration;
using System.Net;
using System.IO;
using Loglib;
using System.Text;

namespace wxhy.Controllers
{
    public class WxController : Controller
    {
        private wxhyEntities db = new wxhyEntities();
        // GET: Wx
        public ActionResult Index()
        {
            string strcode = Request.QueryString["code"];
            MyLog.writeLog(strcode);
            if (string.IsNullOrEmpty(strcode))
            {
                return HttpNotFound();
            }
            string appid = ConfigurationManager.AppSettings["appid"];
            string appsecret = ConfigurationManager.AppSettings["appsecret"];
            MyLog.writeLog(appid);
            MyLog.writeLog(appsecret);
            string url = @" https://api.weixin.qq.com/sns/oauth2/access_token?appid=" + appid + "&secret=" + appsecret + "&code=" + strcode + "&grant_type=authorization_code ";
            MyLog.writeLog(url);
            WebClient wc = new WebClient();
            string strReturn = wc.DownloadString(url);
            MyLog.writeLog(strReturn);
            WxOpenIdAt woa = JsonConvert.DeserializeObject<WxOpenIdAt>(strReturn);
            url = @" https://api.weixin.qq.com/sns/userinfo?access_token=" + woa.access_token + "&openid=" + woa.openid + "&lang=zh_CN ";
            MyLog.writeLog(url);
            strReturn = wc.DownloadString(url);
            
            //string wujson = WxUtil.GetWxUserInfo(WxUtil.GetOpenIdAccess_Token(strcode));
            //MyLog.writeLog(wujson);
            //if (wujson == null)
            //{
            //    return HttpNotFound();
            //}
            strReturn = Encoding.UTF8.GetString(Encoding.ASCII.GetBytes(strReturn));
            MyLog.writeLog(strReturn);
            return RedirectToAction("Create", "lycustomers",new { wujson = strReturn });
        }

        public string GetProductsList()
        {
            return JsonConvert.SerializeObject(db.lyproduct.ToList());
        }

        public string GetStoresList()
        {
            return JsonConvert.SerializeObject(db.lystore.ToList());
        }
    }
}