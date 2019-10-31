using JFine.Code.Online;
using JFine.Common.Web;
/********************************************************************************
**文 件 名:HandlerIsSystemAttribute
**命名空间:JFine.Web.Base.MVC.Handler
**描    述:验证是否为系统用户
**
**版 本 号:V1.0.0.0
**创 建 人:superjoy
**创建日期:2018-09-08 16:01:16
**修 改 人:
**修改日期:
**修改描述:
**版权所有: ©为之团队
*********************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace JFine.Web.Base.MVC.Handler
{
    public class HandlerIsSystemAttribute : AuthorizeAttribute
    {
        public HandlerIsSystemAttribute() 
        {

        }

        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            OnlineUserModel onlineUser = OnlineUser.Operator.GetCurrent();
            if (onlineUser == null)
            {
                CookieHelper.WriteCookie("jfine_login_error", "overdue");
                filterContext.HttpContext.Response.Write("<script>top.location.href = '/Login/Index';</script>");
            }
            else 
            {
                if (!onlineUser.IsSystem) 
                {
                    filterContext.HttpContext.Response.Redirect("/Error/Error?number=401&title=无权限&message=权限不足，不能进行该操作!");
                }
            }
            return;
        }
    }
}
