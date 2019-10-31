using JFine.Busines.SystemManage;
using JFine.Code.Online;
using JFine.Common.Config;
using JFine.Common.Web;
using Senparc.Weixin.BrowserUtility;
using Senparc.Weixin.Work.AdvancedAPIs;
using Senparc.Weixin.Work.AdvancedAPIs.OAuth2;
using Senparc.Weixin.Work.CommonAPIs;
using Senparc.Weixin.Work.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JFine.Web.Base.MVC.Handler
{
    public class HandlerLoginAttribute : AuthorizeAttribute
    {
        public HandlerLoginAttribute()
        {
            
        }
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            OnlineUser onlineUser = OnlineUser.Operator;
            if (onlineUser == null) 
            {
                if (filterContext.HttpContext.SideInWeixinBrowser())
                {
                    UserOAuth();
                }
                else 
                {
                    CookieHelper.WriteCookie("jfine_login_error", "overdue");
                    filterContext.HttpContext.Response.Write("<script>top.location.href = '/Login/Index';</script>");
                }
                
            }

            int onlineResult = onlineUser.IsLogin();
            if (onlineResult != 1)
            {
                if (filterContext.HttpContext.SideInWeixinBrowser())
                {
                    UserOAuth();
                }
                else
                {
                    if (onlineResult == -1)
                    {//被顶
                        CookieHelper.WriteCookie("jfine_login_error", "replace");
                        filterContext.HttpContext.Response.Write("<script>top.location.href = '/Login/Index';</script>");

                    }
                    if (onlineResult == -2)
                    {//过期
                        CookieHelper.WriteCookie("jfine_login_error", "overdue");
                        filterContext.HttpContext.Response.Write("<script>top.location.href = '/Login/Index';</script>");
                    }        
                }                     
                
            }
            return;
        }

        /// <summary>
        /// 弃用
        /// </summary>
        /// <param name="code"></param>
        /// <param name="redirecturl"></param>
        public void UserOAuth_old(string code,string redirecturl)
        {
            string Host = ConfigHelper.GetValue("Host");
            string corpId = ConfigHelper.GetValue("qy_corpId");
            string agentId = ConfigHelper.GetValue("qy_agentId");
            string corpSecret = ConfigHelper.GetValue("qy_corpSecret");
            string url = OAuth2Api.GetCode(corpId, Host + "/WeiChat/UserOAuth?redirecturl=" + HttpContext.Current.Request.RawUrl, "", "");
            if (string.IsNullOrWhiteSpace(code))
            {
                HttpContext.Current.Response.Redirect(url);
            }
            else
            {
                HttpContext.Current.Response.Write("登陆失败");
            }

        }

        public void UserOAuth()
        {
            string Host = ConfigHelper.GetValue("Host");
            string corpId = ConfigHelper.GetValue("qy_corpId");
            string url = OAuth2Api.GetCode(corpId, Host + "/WeiChat/UserOAuth?redirecturl=" + HttpContext.Current.Request.RawUrl, "", "");
            HttpContext.Current.Response.Redirect(url);

        }
    }
}