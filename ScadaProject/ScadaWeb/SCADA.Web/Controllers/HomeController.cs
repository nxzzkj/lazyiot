using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ScadaWeb.Web.Areas.SysSet.Models;
using ScadaWeb.Model;
using ScadaWeb.Common;
using System.IO;
using ScadaWeb.IService;

namespace ScadaWeb.Web.Controllers
{
    public class HomeController : BaseController
    {
        public IDonationService DonationService { get; set; }

        public override ActionResult Index(int? id)
        {
            ViewData["SystemTopButtonList"] = TopButtonService.GetAll();
            ViewBag.Account = Operator == null ? "" : Operator.Account;
            ViewBag.HeadIcon = Operator == null ? "" : Operator.HeadIcon;
            return View(new WebModel().GetWebInfo());
        }
       
        public ActionResult Main()
        {
            ViewData["SystemTopButtonList"] = TopButtonService.GetAll();
            ViewBag.Account = Operator == null ? "" : Operator.Account;
            ViewBag.HeadIcon = Operator == null ? "" : Operator.HeadIcon;
            return View(new WebModel().GetWebInfo());
       
        }

        public JsonResult ExportFile()
        {
            
               UploadFile uploadFile = new UploadFile();
            try
            {
                var file = Request.Files[0];    //获取选中文件
                var filecombin = file.FileName.Split('.');
                if (file == null || string.IsNullOrEmpty(file.FileName) || file.ContentLength == 0 || filecombin.Length < 2)
                {
                    uploadFile.code = -1;
                    uploadFile.src = "";
                    uploadFile.msg = "上传出错!请检查文件名或文件内容";
                    return Json(uploadFile, JsonRequestBehavior.AllowGet);
                }
                //定义本地路径位置
                string localPath = Server.MapPath("~/Upload");
                string filePathName = string.Empty; //最终文件名
                filePathName = Common.Common.CreateNo() + "." + filecombin[1];
                //Upload不存在则创建文件夹
                if (!System.IO.Directory.Exists(localPath))
                {
                    System.IO.Directory.CreateDirectory(localPath);
                }
                file.SaveAs(Path.Combine(localPath, filePathName));  //保存图片
                uploadFile.code = 0;
                uploadFile.src = Path.Combine("/Upload/", filePathName);
                uploadFile.msg = "上传成功";
                return Json(uploadFile, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                uploadFile.code = -1;
                uploadFile.src = "";
                uploadFile.msg = "上传出错!程序异常";
                return Json(uploadFile, JsonRequestBehavior.AllowGet);
            }
        }

    }
}