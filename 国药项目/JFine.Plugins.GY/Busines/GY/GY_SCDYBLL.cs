
/********************************************************************************
**文 件 名:GY_SCDYBLL
**命名空间:JFine.Plugins.GY.Busines.GY
**描    述:
**
**
**版 本 号:V1.0.0.0
**创 建 人:此代码由T4模板自动生成
**创建日期:2018-12-22 10:15:08
**修 改 人:
**修改日期:
**修改描述:
**
**
**版权所有: ©为之团队
*********************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JFine.Plugins.GY.Domain.Models.GY;
using JFine.Plugins.GY.Domain.IRepository.GY;
using JFine.Plugins.GY.Domain.Repository.GY;
using JFine.Cache;
using JFine.Common.UI;
using JFine.Common.Extend;
using JFine.Common.Json;
using JFine.Data.Common;
using System.Linq.Expressions;
using System.Data.Common;
using System.Data;
using JFine.Code.Online;
using JFine.Common.Code;

namespace JFine.Plugins.GY.Busines.GY
{	
	/// <summary>
	/// GY_SCDYBLL
	/// </summary>	
	public class GY_SCDYBLL
	{
	    private IGY_SCDYRepository service=new GY_SCDYRepository();

		/// <summary>
        /// 缓存key
        /// </summary>
        public string cacheKey ="GY_SCDYCache" ;

        #region 数据获取

        /// <summary>
        /// 列表
        /// </summary>
        /// <returns></returns>
        public IEnumerable<GY_SCDYEntity> GetList()
        {
            return service.GetList();
        }

		/// <summary>
        /// 列表
        /// </summary>
        /// <returns></returns>
        public IEnumerable<GY_SCDYEntity> GetListBySql( string sqlWhere)
        {
			return service.GetListBySql(sqlWhere);
        }

		/// <summary>
        /// 列表--分页
        /// </summary>
        /// <param name="pagination">分页</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        public IEnumerable<GY_SCDYEntity> GetPageListBySql(Pagination pagination, string queryJson)
        {
            var sqlWhere = new StringBuilder();
            var queryParam = queryJson.ToJObject();
			 List<DbParameter> parameter =  new List<DbParameter>();
            //查询条件
            if (!queryParam["keyword"].IsEmpty())
            {
                string keyword = queryParam["keyword"].ToString();
                sqlWhere.Append(" AND (Code like @keyword or Name like @keyword)");
				parameter.Add(DbParameters.CreateDbParameter("@keyword","%"+ keyword +"%",DbType.AnsiString));
            }
            
            return service.GetPageListBySql(pagination, sqlWhere.ToString(),parameter);
        }

		/// <summary>
        /// 列表
        /// </summary>
        /// <returns></returns>
        public IEnumerable<GY_SCDYEntity> GetList( string queryJson)
        {
             var expression = LinqExtensions.True<GY_SCDYEntity>();
            var queryParam = queryJson.ToJObject();
            //查询条件
            if (!queryParam["Name"].IsEmpty())
            {
                string name = queryParam["Name"].ToString();
                expression = expression.And(t => t.Id.Contains(name));
            }
			return service.GetList(expression);
        }

        /// <summary>
        /// 列表--分页
        /// </summary>
        /// <param name="pagination">分页</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        public IEnumerable<GY_SCDYEntity> GetPageList(Pagination pagination, string queryJson)
        {
			var expression = LinqExtensions.True<GY_SCDYEntity>();
            var queryParam = queryJson.ToJObject();
            var currentUser = OnlineUser.Operator.GetCurrent();
            if (!currentUser.IsSystem)
            {
                //string keyord = queryParam["keyword"].ToString();
                expression = expression.And(t => t.CreateUserName.Contains(currentUser.UserName));
            }
             //查询条件
            if (!queryParam["keyword"].IsEmpty())
            {
                string keyord = queryParam["keyword"].ToString();
                expression = expression.And(t => t.pname.Contains(keyord)); ;
                expression = expression.Or(t => t.hname.Contains(keyord));
            }

            if (!queryParam["StartTime"].IsEmpty())
            {
                string StartTime = queryParam["StartTime"].ToString();
                DateTime dt = DateTimeHelper.ToDate(StartTime);
                expression = expression.And(t => t.CreateDate >= dt);
            }
            //查询条件
            if (!queryParam["EndTime"].IsEmpty())
            {
                string EndTime = queryParam["EndTime"].ToString();
                DateTime dtt = DateTimeHelper.ToDate(EndTime);
                expression = expression.And(t => t.CreateDate <= dtt);
            }
            if (!queryParam["status"].IsEmpty())
            {
                string status = queryParam["status"].ToString();
                if (status == "0")
                {
                    expression = expression.And(t => t.status.Equals("待审核"));
                }
                else if (status == "1")
                {
                    expression = expression.And(t => t.status.Equals("通过"));
                }
                else if (status == "2")
                {
                    expression = expression.And(t => t.status.Equals("不通过"));
                }

            }
            return service.GetPageList(pagination, expression);
        }


        public IEnumerable<GY_SCDYEntity> GetListSee(Pagination pag, string queryjson)
        {
            var sqlwhere = new StringBuilder();
            var queryparam = queryjson.ToJObject();
            List<DbParameter> param = new List<DbParameter>();
            if (!queryparam["CJid"].IsEmpty())
            {
                sqlwhere.Append(" AND Marketresearch.bfactoryname in ( SELECT name FROM SYS_ORGANIZE WHERE id = @CJid)");
                param.Add(DbParameters.CreateDbParameter("@CJid", queryparam["CJid"].ToString(), DbType.AnsiString));
            }
            if (!queryparam["manager"].IsEmpty())
            {
                sqlwhere.Append(" AND Marketresearch.hname in ( SELECT name FROM BHOSPITAL WHERE manager = @manager)");
                param.Add(DbParameters.CreateDbParameter("@manager", queryparam["manager"].ToString(), DbType.AnsiString));
            }
            if (!queryparam["createuserid"].IsEmpty())
            {
                sqlwhere.Append(" AND  Marketresearch.createuserid = @createuserid");
                param.Add(DbParameters.CreateDbParameter("@createuserid", queryparam["createuserid"].ToString(), DbType.AnsiString));
            }
            if (!queryparam["startDate"].IsEmpty())
            {
                sqlwhere.Append(" AND  Marketresearch.createdate >= @startDate");
                param.Add(DbParameters.CreateDbParameter("@startDate", queryparam["startDate"].ToString(), DbType.AnsiString));
            }
            if (!queryparam["endDate"].IsEmpty())
            {
                sqlwhere.Append(" AND  Marketresearch.createdate <= @endDate");
                param.Add(DbParameters.CreateDbParameter("@endDate", queryparam["endDate"].ToString(), DbType.AnsiString));
            }
            if (!queryparam["searchYY"].IsEmpty())
            {
                sqlwhere.Append(" AND  Marketresearch.hname = @searchYY");
                param.Add(DbParameters.CreateDbParameter("@searchYY", queryparam["searchYY"].ToString(), DbType.AnsiString));
            }
            if (!queryparam["searchCJ"].IsEmpty())
            {
                sqlwhere.Append(" AND bfactoryname = @searchCJ ");
                param.Add(DbParameters.CreateDbParameter("@searchCJ", queryparam["searchCJ"].ToString(), DbType.AnsiString));
            }
            if (!queryparam["searchQX"].IsEmpty())
            {
                sqlwhere.Append(" AND ID in (SELECT BindId FROM Marketresearchd WHERE pname LIKE @searchQX)");
                param.Add(DbParameters.CreateDbParameter("@searchQX", "%" + queryparam["searchQX"].ToString() + "%", DbType.AnsiString));
            }
            return service.GetPageListBySql(pag, sqlwhere.ToString(), param);
        }
        /// <summary>
        /// 实体
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        public GY_SCDYEntity GetForm(string keyValue)
        {
            return service.GetForm(keyValue);
        }
        #endregion

        #region 数据处理

        

        /// <summary>
        /// 保存数据
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <param name="entity">实体</param>
        /// <returns></returns>
        public void SaveForm(string keyValue, GY_SCDYEntity gY_SCDYEntity, string ScoreList)
        {
            try
            {
                service.SaveForm(keyValue, gY_SCDYEntity, ScoreList);
                CacheFactory.Cache().WriteCache(cacheKey,gY_SCDYEntity);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void auditSave(string keyValue, GY_SCDYEntity gY_SCDYEntity)
        {
            try
            {
                service.auditSave(keyValue, gY_SCDYEntity);
                CacheFactory.Cache().WriteCache(cacheKey, gY_SCDYEntity);
            }
            catch (Exception)
            {
                throw;
            }
        }


		/// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        public void DeleteForm(string keyValue)
        {
            try
            {
                service.DeleteForm(keyValue);
                CacheFactory.Cache().RemoveCache(cacheKey);
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

    }
}
