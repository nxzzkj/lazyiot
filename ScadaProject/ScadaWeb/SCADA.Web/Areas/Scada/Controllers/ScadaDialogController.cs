using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ScadaWeb.Common;
using ScadaWeb.IService;
using ScadaWeb.Model;
using ScadaWeb.Web.Controllers;
using Temporal.WebDbAPI;
using Temporal.Net.InfluxDb.Models.Responses;
using System.Collections;
using ScadaWeb.Web.Areas.Scada.Models;
using System.Reflection;
using ScadaWeb.Service;
using System.Dynamic;
using Newtonsoft.Json;
using ScadaWeb.Web.Areas.Permissions.Models;
using System.Web.Script.Serialization;
using System.Text;
using System.Net;
using System.Net.WebSockets;
using System.Net.Sockets;
using System.Threading;
using Scada.AsyncNetTcp.Net;
using System.Threading.Tasks;
using Scada.AsyncNetTcp;

namespace ScadaWeb.Web.Areas.Scada.Controllers
{
    /// <summary>
    /// 通用SCADA系统系统的控制模块
    /// </summary>
    public class ScadaDialogController : BaseController
    {
        public WebInfluxDbManager mWebInfluxDbManager = new WebInfluxDbManager();
        public IIO_ParaService ParaBll { set; get; }

        public IScadaFlowProjectService ProjectServer { get; set; }
        public IScadaFlowViewService ViewServer { get; set; }
        public override ActionResult Index(int? id)
        {

            string vid = Request["vid"];
            if (vid == null || vid.ToString().Trim() == "")
                vid = "";
            ScadaFlowModel model = new ScadaFlowModel();
            if (vid == "")
            {
         

                string para = Request.QueryString["id"].Split('?')[0];
                string idstr = Request.QueryString["id"].Split('?')[1].Split('=')[1];
                base.Index(int.Parse(idstr));
                if (para != null && para != "")
                    id = int.Parse(para);
            }
            ScadaFlowProjectModel Project = ProjectServer.GetById(id.Value);
            if (Project != null && vid == "")
            {
                ScadaFlowViewModel view = ViewServer.GetByWhere(" where ProjectId='" + Project.ProjectId + "'").First();
                model.Project = Project;
                model.MainView = view;
                base.Index(Project.Id);
            }
            else if (vid != "")
            {
                ScadaFlowViewModel view = ViewServer.GetByWhere(" where  ViewId='" + vid + "'").First();
                if (view != null)
                {
                    Project = ProjectServer.GetByWhere(" where ProjectId='" + view.ProjectId + "'").First();
                    model.Project = Project;
                    model.MainView = view;
                    base.Index(Project.Id);
                }

            }
            return View(model);
        }
        #region 下置命令相关
        /// <summary>
        /// 发送一个下置命令消息到消息列表
        /// </summary>
        /// <param name="command"></param>
        private   bool SendNetMQ(IO_COMMANDS command)
        {
            try
            {
                ///获取本地的IP地址
                IPAddress AddressIP = IPAddress.Any;
                foreach (IPAddress _IPAddress in Dns.GetHostEntry(Dns.GetHostName()).AddressList)
                {
                    if (_IPAddress.AddressFamily.ToString() == "InterNetwork")
                    {
                        AddressIP = _IPAddress;
                    }
                }

                TcpData tcpData = new TcpData();
                byte[] datas = tcpData.StringToTcpByte(command.GetCommandString(), ScadaTcpOperator.下置命令);
                
                AsyncTcpClient Client = new AsyncTcpClient
                {
                    IPAddress = AddressIP,
                    Port = int.Parse(Configs.GetValue("Port")),
                    AutoReconnect = true,
                     ScadaClientType= ScadaClientType.WebSystem,
                    ConnectedCallback = async (c, isReconnected) =>
                    {
                        if (!c.IsClosing)
                        {
                            await c.WaitAsync();   // 等待服务器
                          
                          
                            //连接到服务器后向服务器发送心跳握手数据               
                        }


                    },
                    ConnectedTimeoutCallback = (c, isReconnected) =>
                    {
                        
                    },
                    ClosedCallback = (c, isReconnected) =>
                    {
                        
                    },

                    ReceivedCallback = (c, count) =>
                    {
                        
                        return Task.CompletedTask;
                    }
                };
                Client.RunAsync().GetAwaiter();
                Client.Send(new ArraySegment<byte>(datas));
                return true;
            }
            catch
            {
                return false;
            }
        }
        /// <summary>
        /// 用户下置命令
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult SendCommand(WellCommandModel model)
        {
            
            bool res = false;
           string    msg = "";
            if (model.io.Trim() == "")
                return null;
            IOParaModel para = ParaBll.GetByWhere(" where IO_SERVER_ID='"+ model.io.Split(',')[0] + "' and IO_COMM_ID='"+ model.io.Split(',')[1] + "' and IO_DEVICE_ID='"+ model.io.Split(',')[2] + "' and IO_ID='"+ model.io.Split(',')[3] + "'  ").First();
            IO_COMMANDS command = new IO_COMMANDS();
            command.COMMAND_DATE = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            command.IO_SERVER_ID = model.io.Split(',')[0].Trim();
            command.IO_COMM_ID = model.io.Split(',')[1].Trim();
            command.IO_DEVICE_ID = model.io.Split(',')[2].Trim();
            command.IO_ID = model.io.Split(',')[3].Trim();
            if (Operator == null)
            {
                command.COMMAND_SEND_USER = "WebSystem";
                command.COMMAND_SEND_USERNAME = "WebSystem";
            }
            else
            {
                command.COMMAND_SEND_USER = base.Operator.UserId.ToString();
                command.COMMAND_SEND_USERNAME = base.Operator.Account;
            }
      
  
            if (para != null)
            {
                try
                {
                    res = SendNetMQ(command);
                    msg = res ? "命令下置成功" : "下置命令失败";
                    command.IO_NAME = para.IO_NAME;
                    command.IO_LABEL = para.IO_LABEL;
                    command.COMMAND_ID = Guid.NewGuid().ToString();
                    command.COMMAND_RESULT = res.ToString().ToLower();
                    command.COMMAND_USER = "";
                    command.COMMAND_VALUE = model.writevalue;
                    //写入下置命令日志
                     mWebInfluxDbManager.DbWrite_CommandPoints(new List<IO_COMMANDS> { command }, DateTime.Now).GetAwaiter();
                  
                }
                catch(Exception emx)
                {
                    res = false;
                    msg = "命令下置失败,"+emx.Message;

                }
            }
            var result = new
            {
                result = res,
                msg = msg

            };
            return Json(result, JsonRequestBehavior.AllowGet);

        }

        #endregion

    }
}