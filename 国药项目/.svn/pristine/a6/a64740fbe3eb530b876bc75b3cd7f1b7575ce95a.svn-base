/********************************************************************************
**文 件 名:IGY_SCTGRepository
**命名空间:JFine.Plugins.GY.Busines.GY
**描    述:
**
**
**版 本 号:V1.0.0.0
**创 建 人:此代码由T4模板自动生成
**创建日期:2018-12-22 10:18:10
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
using JFine.Common.UI;
using System.Linq.Expressions;
using System.Data.Common;


namespace JFine.Plugins.GY.Domain.IRepository.GY
{	
	/// <summary>
	/// IGY_SCTGRepository
	/// </summary>	
	public interface IGY_SCTGRepository
	{
		#region 数据获取
        /// <summary>
        /// 列表
        /// </summary>
        /// <returns></returns>
        IEnumerable<GY_SCTGEntity> GetList();

		/// <summary>
        /// 列表
        /// </summary>
        /// <returns></returns>
        IEnumerable<GY_SCTGEntity> GetListBySql(string sqlWhere);

		/// <summary>
        /// 列表-分页
        /// </summary>
        /// <param name="pagination">分页</param>
        /// <param name="sqlWhere">查询条件</param>
        /// <returns></returns>
        IEnumerable<GY_SCTGEntity> GetPageListBySql(Pagination pagination, string sqlWhere ,List<DbParameter> parameter);

		/// <summary>
        /// 列表
        /// </summary>
        /// <returns></returns>
        IEnumerable<GY_SCTGEntity> GetList(Expression<Func<GY_SCTGEntity, bool>> condition);

		/// <summary>
        /// 列表-分页
        /// </summary>
        /// <param name="pagination">分页</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        IEnumerable<GY_SCTGEntity> GetPageList(Pagination pagination, Expression<Func<GY_SCTGEntity, bool>> condition);

        /// <summary>
        /// 实体
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        GY_SCTGEntity GetForm(string keyValue);
        #endregion

        #region 数据处理
        

        /// <summary>
        /// 保存数据
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <param name=entity">实体</param>
        /// <returns></returns>
        void SaveForm(string keyValue, GY_SCTGEntity gY_SCTGEntity, string ScoreList);

		/// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        void DeleteForm(string keyValue);

        #endregion

        void auditSave(string keyValue, GY_SCTGEntity gY_SCTGEntity);
    }
}

