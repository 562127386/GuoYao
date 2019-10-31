using Senparc.Weixin;
using Senparc.Weixin.MP;
using Senparc.Weixin.MP.AdvancedAPIs.CustomService;
using Senparc.Weixin.MP.AdvancedAPIs.Media;
using Senparc.Weixin.MP.AdvancedAPIs.User;
using Senparc.Weixin.MP.CommonAPIs;
using Senparc.Weixin.MP.Containers;
using Senparc.Weixin.MP.Entities;
/********************************************************************************
**文 件 名:WeixinHelper
**命名空间:JFine.Plugins.Unity
**描    述:
**
**版 本 号:V1.0.0.0
**创 建 人:superjoy
**创建日期:2018-09-26 18:05:41
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
using System.Web.Configuration;

namespace JFine.Plugins.Unity
{
    public static class WeixinHelper
    {
        public static string appId = WebConfigurationManager.AppSettings["AppId"];
        public static string appSecret = WebConfigurationManager.AppSettings["AppSecret"];
        public static string WeiXinAccount = WebConfigurationManager.AppSettings["WeiXinAccount"];
        //private static string accessToken = null;
        /// <summary>
        /// 访问凭据
        /// </summary>
        public static string AccessToken
        {
            get
            {
                return AccessTokenContainer.TryGetAccessToken(appId, appSecret);
            }
        }
        public static void Init()
        {
            if (string.IsNullOrWhiteSpace(appId) || string.IsNullOrWhiteSpace(appSecret))
            {
                return;
            }

        }
    }
    public static class DateTimeExtend
    {
        private const long STANDARD_TIME_STAMP = 621355968000000000;

        public static long ConvertToTimeStamp(this DateTime time)
        {
            return (time.ToUniversalTime().Ticks - STANDARD_TIME_STAMP) / 10000000;
        }

        public static DateTime ConvertToDateTime(this long timestamp)
        {
            return new DateTime(timestamp * 10000000 + STANDARD_TIME_STAMP).ToLocalTime();
        }
    }
}
