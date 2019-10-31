/********************************************************************************
**文 件 名:GY_BL_DEntity
**命名空间:JFine.Plugins.GY.Busines.GY
**描    述:
**
**
**版 本 号:V1.0.0.0
**创 建 人:此代码由T4模板自动生成
**创建日期:2018-12-06 18:25:34
**修 改 人:
**修改日期:
**修改描述:
**
**
**版权所有: ©为之团队
*********************************************************************************/
using System;
using JFine.Domain.Models;
namespace JFine.Plugins.GY.Domain.Models.GY
{	
	/// <summary>
	/// GY_BL_DEntity
	/// </summary>	
	public class GY_BL_DEntity:BaseEntity<GY_BL_DEntity>, ICreate, IModify
	{

		/// <summary>
        /// 默认构造函数
        /// </summary>
        public GY_BL_DEntity()
		{
            this.Id= System.Guid.NewGuid().ToString();

 		}

	#region 实体成员

	  
	  /// <summary>
	  /// 主键
	  /// </summary>	
	  public string Id { get; set; }

	  
	  /// <summary>
	  /// BindId
	  /// </summary>	
	  public string BindId { get; set; }

	  
	  /// <summary>
	  /// 创建日期
	  /// </summary>	
	  public DateTime? CreateDate { get; set; }

	  
	  /// <summary>
	  /// 创建用户账户
	  /// </summary>	
	  public string CreateUserId { get; set; }

	  
	  /// <summary>
	  /// 创建用户名称
	  /// </summary>	
	  public string CreateUserName { get; set; }

	  
	  /// <summary>
	  /// 最后修改时间
	  /// </summary>	
	  public DateTime? UpdateDate { get; set; }

	  
	  /// <summary>
	  /// 最后修改用户
	  /// </summary>	
	  public string UpdateUserId { get; set; }

	  
	  /// <summary>
	  /// 最后修改用户名称
	  /// </summary>	
	  public string UpdateUserName { get; set; }

	  
	  /// <summary>
	  /// 编号
	  /// </summary>	
	  public string fnumber { get; set; }

	  
	  /// <summary>
	  /// 厂家名称
	  /// </summary>	
	  public string fname { get; set; }

	  
	  /// <summary>
	  /// 类别
	  /// </summary>	
	  public string typename { get; set; }

	  
	  /// <summary>
	  /// 器械编号
	  /// </summary>	
	  public string pnumber { get; set; }

	  
	  /// <summary>
	  /// 器械名称
	  /// </summary>	
	  public string pname { get; set; }

	  
	  /// <summary>
	  /// 规格
	  /// </summary>	
	  public string spec { get; set; }

	  
	  /// <summary>
	  /// 数量
	  /// </summary>	
	  public decimal? quantity { get; set; }

	  
	  /// <summary>
	  /// 单位
	  /// </summary>	
	  public string unit { get; set; }

 
  #endregion
    }
}

