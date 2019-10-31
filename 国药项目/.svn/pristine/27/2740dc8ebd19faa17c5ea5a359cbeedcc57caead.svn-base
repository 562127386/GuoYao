/********************************************************************************
**文 件 名:GY_CJController
**命名空间:JFine.Plugins.GY.Busines.GY
**描    述:
** 厂家基本信息:bfactory
**
**版 本 号:V1.0.0.0
**创 建 人:此代码由T4模板自动生成
**创建日期:2018-12-05 12:01:16
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
	/// GY_CJController
	/// </summary>	
	public class GY_CJController:JFControllerBase
	{
		 private GY_CJBLL gY_CJBll = new GY_CJBLL();

        #region View
        //
        // GET: /GY/
        public override ActionResult Index()
        {
            return View("~/Plugins/JFine.GY/Views/GY_CJ/Index.cshtml");
        }

        /// <summary>
        /// 查看
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [HandlerAuthorize]
        public override ActionResult Details()
        {
            return View("~/Plugins/JFine.GY/Views/GY_CJ/Details2.cshtml");

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
            return View("~/Plugins/JFine.GY/Views/GY_CJ/Form2.cshtml");
        }

        #endregion

        #region 数据获取

        /// <summary>
        /// Get下拉表
        /// </summary>
        /// <returns></returns>
        public ActionResult GetAllCombox()
        {
            var data = gY_CJBll.GetListBySql(" AND STATUS ='1'").ToList();
            List<object> list = new List<object>();
            foreach (GY_CJEntity i in data)
            {
                list.Add(new { id = i.number, text = i.number + " - " + i.name });
            }
            return Content(list.ToJson());
        }

        public ActionResult GetByCode(string keyword)
        {
            var data = gY_CJBll.GetListBySql(" AND number ='"+keyword+"'").ToList();
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
            var data = gY_CJBll.GetList().ToList();
            if (!string.IsNullOrEmpty(keyword))
            {
                data = data.TreeWhere(t => t.name.Contains(keyword), "");
            }
            var treeList = new List<TreeSelectModel>();
            foreach (GY_CJEntity item in data)
            {
                TreeSelectModel treeModel = new TreeSelectModel();
                treeModel.id = item.name;
                treeModel.text = item.name;
                treeModel.parentId = "0";
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
                rows = gY_CJBll.GetPageList(pagination, queryJson),
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
            var data = gY_CJBll.GetList().ToList();
            if (!string.IsNullOrEmpty(keyword))
            {
                data = data.TreeWhere(t => t.name.Contains(keyword), "");
            }
            var treeList = new List<TreeGridModel>();
            foreach (GY_CJEntity item in data)
            {
                TreeGridModel treeModel = new TreeGridModel();
                bool hasChildren = data.Count(t => t.number == item.Id) == 0 ? false : true;
                treeModel.id = item.Id;
                treeModel.isLeaf = hasChildren;
                treeModel.parentId = item.number;
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
            var data = gY_CJBll.GetForm(keyValue);
            return Content(data.ToJson());
        }
        #endregion

        #region 数据处理
        

        /// <summary>
        /// 保存功能表单
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <param name="GY_CJEntity">功能实体</param>
        /// <returns></returns>
        [HttpPost]
        [HandlerAjaxOnly]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult SaveForm(string keyValue, GY_CJEntity gY_CJEntity)
        {
            gY_CJBll.SaveForm(keyValue, gY_CJEntity);
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
            gY_CJBll.DeleteForm(keyValue);
            return Success("删除成功。");
        }

        #endregion

    }
}

