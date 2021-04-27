using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ScadaWeb.Common;
using ScadaWeb.IService;
using ScadaWeb.Model;

namespace ScadaWeb.Web.Controllers
{
    [HandlerLogin]
    public class BaseController : Controller
    {
        public virtual IItemsService ItemServer { set; get; }
        public virtual IItemsDetailService ItemDetailServer { set; get; }

        protected const string SuccessText = "操作成功！";
        protected const string ErrorText = "操作失败！";
        public IButtonService ButtonService { get; set; }
        public ITopButtonService TopButtonService { get; set; }
        public OperatorModel Operator
        {
            get { return OperatorProvider.Provider.GetCurrent(); }
        }
        // GET: Base
        public virtual ActionResult Index(int? id)
        {
            string url = Request.Url.ToString();

            var _menuId = id == null ? 0 : id.Value;
            var _roleId = Operator.RoleId;
            if (id != null)
            {
                ViewData["RightButtonList"]=ButtonService.GetButtonListByRoleIdModuleId(_roleId,_menuId,PositionEnum.FormInside);
                ViewData["TopButtonList"] = ButtonService.GetButtonListByRoleIdModuleId(_roleId, _menuId, PositionEnum.FormRightTop);
               
            }
            if(url.Contains("Scada/ScadaFlow"))
            {
                
            }
            return View();
        }
        /// <summary>
        /// 操作成功
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        protected virtual AjaxResult SuccessTip(string message = SuccessText)
        {
            return new AjaxResult { state = ResultType.success.ToString(), message = message };
        }
        /// <summary>
        /// 操作失败
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        protected virtual AjaxResult ErrorTip(string message = ErrorText)
        {
            return new AjaxResult { state = ResultType.error.ToString(), message = message };
        }
      
    
        public JsonResult GetItemType(string EnCode)
        {

            ItemsModel Item = ItemServer.GetItemByEnCode(EnCode);
            List<SelectOption> _select = new List<SelectOption>();


            IEnumerable<ItemsDetailModel> detailList = ItemDetailServer.GetByWhere(" where ItemId=" + Item.Id, null, " ItemCode,ItemName");
            if (detailList != null && detailList.Count() > 0)
            {

                foreach (var detail in detailList)
                {
                    SelectOption _option = new SelectOption
                    {
                        id = detail.ItemCode.ToString(),
                        name = detail.ItemName,
                        value= detail.ItemName

                    };
                    _select.Add(_option);
                }
            }
            
         
            return Json(_select, JsonRequestBehavior.AllowGet);
        }
        
    }
}