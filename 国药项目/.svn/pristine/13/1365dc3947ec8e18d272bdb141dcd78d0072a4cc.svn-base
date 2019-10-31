/********************************************************************************
**文 件 名:GY_SCTG_DRepository
**命名空间:JFine.Plugins.GY.Busines.GY
**描    述:
**
**
**版 本 号:V1.0.0.0
**创 建 人:此代码由T4模板自动生成
**创建日期:2018-12-22 10:17:04
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
	/// GY_SCTG_DRepository
	/// </summary>	
	public class GY_SCTG_DRepository:RepositoryFactory<GY_SCTG_DEntity>, IGY_SCTG_DRepository
	{
		 #region 数据获取
        /// <summary>
        /// 列表
        /// </summary>
        /// <returns></returns>
        public IEnumerable<GY_SCTG_DEntity> GetList()
        {
            return this.BaseRepository().IQueryable().OrderByDescending(t => t.CreateDate).ToList();
        
		}

		/// <summary>
        /// 列表
        /// </summary>
        /// <returns></returns>
        public IEnumerable<GY_SCTG_DEntity> GetListBySql(string sqlWhere)
        {
            var strSql = new StringBuilder();
            strSql.Append(@"SELECT * 
                            FROM   marketingd
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
        public IEnumerable<GY_SCTG_DEntity> GetPageListBySql(Pagination pagination, string sqlWhere, List<DbParameter> parameter)
        {

            var strSql = new StringBuilder();
            strSql.Append(@"SELECT * 
                            FROM   marketingd
                            WHERE  1=1 ");
            strSql.Append(sqlWhere);

            return this.BaseRepository().FindList(strSql.ToString(),parameter, pagination);

        }

		/// <summary>
        /// 列表
        /// </summary>
        /// <returns></returns>
        public IEnumerable<GY_SCTG_DEntity> GetList(Expression<Func<GY_SCTG_DEntity, bool>> condition)
        {
            return this.BaseRepository().IQueryable(condition).ToList();

        }


		/// <summary>
        /// 列表--分页
        /// </summary>
        /// <param name="pagination">分页</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        public IEnumerable<GY_SCTG_DEntity> GetPageList(Pagination pagination, Expression<Func<GY_SCTG_DEntity, bool>> condition)
        {
            return this.BaseRepository().FindList(condition, pagination);
        }

        /// <summary>
        /// 实体
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        public GY_SCTG_DEntity GetForm(string keyValue)
        {
            return this.BaseRepository().FindEntity(keyValue);
        }
        #endregion

        #region 数据处理
        
        /// <summary>
        /// 保存数据
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <param name="gY_SCTG_DEntity">实体</param>
        /// <returns></returns>
        public void SaveForm(string keyValue, GY_SCTG_DEntity gY_SCTG_DEntity)
        {
            if (!string.IsNullOrEmpty(keyValue))
            {
                gY_SCTG_DEntity.Modify(keyValue);
                this.BaseRepository().Update(gY_SCTG_DEntity);
            }
            else
            {
                gY_SCTG_DEntity.Create();
                this.BaseRepository().Insert(gY_SCTG_DEntity);
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


