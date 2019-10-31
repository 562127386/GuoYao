using JFine.Plugin;
/********************************************************************************
**文 件 名:HandlerPluginAttribute
**命名空间:JFine.Web.Base.MVC.Handler
**描    述:验证插件状态
**
**版 本 号:V1.0.0.0
**创 建 人:superjoy
**创建日期:2018-06-21 13:16:55
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
    public class HandlerPluginAttribute : AuthorizeAttribute
    {
        private string pluginName = "";
        public HandlerPluginAttribute() 
        {

        }
        public HandlerPluginAttribute(string pluginName)
        {
            this.pluginName = pluginName;
        }

        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            bool flag = PluginManager.IsUseablePlugin(pluginName);
            if(!flag)
            {
                filterContext.HttpContext.Response.Redirect("/Error/Error?number=403&title=禁用&message=该功能被禁用!");
            }
            return;
        }
    }
}
