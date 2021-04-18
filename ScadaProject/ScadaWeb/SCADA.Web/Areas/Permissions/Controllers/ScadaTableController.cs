using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ScadaWeb.Web.Controllers;
using ScadaWeb.IService;
using ScadaWeb.Model;
using ScadaWeb.Web.Areas.Scada.Models;
using ScadaWeb.Web.Areas.Permissions.Models;
using Newtonsoft.Json;
using ScadaWeb.Common;
using System.Web.Script.Serialization;
using System.Collections;

namespace ScadaWeb.Web.Areas.Permissions.Controllers
{
    /// <summary>
    /// 自定义二维显示表
    /// </summary>
    public class ScadaTableController : BaseController
    {
        public IScadaTableService TableService { set; get; }
        public IScadaTableRowsService TableRowService { set; get; }
        public IScadaTableUserRoleService TableUserRoleService { set; get; }
        public IUserService UserService { get; set; }
        public IScadaTableService ScadaTableService { set; get; }


        //直接使用基类BaseController的ButtonService
        // GET: Permissions/Button
        public override ActionResult Index(int? id)
        {

            base.Index(id);
            return View();
        }
        [HttpGet]
        public JsonResult List(ScadaTableModel model, PageInfo pageInfo)
        {
            var result = ScadaTableService.GetListByFilter(model, pageInfo);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Add(int id = 0)
        {
            var Users = UserService.GetAll();

            string str = "";
            foreach (var item in Users)
            {
                str += "{'value':'" + item.Id + "','title':'" + item.RealName + "'},";
            }
            if (!string.IsNullOrWhiteSpace(str))
            {
                str = str.Remove(str.Length - 1, 1);
            }
            str = "[" + str + "]";
            ViewData["Users"] = str;
            var roleusers = TableUserRoleService.GetByWhere(" where TableId=" + id);
            string rolestr = "";
            foreach (var user in roleusers)
            {
                rolestr += "'" + user.UserId + "',";
            }
            if (!string.IsNullOrWhiteSpace(rolestr))
            {
                rolestr = rolestr.Remove(rolestr.Length - 1, 1);
            }
            ViewData["PrivateUsers"] = "[" + rolestr + "]";
            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
        public JsonResult AddTable(ScadaTableModel model)
        {
            model.CreateTime = DateTime.Now;
            model.CreateUserId = Operator.UserId;
            model.UpdateTime = DateTime.Now;
            model.UpdateUserId = Operator.UserId;
            model.ColNum = 26;
            List<int> colWidths = new List<int>();
            List<string> colTitles = new List<string>();
            for (int i = 0; i < model.ColNum; i++)
            {
                colTitles.Add(ExcelConvert.ToName(i));
                colWidths.Add(120);

            }

            model.ColimnWidths = string.Join(",", colWidths.ToArray());
            model.ColumnTitles = string.Join(",", colTitles.ToArray());
            model.RowNum = 100;
            model.FilterRule = "";
            int id = 0;
            bool isres = TableService.Insert(model, out id);
            if (isres)
            {
                TableUserRoleService.DeleteByWhere(" where TableId=" + id);
                if (model.RoleUserID != null)
                {
                    string[] users = model.RoleUserID.Split(',');
                    for (int i = 0; i < users.Length; i++)
                    {
                        ScadaTableUserRoleModel role = new ScadaTableUserRoleModel();
                        role.CreateTime = DateTime.Now;
                        role.CreateTime = DateTime.Now;
                        role.CreateUserId = Operator.UserId;
                        role.UpdateTime = DateTime.Now;
                        role.UpdateUserId = Operator.UserId;
                        role.SortCode = i + 1;
                        role.TableId = id;
                        role.UserId = int.Parse(users[i]);
                        TableUserRoleService.Insert(role);
                    }

                }

            }
            var result = isres ? SuccessTip("添加成功") : ErrorTip("添加失败");
            return Json(result);
        }
        public ActionResult Edit(int id = 0)
        {
            var Model = TableService.GetById(id);
            var Users = UserService.GetAll();

            string str = "";
            foreach (var item in Users)
            {
                str += "{'value':'" + item.Id + "','title':'" + item.RealName + "'},";
            }
            if (!string.IsNullOrWhiteSpace(str))
            {
                str = str.Remove(str.Length - 1, 1);
            }
            str = "[" + str + "]";
            ViewData["Users"] = str;
            var roleusers = TableUserRoleService.GetByWhere(" where TableId=" + id);
            string rolestr = "";
            foreach (var user in roleusers)
            {
                rolestr += "'" + user.UserId + "',";
            }
            if (!string.IsNullOrWhiteSpace(rolestr))
            {
                rolestr = rolestr.Remove(rolestr.Length - 1, 1);
            }
            ViewData["PrivateUsers"] = "[" + rolestr + "]";
            return View(Model);
        }
        [HttpPost]
        [ValidateInput(false)]
        public JsonResult EditTable(ScadaTableModel model)
        {
            var sourmodel = TableService.GetById(model.Id);
            model.CreateTime = DateTime.Now;
            model.CreateUserId = Operator.UserId;
            model.UpdateTime = DateTime.Now;
            model.UpdateUserId = Operator.UserId;
            model.RowNum = 100;
            model.ColNum = 26;
            if(sourmodel!=null)
            {
                model.ColimnWidths = sourmodel.ColimnWidths;
                model.ColumnTitles = sourmodel.ColumnTitles;
            }
           
            bool isres = TableService.UpdateById(model);
            if (isres)
            {
                TableUserRoleService.DeleteByWhere(" where TableId=" + model.Id);
                if (model.RoleUserID != null)
                {
                    string[] users = model.RoleUserID.Split(',');
                    for (int i = 0; i < users.Length; i++)
                    {
                        ScadaTableUserRoleModel role = new ScadaTableUserRoleModel();
                        role.CreateTime = DateTime.Now;
                        role.CreateTime = DateTime.Now;
                        role.CreateUserId = Operator.UserId;
                        role.UpdateTime = DateTime.Now;
                        role.UpdateUserId = Operator.UserId;
                        role.SortCode = i + 1;
                        role.TableId = model.Id;
                        role.UserId = int.Parse(users[i]);
                        TableUserRoleService.Insert(role);
                    }

                }

            }
            var result = isres ? SuccessTip("保存成功") : ErrorTip("保存失败");
            return Json(result);
        }
        [HttpGet]
        public JsonResult Delete(int id)
        {
            bool res = TableService.DeleteById(id);
            if (res)
            {
                TableUserRoleService.DeleteByWhere(" where TableId=" + id);
                TableRowService.DeleteByWhere(" where TableId=" + id);
            }
            var result = res ? SuccessTip("删除成功") : ErrorTip("删除失败");
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public JsonResult BatchDel(string idsStr)
        {
            return Json(ErrorTip("不支持批量删除"), JsonRequestBehavior.AllowGet);

        }
        public ActionResult DesignTable(int Id = 0)
        {
            var rowModel = TableRowService.GetByWhere("where TableId=" + Id);
            var tableUsers = TableUserRoleService.GetByWhere("where TableId=" + Id);
            var tableModel = TableService.GetById(Id);
            TableEditModel model = new TableEditModel();
            model.TableId = Id;
            model.Title = tableModel != null ? tableModel.Title : "";
            model.RowNum = tableModel != null ? tableModel.RowNum : 100;

            var AllUsers = UserService.GetAll();
            model.AllUserJson = JsonConvert.SerializeObject(AllUsers);//获取当前的所有用户
            List<UserModel> privatemodels = new List<UserModel>();
            foreach (var item in tableUsers)
            {
                var whereItems = AllUsers.Where(x => x.Id == item.UserId);
                if (whereItems.Count() > 0)
                {
                    var extItem = whereItems.First();
                    privatemodels.Add(extItem);
                }

            }
            model.PrivateUserJson = JsonConvert.SerializeObject(privatemodels);//获取当前的所有用户
                                                                               //获取表的列宽度
            List<string> fontwidthmodels = new List<string>();
            if (tableModel != null &&!string.IsNullOrWhiteSpace( tableModel.ColimnWidths))
            {
                fontwidthmodels = tableModel.ColimnWidths.Split(',').ToList();
            }
            else
            {
                for (int i = 0; i < 26; i++)
                {
                    fontwidthmodels.Add("120");
                }

            }

            model.colwidthmodels = JsonConvert.SerializeObject(fontwidthmodels);
            //获取列标题
            //获取表的列宽度
            List<string> columntitlemodels = new List<string>();
            if (tableModel != null && !string.IsNullOrWhiteSpace(tableModel.ColumnTitles))
            {
                columntitlemodels = tableModel.ColumnTitles.Split(',').ToList();
            }
            else
            {
                for (int i = 0; i < 26; i++)
                {
                    columntitlemodels.Add(ExcelConvert.ToName(i));
                }

            }
            model.coltitlesmodels = JsonConvert.SerializeObject(columntitlemodels);
            return View(model);
        }
         ExcelModel CreateExcelModel(string[] keys, string[] values)
        {
            ExcelModel person = new ExcelModel();
            var len = keys.Length;
            for (int i = 0; i < len; i++)
            {
                person.GetType().GetField(keys[i]).SetValue(person, values[i]);
            }
            return person;
        }
        [HttpGet]
        public JsonResult GetExcelData(int id = 0)
        {
            var rowModes = TableRowService.GetByWhere("where TableId=" + id);
            List<ExcelModel> models = new List<ExcelModel>();
            List<List<string>> backcolormodels = new List<List<string>>();
            List<List<string>> fontcolormodels = new List<List<string>>();
            List<List<string>> fontsizemodels = new List<List<string>>();
            List<List<string>> fontweightmodels = new List<List<string>>();
          


                for (int i = 0; i < 100; i++)
                {
           
                    models.Add(new ExcelModel());
                }
            for (int i = 0; i < 100; i++)
            {
                List<string> row = new List<string>();
                for (int j = 0; j < 26; j++)
                {
                    row.Add("#ffffff");
                }
                backcolormodels.Add(row);
            }
            for (int i = 0; i < 100; i++)
            {
                List<string> row = new List<string>();
                for (int j = 0; j < 26; j++)
                {
                    row.Add("#000000");
                }
                fontcolormodels.Add(row);


            }
                for (int i = 0; i < 100; i++)
                {
                 
                List<string> row = new List<string>();
                for (int j = 0; j < 26; j++)
                {
                    row.Add("120");
                }
                fontsizemodels.Add(row);
            }
            for (int i = 0; i < 100; i++)
            {
                List<string> row = new List<string>();
                for (int j = 0; j < 26; j++)
                {
                    row.Add("normal");
                }
                fontweightmodels.Add(row);

            }


           
            

                ScadaTableRowsModel rowmodel = null;
                if (rowModes.Count() > 0)
                {
                    rowmodel = rowModes.First();
                }
            if (rowmodel != null)
            {
                try
                {
                    JavaScriptSerializer js = new JavaScriptSerializer();   //实例化一个能够序列化数据的类

                    backcolormodels = js.Deserialize<List<List<string>>>(rowmodel.FieldBackColors);
                    fontcolormodels = js.Deserialize<List<List<string>>>(rowmodel.FieldColors);
                    fontsizemodels = js.Deserialize<List<List<string>>>(rowmodel.FieldFontSizes);
                    models = js.Deserialize<List<ExcelModel>>(rowmodel.FieldIOPaths);
                    fontweightmodels = js.Deserialize<List<List<string>>>(rowmodel.FieldWeights);

                   
                }
                catch 
                {

                }
            }
              

            
            var result = Pager.ExcelPaging(models, backcolormodels, fontcolormodels, fontsizemodels, fontweightmodels, null, 100);
            return Json(result, JsonRequestBehavior.AllowGet);
       
       }
        public IDeviceGroupService DeviceGroupService { set; get; }
        public ActionResult IOEdit(string column,string value,string fontcolor,string backcolor,string fontweight)
        {
          
            IOEditModel editModel = new IOEditModel();
          
 
            editModel.Column = column;
            string[] items = value.Split('/');
            if (value.Split('/').Length>=8)
            {
                try
                {


                    editModel.Value = "";

                    editModel.GroupId = items[1];
                    editModel.ServerID = items[2];
                    editModel.CommunicateID = items[3];
                    editModel.DeviceID = items[4];
                    editModel.UpdateCycle = int.Parse(items[6]);
                    editModel.IOID = items[5];
                    editModel.UnitType = items[7];
                    editModel.IOPath = "/" + editModel.GroupId + "/" + editModel.ServerID + "/" + editModel.CommunicateID + "/" + editModel.DeviceID + "/" + editModel.IOID + "/" + editModel.UpdateCycle;
                    DeviceGroupModel deviceModel = DeviceGroupService.GetListByGroupIdDeviceId(int.Parse(editModel.GroupId), editModel.ServerID, editModel.CommunicateID, editModel.DeviceID).First();
                    editModel.Id = deviceModel.Id.ToString();
                }
                catch
                {

                }
            }
            else
            {
                editModel.Value = value;
            }
            editModel.FontColor = "#"+fontcolor;
            editModel.BackColor = "#" + backcolor;
            editModel.FontWeight = fontweight;
            return View(editModel);
        }
        public sealed class TableDesignModel
        {
            public string columnwidth { set; get; }
            public string columntitle{ set; get; }

            public List<ExcelModel> data
            {
                set;get;
            }
            public List<List<string>> fontsize
            {
                set;get;
            }
            public List<List<string>> backcolor
            {
                set; get;
            }
            public List<List<string>> fontcolor
            {
                set; get;
            }
            public List<List<string>> fontweight
            {
                set; get;
            }
        }
        [HttpPost]
        public JsonResult TableDesignSave(string data, int id = 0)
        {
            JavaScriptSerializer js = new JavaScriptSerializer();   //实例化一个能够序列化数据的类
            TableDesignModel myModel = js.Deserialize<TableDesignModel>(data);
            ScadaTableRowsModel model = new ScadaTableRowsModel();
            model.Id = 0;
            model.TableId = id;
            model.CreateTime = DateTime.Now;
            model.CreateUserId = Operator.UserId;
            model.UpdateTime = DateTime.Now;
            model.UpdateUserId = Operator.UserId;
            model.FieldBackColors = js.Serialize(myModel.backcolor);
            model.FieldColors = js.Serialize(myModel.fontcolor);
            model.FieldFontSizes = js.Serialize(myModel.fontsize);
            model.FieldWeights = js.Serialize(myModel.fontweight);
            model.FieldIOPaths = js.Serialize(myModel.data);
            var rowModes = TableRowService.GetByWhere("where TableId=" + id);
            var result= "保存失败";
            if(rowModes.Count()>0)
            {
                var TableModel = TableService.GetById(id);
                if(TableModel!=null)
                {
                    TableModel.ColimnWidths = myModel.columnwidth;
                    TableModel.ColumnTitles = myModel.columntitle;
                    TableService.UpdateById(TableModel);
                }
                model.Id = rowModes.First().Id;
                result = TableRowService.UpdateById(model) ? "保存设计成功" : "保存失败";
            }
            else
            {
                var TableModel = TableService.GetById(id);
                if (TableModel != null)
                {
                    TableModel.ColimnWidths = myModel.columnwidth;
                    TableModel.ColumnTitles = myModel.columntitle;
                    TableService.UpdateById(TableModel);
                    model.Id = 0;
                    model.TableId = TableModel.Id;
                    result = TableRowService.Insert(model) ? "保存设计成功" : "保存失败";
                }
               
            }
          
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}