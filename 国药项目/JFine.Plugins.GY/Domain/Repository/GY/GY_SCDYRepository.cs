/********************************************************************************
**文 件 名:GY_SCDYRepository
**命名空间:JFine.Plugins.GY.Busines.GY
**描    述:
**
**
**版 本 号:V1.0.0.0
**创 建 人:此代码由T4模板自动生成
**创建日期:2018-12-22 10:15:13
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
	/// GY_SCDYRepository
	/// </summary>	
	public class GY_SCDYRepository:RepositoryFactory<GY_SCDYEntity>, IGY_SCDYRepository
	{
		 #region 数据获取
        /// <summary>
        /// 列表
        /// </summary>
        /// <returns></returns>
        public IEnumerable<GY_SCDYEntity> GetList()
        {
            return this.BaseRepository().IQueryable().OrderByDescending(t => t.CreateDate).ToList();
        
		}

		/// <summary>
        /// 列表
        /// </summary>
        /// <returns></returns>
        public IEnumerable<GY_SCDYEntity> GetListBySql(string sqlWhere)
        {
            var strSql = new StringBuilder();
            strSql.Append(@"SELECT * 
                            FROM   marketresearch
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
        public IEnumerable<GY_SCDYEntity> GetPageListBySql(Pagination pagination, string sqlWhere, List<DbParameter> parameter)
        {

            var strSql = new StringBuilder();
            strSql.Append(@"SELECT * 
                            FROM   marketresearch
                            WHERE  1=1 ");
            strSql.Append(sqlWhere);

            return this.BaseRepository().FindList(strSql.ToString(),parameter, pagination);

        }

		/// <summary>
        /// 列表
        /// </summary>
        /// <returns></returns>
        public IEnumerable<GY_SCDYEntity> GetList(Expression<Func<GY_SCDYEntity, bool>> condition)
        {
            return this.BaseRepository().IQueryable(condition).ToList();

        }


		/// <summary>
        /// 列表--分页
        /// </summary>
        /// <param name="pagination">分页</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        public IEnumerable<GY_SCDYEntity> GetPageList(Pagination pagination, Expression<Func<GY_SCDYEntity, bool>> condition)
        {
            return this.BaseRepository().FindList(condition, pagination);
        }

        /// <summary>
        /// 实体
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        public GY_SCDYEntity GetForm(string keyValue)
        {
            return this.BaseRepository().FindEntity(keyValue);
        }
        #endregion

        #region 数据处理
        
        /// <summary>
        /// 保存数据
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <param name="gY_SCDYEntity">实体</param>
        /// <returns></returns>
        public void SaveForm(string keyValue, GY_SCDYEntity gY_SCDYEntity, string ScoreList)
        {
            JFine.Data.Repository.IRepositoryBase db = new RepositoryFactory().BaseRepository().BeginTrans();
            if (!string.IsNullOrEmpty(keyValue))
            {
                gY_SCDYEntity.Modify(keyValue);
                db.Update(gY_SCDYEntity);
                //this.BaseRepository().Update(gY_SCDYEntity);
            }
            else
            {
                gY_SCDYEntity.Create();
                db.Insert(gY_SCDYEntity);
                //this.BaseRepository().Insert(gY_SCDYEntity);
            }
            List<GY_SCDY_DEntity> list_item = ScoreList.ToList<GY_SCDY_DEntity>();
            var sql = new StringBuilder();
            sql.AppendFormat("DELETE FROM marketresearchd WHERE BindId='{0}'", gY_SCDYEntity.Id);
            db.ExecuteBySql(sql.ToString());
            foreach (var item in list_item)
            {
                item.BindId = gY_SCDYEntity.Id;
                
                    item.Create();
                    db.Insert(item);
                
            }

            try
            {
                db.Commit();
            }
            catch (Exception)
            {
                db.Rollback();
                throw;
            }

        }

        //审核save
        public void auditSave(string keyValue, GY_SCDYEntity gY_SCDYEntity)
        {
            if (!string.IsNullOrEmpty(keyValue))
            {
                gY_SCDYEntity.Modify(keyValue);
                this.BaseRepository().Update(gY_SCDYEntity);
            }
            else
            {
                gY_SCDYEntity.Create();
                this.BaseRepository().Insert(gY_SCDYEntity);
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


