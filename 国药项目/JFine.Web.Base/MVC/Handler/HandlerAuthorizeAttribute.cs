using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JFine.Code.Online;
using JFine.Common.Code;
using JFine.Common.Extend;
using JFine.Common.Web;

namespace JFine.Web.Base.MVC.Handler
{
    public class HandlerAuthorizeAttribute : ActionFilterAttribute
    {
        public HandlerAuthorizeAttribute()
        {

        }
        /// <summary>
        /// 权限校验
        /// </summary>
        /// <param name="filterContext"></param>
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            
        }
    }
}