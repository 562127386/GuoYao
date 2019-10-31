using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace JFine.Plugins.Areas.GY
{
    public class TN_XMAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "GY";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "GY_default",
                "GY/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional },
                new string[] { "JFine.Plugins.GY.Areas.GY.Controllers" }
            );
        }
    }
}
