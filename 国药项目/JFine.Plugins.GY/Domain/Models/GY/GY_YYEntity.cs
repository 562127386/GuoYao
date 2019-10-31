/********************************************************************************
**文 件 名:GY_YYEntity
**命名空间:JFine.Plugins.GY.Busines.GY
**描    述:
**
**
**版 本 号:V1.0.0.0
**创 建 人:此代码由T4模板自动生成
**创建日期:2018-12-05 09:36:11
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
	/// GY_YYEntity
	/// </summary>	
	public class GY_YYEntity:BaseEntity<GY_YYEntity>, ICreate, IModify
	{

		/// <summary>
        /// 默认构造函数
        /// </summary>
        public GY_YYEntity()
		{
            this.Id= System.Guid.NewGuid().ToString();

 		}

	#region 实体成员

	  
	  /// <summary>
	  /// 主键
	  /// </summary>	
	  public string Id { get; set; }

	  
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
	  public string number { get; set; }

	  
	  /// <summary>
	  /// 医院名称
	  /// </summary>	
	  public string name { get; set; }

	  
	  /// <summary>
	  /// 地址
	  /// </summary>	
	  public string address { get; set; }

	  
	  /// <summary>
	  /// 联系人
	  /// </summary>	
	  public string linkman { get; set; }

	  
	  /// <summary>
	  /// 联系电话
	  /// </summary>	
	  public string phone { get; set; }

	  
	  /// <summary>
	  /// 业务员
	  /// </summary>	
	  public string salesman { get; set; }

	  
	  /// <summary>
	  /// 业务经理
	  /// </summary>	
	  public string manager { get; set; }

	  
	  /// <summary>
	  /// 备注
	  /// </summary>	
	  public string remark { get; set; }

	  
	  /// <summary>
	  /// 状态
	  /// </summary>	
	  public string status { get; set; }

 
  #endregion
    }
}

