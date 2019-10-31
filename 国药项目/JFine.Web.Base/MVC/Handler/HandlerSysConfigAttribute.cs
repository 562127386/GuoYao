using JFine.Busines.SysConfig;
using JFine.Code.Online;
using JFine.Domain.Models.SysConfig;
/********************************************************************************
**文 件 名:HandlerSysConfigAttribute
**命名空间:JFine.Web.Base.MVC.Handler
**描    述:对系统参数配置进行校验
**
**版 本 号:V1.0.0.0
**创 建 人:superjoy
**创建日期:2018-08-22 13:20:24
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
    public class HandlerSysConfigAttribute : ActionFilterAttribute
    {
        public HandlerSysConfigAttribute()
        {

        }
        /// <summary>
        /// 系统配置校验
        /// </summary>
        /// <param name="filterContext"></param>
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            OnlineUserModel onliner = OnlineUser.Operator.GetCurrent();
            SysConfigBLL sysConfigBLL = new SysConfigBLL();
            SysConfigEntity sysConfig = sysConfigBLL.GetCurrentConfig();
            if (sysConfig != null)
            {
                //1、判断系统是否处于维护状态
                if (sysConfig.IsMaintenance != null && (bool)sysConfig.IsMaintenance)
                {
                    if (onliner == null || !onliner.IsSystem)
                    {
                        filterContext.HttpContext.Response.Redirect("/Error/Maintenance");
                    }

                }
            }
        }
    }
}
