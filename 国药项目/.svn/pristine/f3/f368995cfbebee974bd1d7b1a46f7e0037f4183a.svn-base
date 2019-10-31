using JFine.Code;
using JFine.Log;
using JFine.Common.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JFine.Code.Online;
using JFine.Common.Web;
using JFine.Common.Code;

namespace JFine.Web.Base.MVC.Handler
{
    public class HandlerErrorAttribute : HandleErrorAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            base.OnException(context);
            context.ExceptionHandled = true;
            context.HttpContext.Response.StatusCode = 200;
            context.Result = new ContentResult { Content = new AjaxResult { state = ResultType.error.ToString(), message = context.Exception.Message }.ToJson() };
            WriteLog(context);
        }
        private void WriteLog(ExceptionContext context)
        {
            if (context == null)
                return;
            var log = LogFactory.GetLogger(context.Controller.ToString());
            LogMessage logMessage = new LogMessage();
            OnlineUserModel user = OnlineUser.Operator.GetCurrent();
            logMessage.Time = DateTimeHelper.ShortDateTimeS;
            logMessage.Account = (user == null) ? "无登陆信息" : user.Account;
            logMessage.UserName = (user == null) ? "无登陆信息" : user.UserName;
            logMessage.Ip = (user == null) ? RequestHelper.Ip : user.IP;
            logMessage.System = (user == null) ? RequestHelper.GetClientOSName() : user.System;
            logMessage.Browser = (user == null) ? RequestHelper.Browser : user.Browser;
            logMessage.Url = RequestHelper.GetScriptUrl;
            logMessage.Content = context.Exception.InnerException == null ? context.Exception.Message : context.Exception.InnerException.Message;
            logMessage.ExceptionMessage = context.Exception.Message;
            logMessage.ExceptionTrace = context.Exception.StackTrace;
            log.Error(logMessage.ToString());
        }
    }
}