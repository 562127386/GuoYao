/********************************************************************************
**文 件 名:GY_CJRepository
**命名空间:JFine.Plugins.GY.Busines.GY
**描    述:
**
**
**版 本 号:V1.0.0.0
**创 建 人:此代码由T4模板自动生成
**创建日期:2018-12-05 12:01:18
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
using System.Threading.Tasks;
using JFine.Data;
using JFine.Plugins.GY.Domain.Models.GY;
using JFine.Data.Repository;
using JFine.Plugins.GY.Domain.IRepository.GY;
using JFine.Common.UI;
using JFine.Common.Extend;
using JFine.Common.Json;
using System.Data.Common;
using System.Linq.Expressions;

namespace JFine.Plugins.GY.Domain.Repository.GY
{	
	/// <summary>
	/// GY_CJRepository
	/// </summary>	
	public class GY_CJRepository:RepositoryFactory<GY_CJEntity>, IGY_CJRepository
	{
		 #region 数据获取
        /// <summary>
        /// 列表
        /// </summary>
        /// <returns></returns>
        public IEnumerable<GY_CJEntity> GetList()
        {
            return this.BaseRepository().IQueryable().OrderByDescending(t => t.CreateDate).ToList();
        
		}

		/// <summary>
        /// 列表
        /// </summary>
        /// <returns></returns>
        public IEnumerable<GY_CJEntity> GetListBySql(string sqlWhere)
        {
            var strSql = new StringBuilder();
            strSql.Append(@"SELECT * 
                            FROM   bfactory
                            WHERE  1=1 ");
            strSql.Append(sqlWhere);
            return this.BaseRepository().FindList(strSql.ToString());
        
		}

		/// <summary>
        /// 列表-分页
        /// </summary>
        /// <param name="pagination">分页</param>
        /// <param name="sqlWhere">查询条件</param>
        /// <returns></returns>
        public IEnumerable<GY_CJEntity> GetPageListBySql(Pagination pagination, string sqlWhere, List<DbParameter> parameter)
        {

            var strSql = new StringBuilder();
            strSql.Append(@"SELECT * 
                            FROM   bfactory
                            WHERE  1=1 ");
            strSql.Append(sqlWhere);

            return this.BaseRepository().FindList(strSql.ToString(),parameter, pagination);

        }

		/// <summary>
        /// 列表
        /// </summary>
        /// <returns></returns>
        public IEnumerable<GY_CJEntity> GetList(Expression<Func<GY_CJEntity, bool>> condition)
        {
            return this.BaseRepository().IQueryable(condition).ToList();

        }


		/// <summary>
        /// 列表--分页
        /// </summary>
        /// <param name="pagination">分页</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        public IEnumerable<GY_CJEntity> GetPageList(Pagination pagination, Expression<Func<GY_CJEntity, bool>> condition)
        {
            return this.BaseRepository().FindList(condition, pagination);
        }

        /// <summary>
        /// 实体
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        public GY_CJEntity GetForm(string keyValue)
        {
            return this.BaseRepository().FindEntity(keyValue);
        }
        #endregion

        #region 数据处理
        
        /// <summary>
        /// 保存数据
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <param name="gY_CJEntity">实体</param>
        /// <returns></returns>
        public void SaveForm(string keyValue, GY_CJEntity gY_CJEntity)
        {
            if (!string.IsNullOrEmpty(keyValue))
            {
                gY_CJEntity.Modify(keyValue);
                this.BaseRepository().Update(gY_CJEntity);
            }
            else
            {
                gY_CJEntity.Create();
                this.BaseRepository().Insert(gY_CJEntity);
            }
        }

		/// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        public void DeleteForm(string keyValue)
        {
            this.BaseRepository().Delete(keyValue);
        }

        #endregion
    }
}


