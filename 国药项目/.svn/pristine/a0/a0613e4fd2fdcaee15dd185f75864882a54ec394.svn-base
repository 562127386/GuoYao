using JFine.Busines.SysConfig;
using JFine.Busines.SystemManage;
using JFine.Cache;
using JFine.Code.Online;
using JFine.Domain.Models.SysConfig;
using JFine.Domain.Models.SystemManage;
using JFine.Util;
using JFine.Web.Base.MVC.Routes;
/********************************************************************************
**文 件 名:ApplicationBLL
**命名空间:JFine.Web.App_Start.Handler
**描    述:应用级业务处理
**
**版 本 号:V1.0.0.0
**创 建 人:superjoy
**创建日期:2018-05-12 21:46:11
**修 改 人:
**修改日期:
**修改描述:
**版权所有: ©为之团队
*********************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Web;
using System.Web.Routing;

namespace JFine.Web.App_Start
{
    public class ApplicationBLL
    {
        private OnlineUser onlineBll = new OnlineUser();
        private SysConfigBLL sysConfigBLL = new SysConfigBLL();
        /// <summary>
        /// 缓存初始化
        /// </summary>
        public void InitCache()
        {
            #region 组织机构
            OrganizeBLL organizeBLL = new OrganizeBLL();
            List<OrganizeEntity> orgList = organizeBLL.GetList().ToList();
            CacheFactory.Cache().WriteCache<List<OrganizeEntity>>(CacheKeysUtil.ORG.ToString(), orgList, false);
            #endregion
            
            #region 系统配置
            string configQuery = "{\"Code\":\"" + ConstantUtil.CODE_SYS + "\"}";
            List<SysConfigEntity> configList = sysConfigBLL.GetList(configQuery).ToList();
            if (configList != null && configList.Count > 0) 
            {
                CacheFactory.Cache().WriteCache<SysConfigEntity>(CacheKeysUtil.SYSCONFIG.ToString(), configList[0], false);
            }
            
            #endregion
        }

        #region 在线用户处理

        /// <summary>
        /// 启动检查操作Session用户队列
        /// </summary>
        public void StartCheckOnlineQueue()
        {
            OnlineUser.Operator.CheckOnlineQueue();
        }

        /// <summary>
        /// 启动检查在线用户是否超期
        /// </summary>
        public void StartCheckOnLineIsOverdue()
        {
            CheckOnlineList();
        }


        /// <summary>
        /// 检测在线列表，超期用户移出列表
        /// </summary>
        private void CheckOnlineList()
        {
            ThreadPool.QueueUserWorkItem((a) =>
            {
                while (true)
                {
                    var onlinerList = onlineBll.GetOnlinerAll();
                    if (onlinerList != null)
                    {
                        //默认90分钟
                        var onlinerOverDue = onlinerList.Where(t => t.SessionStartTime.AddMinutes(90) < DateTime.Now).ToList();
                        if (onlinerOverDue != null && onlinerOverDue.Count > 0)
                        {
                            //删除超期用户
                            foreach (var onliner in onlinerOverDue)
                            {
                                onlineBll.DelUserFromCacheList(onliner.SessionId);
                            }
                        }
                        else
                        {
                            //如果没有用户超期，休眠5分钟.
                            Thread.Sleep(300000);
                        }
                    }
                    else
                    {
                        //如果没有数据，休眠10分钟.
                        Thread.Sleep(600000);
                    }

                }
            });
        }

        #endregion

        #region 插件路由注册
        public void RegistPluginRoutes() 
        {
            RoutePublisher rp = new RoutePublisher();
            rp.RegisterRoutes(RouteTable.Routes);
        }
        #endregion


        /// <summary>
        /// 重新加载缓存
        /// </summary>
        public void ReloadCache() 
        {

        }
    }
}