/********************************************************************************
**文 件 名:RoutePublisher
**命名空间:JFine.Web.Base.MVC.Routes
**描    述:
**
**版 本 号:V1.0.0.0
**创 建 人:superjoy
**创建日期:2018-05-20 10:39:00
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
using System.Web.Routing;
using JFine.Infrastructure;
using JFine.Plugin;
using System.Reflection;

namespace JFine.Web.Base.MVC.Routes
{
    /// <summary>
    /// 路由发布
    /// </summary>
    public class RoutePublisher : IRoutePublisher
    {
        protected readonly ITypeFinder typeFinder;


        public RoutePublisher()
        {
           
        }

        public RoutePublisher(ITypeFinder typeFinder)
        {
            this.typeFinder = typeFinder;
        }

        /// <summary>
        /// Find a plugin descriptor by some type which is located into its assembly
        /// </summary>
        /// <param name="providerType">Provider type</param>
        /// <returns>Plugin descriptor</returns>
        protected virtual PluginModel FindPlugin(Type providerType)
        {
            if (providerType == null)
                throw new ArgumentNullException("providerType");

            foreach (var plugin in PluginManager.ReferencedPlugins)
            {
                if (plugin.ReferencedAssembly == null)
                    continue;

                if (plugin.ReferencedAssembly.FullName == providerType.Assembly.FullName)
                    return plugin;
            }

            return null;
        }

        /// <summary>
        /// 注册插件路由
        /// </summary>
        /// <param name="routes">路由集合</param>
        public virtual void RegisterRoutes(RouteCollection routes)
        {
            AppDomainTypeFinder finder = new AppDomainTypeFinder();
            var routeProviderTypes = finder.FindClassesOfType<IRouteProvider>();
            var routeProviders = new List<IRouteProvider>();
            foreach (var providerType in routeProviderTypes)
            {
                var provider = Activator.CreateInstance(providerType) as IRouteProvider;
                routeProviders.Add(provider);
            }
            routeProviders.ForEach(rp => rp.RegisterRoutes(routes));
        }
    }
}
