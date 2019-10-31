using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;

namespace JFine.Web.FineHub
{
    [HubName("bid")]
    public class BidHub : Hub
    {
        public void Hello()
        {
            Clients.All.hello();
        }
        /// <summary>
        /// 启动竞价
        /// </summary>
        /// <param name="projectnumber"></param>
        /// <param name="nowTime"></param>
        public void BidStart(string projectId, string bidStartTime, string bidEndTime, string delayEndTime)
        {
            // 客户端调用.启动项目竞价
            Clients.All.BidStart(projectId, bidStartTime, bidEndTime, delayEndTime);

        }
    }
}