using JFine.Busines.SystemManage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JFine.Web.Base.MVC.Handler;
using JFine.Code.Online;
using JFine.Cache;
using JFine.Domain.Models.SysConfig;
using JFine.Util;

namespace JFine.Web.Controllers
{
    [HandlerLogin]
    [HandlerSysConfig]
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index(string token)
        {
            var config = CacheFactory.Cache().GetCache<SysConfigEntity>(CacheKeysUtil.SYSCONFIG.ToString());
            OnlineUserModel onliner = JFine.Code.Online.OnlineUser.Operator.GetCurrent();
            ViewBag.onliner = onliner;
            ViewBag.defaultSkin = config.DefaultSkin;
            SysManageBLL sysManageBll = new SysManageBLL();
            if (sysManageBll.VerificationToken(token))
            {
                return View();
            }
            else
            {
                return Redirect("/Login/Index");
            }

        }
        [HttpGet]
        public ActionResult Default()
        {
            return View();
        }
        [HttpGet]
        public ActionResult About()
        {
            return View();
        }
    }
}