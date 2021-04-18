using Scada.FlowGraphEngine.GraphicsMap;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Scada.DBUtility;
using Scada.Model;

namespace ScadaFlowDesign.Core
{
    [Serializable]
    public class FlowProject : ISerializable
    {
        // Fields
        public List<ScadaFlowUser> FlowUsers;
        public List<ScadaConnectionBase> ScadaConnections;
        private string mTitle;
        private string mCreateDate;
        private string mProjectID;
        private List<GraphAbstract> mGraphList;
        private string mPassword;
        public string FileFullName;

        // Methods
        public FlowProject()
        {
            this.FlowUsers = new List<ScadaFlowUser>();
            this.ScadaConnections = new List<ScadaConnectionBase>();
            this.mTitle = "";
            this.mCreateDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            this.mProjectID = "";
            this.mGraphList = new List<GraphAbstract>();
            this.mPassword = "123456";
            this.FileFullName = "";
            this.mProjectID = GUIDTo16.GuidToLongID().ToString();
            ScadaFlowUser item = new ScadaFlowUser
            {
                Nickname = "管理员",
                UserName = "admin",
                Password = "123456",
                Read = 1,
                Write = 1
            };
            this.FlowUsers.Add(item);
        }

        protected FlowProject(SerializationInfo info, StreamingContext context)
        {
            this.FlowUsers = new List<ScadaFlowUser>();
            this.ScadaConnections = new List<ScadaConnectionBase>();
            this.mTitle = "";
            this.mCreateDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            this.mProjectID = "";
            this.mGraphList = new List<GraphAbstract>();
            this.mPassword = "123456";
            this.FileFullName = "";
            this.mProjectID = (string)info.GetValue("mProjectID", typeof(string));
            this.mTitle = (string)info.GetValue("mTitle", typeof(string));
            this.mCreateDate = (string)info.GetValue("mCreateDate", typeof(string));
            this.mGraphList = (List<GraphAbstract>)info.GetValue("mGraphList", typeof(List<GraphAbstract>));
            this.mPassword = (string)info.GetValue("mPassword", typeof(string));
            this.FileFullName = (string)info.GetValue("FileFullName", typeof(string));
            this.FlowUsers = (List<ScadaFlowUser>)info.GetValue("FlowUsers", typeof(List<ScadaFlowUser>));
            this.ScadaConnections = (List<ScadaConnectionBase>)info.GetValue("ScadaConnections", typeof(List<ScadaConnectionBase>));
        }

        [SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("mProjectID", this.mProjectID);
            info.AddValue("mTitle", this.mTitle);
            info.AddValue("mCreateDate", this.mCreateDate);
            info.AddValue("mGraphList", this.mGraphList);
            info.AddValue("mPassword", this.mPassword);
            info.AddValue("FileFullName", this.FileFullName);
            info.AddValue("FlowUsers", this.FlowUsers);
            info.AddValue("ScadaConnections", this.ScadaConnections);
        }

        public void LoadWork(GraphAbstract site, GraphControl graph)
        {
            for (int i = 0; i < this.mGraphList.Count; i++)
            {
                if (this.mGraphList[i] == site)
                {
                    graph.Abstract = site;
                }
            }
        }

        // Properties
        public string Title
        {
            get
            {
                return this.mTitle;
            }
            set
            {
                this.mTitle = value;
            }
        }

        public string CreateDate
        {
            get
            {
                return this.mTitle;
            }
            set
            {
                this.mTitle = value;
            }
        }

        public string ProjectID
        {
            get
            {
                return this.mProjectID;
            }
            set
            {
                this.mProjectID = value;
            }
        }

        public List<GraphAbstract> GraphList
        {
            get
            {
                return this.mGraphList;
            }
            set
            {
                this.mGraphList = value;
            }
        }

        public string Password
        {
            get
            {
                return this.mPassword;
            }
            set
            {
                this.mPassword = value;
            }
        }
    }

}
