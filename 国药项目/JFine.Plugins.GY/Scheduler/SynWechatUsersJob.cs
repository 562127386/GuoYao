using JFine.Busines.SystemManage;
using JFine.Common.Config;
using JFine.Data.Repository;
using JFine.Domain.Models.SystemManage;
using JFine.Job;
using Senparc.Weixin.Work.AdvancedAPIs;
using Senparc.Weixin.Work.AdvancedAPIs.MailList;
using Senparc.Weixin.Work.CommonAPIs;
using Senparc.Weixin.Work.Entities;
/********************************************************************************
**文 件 名:SynWechatUsersJob
**命名空间:JFine.Plugins.GY.Scheduler
**描    述:同步企业微信用户Id到本平台
**
**版 本 号:V1.0.0.0
**创 建 人:superjoy
**创建日期:2018-12-08 15:40:06
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

namespace JFine.Plugins.GY.Scheduler
{
    public class SynWechatUsersJob : ITaskJob
    {
        public bool CloseJob(JFine.Domain.Models.SysCommon.Job_ScheduleEntity jobModel)
        {
            throw new NotImplementedException();
        }

        public bool RunJob(Dictionary<string, string> dic_paras, string jobName, string id)
        {
            //获取微信Id为空的用户列表
            StringBuilder sql = new StringBuilder();
            long deptId = long.Parse(dic_paras["@deptId"].ToString());
            UserBLL userBLL = new UserBLL();
            List<UserExpand> userList = userBLL.GetUserList(new StringBuilder(" AND (WeChatID is null or WeChatID = '') ")).ToList();
            if (userList != null && userList.Count > 0)
            {
                string corpId = ConfigHelper.GetValue("qy_corpId");
                string agentId = ConfigHelper.GetValue("qy_agentId");//应用Id
                string corpSecret = ConfigHelper.GetValue("qy_corpSecret");//应用Secret
                string contactSecret = ConfigHelper.GetValue("qy_contactSecret");//通讯录Secret
                //获取token
                AccessTokenResult tokenResult = CommonApi.GetToken(corpId, contactSecret);
                //GetDepartmentListResult deptListResult = MailListApi.GetDepartmentList(tokenResult.access_token);
                //foreach (var dept in deptListResult.department) 
                //{
                //    GetDepartmentMemberResult deptMemberResult = MailListApi.GetDepartmentMember(tokenResult.access_token, dept.id, 0);
                //}
                GetDepartmentMemberInfoResult deptMemberResult = MailListApi.GetDepartmentMemberInfo(tokenResult.access_token, deptId, 1);
                if (deptMemberResult != null && deptMemberResult.userlist.Count > 0)
                {
                    foreach (var user in userList)
                    {
                        var member = deptMemberResult.userlist.FirstOrDefault(t => t.mobile.Equals(user.MobilePhone));
                        if (member != null)
                        {
                            sql.Append("update Sys_User set WeChatID = '" + member.userid + "' where Id = '" + user.Id + "';");
                        }
                    }
                }
                JFine.Data.Repository.IRepositoryBase db = new RepositoryFactory().BaseRepository();
                db.ExecuteBySql(sql.ToString());
            }

            return true;
        }

        public bool RunJobBefore(JFine.Domain.Models.SysCommon.Job_ScheduleEntity jobModel)
        {
            throw new NotImplementedException();
        }
    }
}
