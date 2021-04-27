using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScadaWeb.Model
{

    /// <summary>
    /// IO_COMMANDS:下置命令类
    /// </summary>
    [Serializable]
    public partial class IO_COMMANDS
    {
        public IO_COMMANDS()
        { }
        #region Model
        private string _command_id = "";
        private string _command_value = "";
        private string _command_date = "";
        private string _IO_SERVER_id = "";
        private string _io_comm_id = "";
        private string _io_device_id = "";
        private string _io_id = "";
        private string _io_name = "";
        private string _io_label = "";
        private string _command_result = "false";
        public string IO_LABEL
        {
            set { _io_label = value; }
            get { return _io_label; }
        }
        public string IO_NAME
        {
            set { _io_name = value; }
            get { return _io_name; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string COMMAND_ID
        {
            set { _command_id = value; }
            get { return _command_id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string COMMAND_VALUE
        {
            set { _command_value = value; }
            get { return _command_value; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string COMMAND_DATE
        {
            set { _command_date = value; }
            get { return _command_date; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string IO_SERVER_ID
        {
            set { _IO_SERVER_id = value; }
            get { return _IO_SERVER_id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string IO_COMM_ID
        {
            set { _io_comm_id = value; }
            get { return _io_comm_id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string IO_DEVICE_ID
        {
            set { _io_device_id = value; }
            get { return _io_device_id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string IO_ID
        {
            set { _io_id = value; }
            get { return _io_id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string COMMAND_RESULT
        {
            set { _command_result = value; }
            get { return _command_result; }
        }
        private string _command_user = "";
        public string COMMAND_USER
        {
            set { _command_user = value; }
            get { return _command_user; }
        }

        /// <summary>
        /// 下置用户
        /// </summary>
        public string COMMAND_SEND_USER
        {
            set;get;
        }
        /// <summary>
        /// 下置用户名
        /// </summary>
        public string COMMAND_SEND_USERNAME
        {
            set;get;
        }
        #endregion Model
        public string GetCommandString()
        {

            string str = "IO_ID:" + IO_ID + "#COMMAND_ID:" + COMMAND_ID + "#COMMAND_VALUE:" + COMMAND_VALUE + "#COMMAND_DATE:" + COMMAND_DATE.Replace("#", "//").Replace(":", "\\") + "#IO_SERVER_ID:" + IO_SERVER_ID + "#IO_COMM_ID:" + IO_COMM_ID + "#IO_DEVICE_ID:" + IO_DEVICE_ID + "#COMMAND_RESULT:" + COMMAND_RESULT + "#COMMAND_USER:" + COMMAND_USER + "#IO_LABEL:" + IO_LABEL + "#IO_NAME:" + IO_NAME;
            return str;
        }
    }
}
