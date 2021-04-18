using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Scada.Model
{
    [Serializable]
    /// <summary>
    /// 流程图管理的用户
    /// </summary>
    public class ScadaFlowUser: ISerializable
    {
        public override string ToString()
        {
            return _Nickname+"["+ _UserName + "]".ToString();
        }
        public ScadaFlowUser()
        { }
        protected ScadaFlowUser(SerializationInfo info, StreamingContext context)

        {
            #region 自定义属性
            this._UserName = (string)info.GetValue("_UserName", typeof(string));
            this._Nickname = (string)info.GetValue("_Nickname", typeof(string));
            this._Password = (string)info.GetValue("_Password", typeof(string));
            this._Write = (int)info.GetValue("_Write", typeof(int));
            this._Read = (int)info.GetValue("_Read", typeof(int));
          

            #endregion
        }
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("_UserName", this._UserName);
            info.AddValue("_Nickname", this._Nickname);
            info.AddValue("_Password", this._Password);
            info.AddValue("_Write", this._Write);
            info.AddValue("_Read", this._Read);
        }
        #region Model

        private string _UserName;
        private string _Nickname;
        private string _Password;
        private int _Write;
        private int _Read;
       
        /// <summary>
        /// 
        /// </summary>
        public string UserName
        {
            set { _UserName = value; }
            get { return _UserName; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Nickname
        {
            set { _Nickname = value; }
            get { return _Nickname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Password
        {
            set { _Password = value; }
            get { return _Password; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int Write
        {
            set { _Write = value; }
            get { return _Write; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int Read
        {
            set { _Read = value; }
            get { return _Read; }
        }

      
        #endregion Model

    }
}
