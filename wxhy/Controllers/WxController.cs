using System.Linq;
using System.Web.Mvc;
using wxhy.Models;
using Wxlib;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Configuration;
using System.Net;
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
            string url = @" https://api.weixin.qq.com/sns/oauth2/access_token?appid=" + appid + "&secret=" + appsecret + "&code=" + strcode + "&grant_type=authorization_code ";
            WebClient wc = new WebClient();
            string strReturn = wc.DownloadString(url);
            JObject jo = (JObject)JsonConvert.DeserializeObject(strReturn);
            var cstinfo = from c in db.lycustomer where c.openid == jo["access_token"].ToString() select c;
            if(cstinfo.Count()>0)
            {
                return RedirectToAction("RegisterSuccess", "lycustomers");
            }
            url = @" https://api.weixin.qq.com/sns/userinfo?access_token=" + jo["access_token"].ToString() + "&openid=" + jo["openid"].ToString() + "&lang=zh_CN ";
            strReturn = Encoding.UTF8.GetString(wc.DownloadData(url));
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