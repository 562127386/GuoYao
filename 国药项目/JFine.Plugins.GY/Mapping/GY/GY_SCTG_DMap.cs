/********************************************************************************
**文 件 名:GY_SCTG_DMap
**命名空间:JFine.Plugins.GY.Busines.GY
**描    述:
**
**
**版 本 号:V1.0.0.0
**创 建 人:此代码由T4模板自动生成
**创建日期:2018-12-22 10:17:03
**修 改 人:
**修改日期:
**修改描述:
**
**
**版权所有: ©为之团队
*********************************************************************************/

using JFine.Plugins.GY.Domain.Models.GY;
using JFine.Data.Common;
using System.Data.Entity.ModelConfiguration;
namespace JFine.Plugins.GY.Mapping.GY
{	
	/// <summary>
	/// GY_SCTG_DMap
	/// </summary>	
	public class GY_SCTG_DMap:JFEntityTypeConfiguration<GY_SCTG_DEntity>
	{
	   public GY_SCTG_DMap()
	   {
	      this.ToTable("marketingd");
		  this.HasKey(t=>t.Id);
	   }
    }
}

