/********************************************************************************
**文 件 名:GY_BLController
**命名空间:JFine.Plugins.GY.Busines.GY
**描    述:
**病例信息采集表 patientinfo
**
**版 本 号:V1.0.0.0
**创 建 人:此代码由T4模板自动生成
**创建日期:2018-12-06 18:22:45
**修 改 人:
**修改日期:
**修改描述:
**
**
**版权所有: ©为之团队
*********************************************************************************/
using JFine.Plugins.GY.Busines.GY;
using JFine.Common.UI;
using JFine.Common.Json;
using JFine.Plugins.GY.Domain.Models.GY;
using JFine.Web.Base.MVC.Handler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;

namespace JFine.Plugins.GY.Areas.GY.Controllers
{	
	/// <summary>
	/// GY_BLController
	/// </summary>	
	public class GY_BLController:JFControllerBase
	{
		 private GY_BLBLL gY_BLBll = new GY_BLBLL();
         private GY_BL_DBLL gY_BL_DBLL = new GY_BL_DBLL();

        #region View
        //
        // GET: /GY/
        public override ActionResult Index()
        {
            return View("~/Plugins/JFine.GY/Views/GY_BL/Index.cshtml");
        }

        //审核
        // GET: /GY/
        public ActionResult BLAuditIndex()
        {
            return View("~/Plugins/JFine.GY/Views/GY_BL/BLAuditIndex.cshtml");
        }

        //审核
        // GET: /GY/
        public ActionResult BLAuditForm()
        {
            ViewBag.Id = Request["keyValue"];
            return View("~/Plugins/JFine.GY/Views/GY_BL/BLAuditForm.cshtml");
        }

        /// <summary>
        /// Form表单
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [HandlerAuthorize]
        public override ActionResult Form()
        {
            ViewBag.Id = Request["keyValue"];
            return View("~/Plugins/JFine.GY/Views/GY_BL/Form2.cshtml");
        }

        /// <summary>
        /// 查看
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [HandlerAuthorize]
        public override ActionResult Details()
        {
            return View("~/Plugins/JFine.GY/Views/GY_BL/Details2.cshtml");

        }

        public ActionResult SelectBL()
        {
            return View("~/Plugins/JFine.GY/Views/GY_BB/SelectBL.cshtml");
        }
        public ActionResult SelectBysalesman()
        {
            return View("~/Plugins/JFine.GY/Views/GY_BB/SelectBysalesman.cshtml");
        }
        public ActionResult SelectBymanager()
        {
            return View("~/Plugins/JFine.GY/Views/GY_BB/SelectBymanager.cshtml");
        }
        public ActionResult SelectByCJ()
        {
            return View("~/Plugins/JFine.GY/Views/GY_BB/SelectByCJ.cshtml");
        }
        #endregion

        #region 数据获取
        public ActionResult GetDoubleList(Pagination pag,string queryjson)
        {
            var data = new
            {
                rows = gY_BLBll.GetLists(pag, queryjson),
                total = pag.total,
                page = pag.page,
                records = pag.records
            };
            return Content(data.ToJson());
        }


        /// <summary>
        /// 功能列表 
        /// </summary>
        /// <param name="keyword">关键字</param>
        /// <returns>返回树形Json</returns>
        [HttpGet]
        [HandlerAjaxOnly]
        public ActionResult GetTreeSelectJson(string keyword)
        {
            var data = gY_BLBll.GetList().ToList();
            if (!string.IsNullOrEmpty(keyword))
            {
                data = data.TreeWhere(t => t.pname.Contains(keyword), "");
            }
            var treeList = new List<TreeSelectModel>();
            foreach (GY_BLEntity item in data)
            {
                TreeSelectModel treeModel = new TreeSelectModel();
                treeModel.id = item.Id;
                treeModel.text = item.pname;
                treeModel.parentId = item.pname;
                treeList.Add(treeModel);
            }
            return Content(treeList.TreeSelectJson());
        
		}

		/// <summary>
        /// 列表 
        /// </summary>
        /// <param name="pagination">分页</param>
        /// <returns></returns>
		[HttpGet]
        [HandlerAjaxOnly]
        public ActionResult GetGridJson(Pagination pagination, string queryJson)
        {
            var data = new
            {
                rows = gY_BLBll.GetPageList(pagination, queryJson),
                total = pagination.total,
                page = pagination.page,
                records = pagination.records
            };
            return Content(data.ToJson());
        }
        /// <summary>
        /// 获取目录级功能列表 
        /// </summary>
        /// <param name="keyword">关键字</param>
        /// <returns>返回树形Json</returns>
        [HttpGet]
        public ActionResult GetTreeGridJson(string keyword)
        {
            var data = gY_BLBll.GetList().ToList();
            if (!string.IsNullOrEmpty(keyword))
            {
                data = data.TreeWhere(t => t.pname.Contains(keyword), "");
            }
            var treeList = new List<TreeGridModel>();
            foreach (GY_BLEntity item in data)
            {
                TreeGridModel treeModel = new TreeGridModel();
                bool hasChildren = data.Count(t => t.Id == item.Id) == 0 ? false : true;
                treeModel.id = item.Id;
                treeModel.isLeaf = hasChildren;
                treeModel.parentId = item.Id;
                treeModel.expanded = hasChildren;
                treeModel.entityJson = item.ToJson();
                treeList.Add(treeModel);
            }
            return Content(treeList.TreeGridJson());
        }

        /// <summary>
        /// 功能实体 返回对象Json
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult GetFormJson(string keyValue)
        {
            var data = gY_BLBll.GetForm(keyValue);
            String sqlWhere = " And BindId ='" + keyValue + "'";
            var subData = gY_BL_DBLL.GetListBySql(sqlWhere);
            var sub =  subData.ToJson();
            var d = data.ToJson();
            sub = ",\"sub\":" + sub;
            var tt=  d.Insert(d.IndexOf('}'), sub);
            return Content(tt);
        }
        #endregion

        #region 数据处理
        

        /// <summary>
        /// 保存功能表单
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <param name="GY_BLEntity">功能实体</param>
        /// <returns></returns>
        [HttpPost]
        [HandlerAjaxOnly]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult SaveForm2(string keyValue, GY_BLEntity gY_BLEntity)
        {
            gY_BLBll.SaveForm2(keyValue, gY_BLEntity);
            return Success("保存成功。");
        }


        /// <summary>
        /// 保存功能表单
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <param name="GY_BLEntity">功能实体</param>
        /// <returns></returns>
        [HttpPost]
        [HandlerAjaxOnly]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult SaveForm(string keyValue, GY_BLEntity gY_BLEntity, string ScoreList)
        {
            gY_BLBll.SaveForm(keyValue, gY_BLEntity, ScoreList);
            return Success("保存成功。");
        }

		/// <summary>
        /// 删除功能
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        [HttpPost]
        [HandlerAjaxOnly]
        [HandlerAuthorize]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteForm(string keyValue)
        {
            gY_BLBll.DeleteForm(keyValue);
            return Success("删除成功。");
        }

        #endregion

    }
}

